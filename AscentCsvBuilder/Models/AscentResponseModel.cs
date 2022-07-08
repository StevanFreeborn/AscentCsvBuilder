using System.Text.Json.Serialization;

namespace AscentCsvBuilder.Models;

public class AscentResponse
{
    [JsonPropertyName("data")]
    public List<Datum> Data { get; set; }

    [JsonPropertyName("links")]
    public AscentResponseLinks Links { get; set; }
}

public class Datum
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("attributes")]
    public Attributes Attributes { get; set; }
}

public class AttributesLinks
{
    [JsonPropertyName("app")]
    public Uri App { get; set; }

    [JsonPropertyName("self")]
    public Uri Self { get; set; }
}

public class AscentResponseLinks
{
    [JsonPropertyName("self")]
    public Uri Self { get; set; }

    [JsonPropertyName("first")]
    public Uri First { get; set; }

    [JsonPropertyName("prev")]
    public Uri Prev { get; set; }

    [JsonPropertyName("next")]
    public Uri Next { get; set; }
}

public partial class Hierarchy
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("position")]
    public long? Position { get; set; }
}

public class Attributes
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("regionLocation")]
    public string RegionLocation { get; set; }

    [JsonPropertyName("countryLocation")]
    public string CountryLocation { get; set; }

    [JsonPropertyName("stateTerritoryLocation")]
    public string StateTerritoryLocation { get; set; }

    [JsonPropertyName("links")]
    public AttributesLinks Links { get; set; }

    [JsonPropertyName("number")]
    public string Number { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("content")]
    public string Content { get; set; }

    [JsonPropertyName("position")]
    public long Position { get; set; }

    [JsonPropertyName("startsAt")]
    public DateTimeOffset StartsAt { get; set; }

    [JsonPropertyName("endsAt")]
    public DateTimeOffset? EndsAt { get; set; }

    [JsonPropertyName("publishedDate")]
    public DateTimeOffset PublishedDate { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTimeOffset CreatedAt { get; set; }

    [JsonPropertyName("modifiedAt")]
    public DateTimeOffset ModifiedAt { get; set; }

    [JsonPropertyName("hierarchy")]
    public List<Hierarchy> Hierarchy { get; set; }

    [JsonPropertyName("frequency")]
    public string Frequency { get; set; }

    [JsonPropertyName("preview")]
    public string Preview { get; set; }

    [JsonPropertyName("disableReason")]
    public object DisableReason { get; set; }

    [JsonPropertyName("statusChangedAt")]
    public DateTimeOffset StatusChangedAt { get; set; }

    [JsonPropertyName("citation")]
    public string Citation { get; set; }

    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("dueDate")]
    public DateTimeOffset? DueDate { get; set; }
}
