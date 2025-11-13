using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace UrlShortener.WebAPI.Database;

internal class SoftDeleteInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData, InterceptionResult<int> result)
    {
        if (eventData.Context is null) return result;

        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            // Skip if the entity is not being deleted and not implements ISoftDeletable
            if (entry is not { State: EntityState.Deleted, Entity: ISoftDeletable softDeletable }) 
                continue;
            
            // Skip to permanently delete if the entity is already marked soft deleted 
            if (entry is { State: EntityState.Deleted, Entity: ISoftDeletable { IsDeleted: true } })
                continue;
            
            // Change the state to Modified instead of Deleted
            entry.State = EntityState.Modified;
            softDeletable.DeletedAt = DateTime.UtcNow;

            // Handle cascading soft delete for navigations
            foreach (var navigation in entry.Navigations)
            {
                if (navigation.Metadata.IsCollection)
                {
                    // Skip If the navigation is not a collection
                    if (navigation.CurrentValue is not IEnumerable<object> children) 
                        continue;

                    // Soft delete each child entity that implements ISoftDeletable
                    foreach (var child in children.OfType<ISoftDeletable>()) 
                        child.DeletedAt = DateTime.UtcNow;
                }
                else
                {
                    // Soft delete the single child entity that implements ISoftDeletable
                    if (navigation.CurrentValue is ISoftDeletable child) 
                        child.DeletedAt = DateTime.UtcNow;
                }
            }
        }
        return result;
    }
}