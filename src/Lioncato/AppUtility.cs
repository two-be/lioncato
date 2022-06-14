using System.Text;
using Lioncato.Data;
using Microsoft.EntityFrameworkCore;

public static class AppUtility
{
    public static async Task EnsureDbCreatedAndSeedAsync(DbContextOptions<AppDbContext> options)
    {
        var factory = new LoggerFactory();
        var builder = new DbContextOptionsBuilder<AppDbContext>(options).UseLoggerFactory(factory);

        using var context = new AppDbContext(builder.Options);

        if (await context.Database.EnsureCreatedAsync())
        {
            var seed = new Seed();
            await seed.SeedDatabaseAsync(context);
        }
    }
}

public static class AppClass
{
    public static readonly string FadeIn = "animate__animated animate__fadeIn";
}

public static class AppExtensions
{
    public static string ToSHA512(this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return string.Empty;
        }

        using var sha = System.Security.Cryptography.SHA512.Create();
        var utf8Bytes = Encoding.UTF8.GetBytes(value);
        var hash = sha.ComputeHash(utf8Bytes);

        return BitConverter.ToString(hash).Replace("-", string.Empty);
    }
}

public enum ActionType
{
    None = 0,
    Delete = 1,
    Save = 2,
}