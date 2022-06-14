#nullable disable

using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace Lioncato.Data;

public class AppService
{
    public async Task<UserInfo> GetUserAsync(ProtectedLocalStorage localStorage)
    {
        var rs = await localStorage.GetAsync<UserInfo>("user");
        if (rs.Success)
        {
            return rs.Value;
        }
        return new UserInfo(string.Empty);
    }

    public async Task SetUserAsync(ProtectedLocalStorage localStorage, UserInfo user)
    {
        await localStorage.SetAsync("user", user);
    }
}