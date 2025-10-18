using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using UrlShortener.WebAPI.Entities;
using UrlShortener.WebAPI.Services;

namespace UrlShortener.WebAPI.Endpoints;

internal static class UsersAuthEndpoints
{
    private record RegisterRequest(
        [Required, EmailAddress] string Email,
        [Required, MinLength(4)] string Username,
        [Required, MinLength(8)] string Password);

    private record LoginRequest(
        [Required, MinLength(4)] string EmailOrUsername,
        [Required, MinLength(8)] string Password);

    private record ErrorResponse(
        string Message, IEnumerable<string>? Errors = null);
    
    internal static void MapUsersAuthEndpoints(this IEndpointRouteBuilder app)
    {
        var authGroup = app
            .MapGroup("/api/auth")
            .ProducesValidationProblem()
            .WithOpenApi().WithTags("Authentication");

        
        // Get current user info
        authGroup.MapGet("/me", (ClaimsPrincipal user) =>
        {
            // Get user information from claims
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userName = user.FindFirst(ClaimTypes.Name)?.Value;
            var email = user.FindFirst(ClaimTypes.Email)?.Value;
        
            // Get additional claims if available
            var preferredUsername = user.FindFirst("preferred_username")?.Value;
            var jwtEmail = user.FindFirst("email")?.Value;
        
            if (string.IsNullOrEmpty(userId))
            {
                return Results.BadRequest(
                    new ErrorResponse("Invalid or expired token."));
            }

            // Return user profile information
            return Results.Ok(new
            {
                id = userId,
                username = userName ?? preferredUsername ?? "Unknown",
                email = email ?? jwtEmail ?? "Unknown"
            });
        })
        .RequireAuthorization()
        .WithDescription("Gets the current authenticated user's information")
        .WithSummary("Get Current User Info")
        .WithName("GetUserInfo");
        
        
        // Register new user
        authGroup.MapPost("/register",
            async (RegisterRequest request, UserManager<User> userManager) =>
        {
            // Check if user already exists by email
            var existingUserByEmail = await userManager.FindByEmailAsync(request.Email);
            if (existingUserByEmail != null) 
            {
                return Results.BadRequest(
                    new ErrorResponse("User with this email already exists."));
            }

            // Create new user
            var user = new User
            {
                UserName = request.Username,
                Email = request.Email,
                EmailConfirmed = false
            };

            var result = await userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                // Collect error descriptions
                var errors = result.Errors.Select(e => e.Description);
                return Results.BadRequest(new ErrorResponse("Registration failed.", errors));
            }
            return Results.Ok(new { message = "User registered successfully." });
        })
        .WithParameterValidation()
        .WithDescription("Creates a new user account")
        .WithSummary("Register a new user")
        .WithName("RegisterUser");

        
        // Login user
        authGroup.MapPost("/login",
            async (LoginRequest request, UserManager<User> userManager, 
                   SignInManager<User> signInManager, JwtIdentityService jwtService) =>
        {
            User? user;

            // Try to find user by email first, then by username
            user = request.EmailOrUsername.Contains('@')
                ? await userManager.FindByEmailAsync(request.EmailOrUsername)
                : await userManager.FindByNameAsync(request.EmailOrUsername);

            if (user == null) 
            {
                return Results.BadRequest(
                    new ErrorResponse("Invalid email/username or password."));
            }

            // Check password
            var result = await signInManager
                .CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: false);

            // Handle sign-in failures
            if (!result.Succeeded) 
            {
                if (result.IsLockedOut)
                {
                    return Results.BadRequest(
                        new ErrorResponse("Account is locked out. Please try again later."));
                }
                if (result.IsNotAllowed)
                {
                    return Results.BadRequest(
                        new ErrorResponse("Account is not allowed to sign in. Please confirm your email."));
                }
                return Results.BadRequest(
                    new ErrorResponse("Invalid email/username or password."));
            }

            // Generate JWT token
            var accessToken = jwtService.GenerateJwtToken(user);
            return Results.Ok(new { accessToken });
        })
        .WithParameterValidation()
        .WithDescription("Authenticates a user and returns a JWT token")
        .WithSummary("Login User")
        .WithName("LoginUser");
        
        
        // Logout user
        authGroup.MapPost("/logout", (ClaimsPrincipal user) =>
        {
            // Get user information from claims using correct claim types
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userName = user.FindFirst(ClaimTypes.Name)?.Value ?? 
                           user.FindFirst(ClaimTypes.Email)?.Value ?? 
                           "Unknown";

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(userName))
            {
                return Results.BadRequest(
                    new ErrorResponse("Invalid or expired token."));
            }

            // Return success response with instruction for client
            return Results.Ok(new
            {
                message = "Logout successful",
                instruction = "Token invalidated on client side"
            });
        })
        .RequireAuthorization()
        .WithDescription("Logs out the current user. Client should remove JWT token from storage.")
        .WithSummary("Logout User")
        .WithName("LogoutUser");

    }
}