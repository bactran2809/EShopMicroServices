using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;


namespace Ordering.Infrastructure.Data.Interceptors
{
    public class AuditableEntityInterceptor: SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntity(eventData.Context);
            return base.SavingChanges(eventData, result);
        }     
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntity(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
        private void UpdateEntity(DbContext? context)
        {
            if (context is null) return;

            foreach (var item in context.ChangeTracker.Entries<IEntity>())
            {
                if (item.State == EntityState.Added)
                {
                    item.Entity.CreatedBy = "ADMIN";
                    item.Entity.CreatedAt = DateTime.UtcNow;

                }
                if (item.State == EntityState.Added || item.State == EntityState.Modified || item.HasChangeOwnedEntitys())
                {
                    item.Entity.LastModifiedBy = "ADMIN";
                    item.Entity.LastModified = DateTime.UtcNow;
                }
            }
        }
    }

}

public static class Extention
{
    public static bool HasChangeOwnedEntitys(this EntityEntry entry) =>
        entry.References.Any(a =>
            a.TargetEntry != null
            && a.TargetEntry.Metadata.IsOwned()
            && (a.TargetEntry.State == EntityState.Modified || a.TargetEntry.State == EntityState.Added)
        );
}