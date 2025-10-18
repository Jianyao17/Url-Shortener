using System.Reflection;

namespace UrlShortener.WebAPI.Extensions;

internal static class ConfigLoaderExtensions
{
    /// <summary>
    /// Load and register all configuration classes from the "Config" directory.
    /// </summary>
    internal static void AddAllConfigs(this IServiceCollection services, IConfiguration configuration)
    {
        var configTypes = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t 
                => t.Namespace != null && 
                   t.Namespace.EndsWith(".Config") && 
                   !t.IsAbstract && 
                   t.IsClass);

        foreach (var type in configTypes)
        {
            // Derive section name from class name by removing "Config" suffix if present
            var sectionName = type.Name.EndsWith("Config")
                ? type.Name[..^"Config".Length]
                : type.Name;

            var section = configuration.GetSection(sectionName);
            var configInstance = Activator.CreateInstance(type);
            section.Bind(configInstance);

            services.AddSingleton(type, configInstance!);
        }
    }
}