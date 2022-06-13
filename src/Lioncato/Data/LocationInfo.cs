namespace Lioncato.Data;

public class LocationInfo
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string AppleMapsUrl { get; set; } = string.Empty;
    public string GoogleMapsUrl { get; set; } = string.Empty;
    public bool IsPublic { get; set; }
    public string Name { get; set; } = string.Empty;

    public LocationInfo() { }
    
    public LocationInfo(string id) => Id = id;
}