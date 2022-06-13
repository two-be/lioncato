namespace Lioncato.Data;

public class UserInfo
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string Password { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;

    public UserInfo() { }

    public UserInfo(string id) => Id = id;
}