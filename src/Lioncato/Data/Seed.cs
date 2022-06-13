#nullable disable

namespace Lioncato.Data;

public class Seed
{
    public async Task SeedDatabaseAsync(AppDbContext context)
    {
        if (!context.Users.Any())
        {
            var user = new UserInfo
            {
                Password = "6AD275D26C200E81534D9996183C8748DDFABC7B0A011A90F46301626D709923474703CACAB0FF8B67CD846B6CB55B23A39B03FBDFB5218EEC3373CF7010A166",
                Username = "Two",
            };
            await context.Users.AddAsync(user);
        }

        await context.SaveChangesAsync();
    }
}