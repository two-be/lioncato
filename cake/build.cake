#addin "Cake.WebDeploy"

var password = Argument("password", "");
var task = Argument("task", "Default");
var username = Argument("username", "");

Task("Publish")
    .Description("Deploy to Azure using a custom Url")
    .Does(() =>
    {
        var settings = new DeploySettings()
        {
            Password = password.Replace("'", string.Empty),
            PublishUrl = "https://location.demosoft.me:8172/msdeploy.axd",
            SiteName = "Lioncato",
            SourcePath = @"../published",
            UseAppOffline = true,
            Username = username,
        };
        DeployWebsite(settings);
        Console.WriteLine(DateTime.Now);
    });

Task("Default")
    .Does(() => {
        Console.WriteLine("Default");
    });

RunTarget(task);
