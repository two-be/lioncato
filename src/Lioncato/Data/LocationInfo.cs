namespace Lioncato.Data;

public record LocationInfo
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string AppleMapsUrl { get; set; } = string.Empty;
    public string GoogleMapsUrl { get; set; } = string.Empty;
    public bool IsPublic { get; set; }
    public string Name { get; set; } = string.Empty;

    public LocationInfo() { }

    public LocationInfo(string id) => Id = id;

    public string Validate()
    {
        if (string.IsNullOrEmpty(Name))
        {
            return "Please enter a valid Name";
        }
        return string.Empty;
    }
}