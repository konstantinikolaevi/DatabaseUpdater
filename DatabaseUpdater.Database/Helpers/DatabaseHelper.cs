using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using DatabaseUpdater.Database.Contexts;
using DatabaseUpdater.Database.Exceptions;

namespace DatabaseUpdater.Database.Helpers;

public static class DatabaseHelper
{
    public static async Task UpdateDatabaseAsync(string connectionString, string targetMigration = null)
    {
        using var context = new DatabaseContext(connectionString);
        targetMigration ??= GetLocalMigrations().Last();
        await context.GetInfrastructure().GetService<IMigrator>().MigrateAsync(targetMigration);
        if (!context.Database.GetPendingMigrations().Any())
            new DatabaseInitializer().InitializeDatabase(context);
    }

    public static async Task<bool> TestDatabaseConnectionAsync(string connectionString, bool throwOnError = false, CancellationToken? cancellationToken = null)
    {
        using var context = new DatabaseContext(connectionString);
        try
        {
            using var timeoutCts = new CancellationTokenSource(TimeSpan.FromSeconds(2));
            using var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(timeoutCts.Token, cancellationToken.GetValueOrDefault());
            await context.Database.GetDbConnection().OpenAsync(linkedCts.Token);
            return true;
        }
        catch
        {
            if (throwOnError)
                throw new DatabaseConnectionException();
            return false;
        }
    }

    public static IEnumerable<string> GetLocalMigrations()
    {
        using var context = new DatabaseContext();
        return context.Database.GetMigrations();
        //return Assembly.GetAssembly(typeof(DatabaseContext)).DefinedTypes
        //    .Select(x => x.AsType())
        //    .Where(x => x.IsSubclassOf(typeof(Migration)))
        //    .Select(x => x.Name)
        //    .ToList();
    }
}