namespace AscentCsvBuilder.Models;

public class Regulator
{
    public Regulator(Datum datum)
    {
        RegulatorId = datum.Id;
        Type = datum.Type;
        Name = datum.Attributes.Name;
        Region = datum.Attributes.RegionLocation;
        Country = datum.Attributes.CountryLocation;
        State = datum.Attributes.StateTerritoryLocation;
        Link = datum.Attributes.Links.App.ToString();
    }

    public string RegulatorId { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public string Region { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
    public string Link { get; set; }

}

public class Rule
{
    public Rule(Datum datum)
    {
        RuleId = datum.Id;
        Type = datum.Type;
        RuleNumber = datum.Attributes.Number;
        RuleTitle = datum.Attributes.Title;
        Content = datum.Attributes.Content;
        Position = datum.Attributes.Position;
        EffectiveDate = datum.Attributes.StartsAt;
        ExpirationDate = datum.Attributes.EndsAt;
        PublishedDate = datum.Attributes.PublishedDate;
        CreatedAt = datum.Attributes.CreatedAt;
        ModifiedAt = datum.Attributes.ModifiedAt;
        RegulatorId = datum.Attributes.Hierarchy.FirstOrDefault(f => f.Type == "regulator").Id;
        RegulatorName = datum.Attributes.Hierarchy.FirstOrDefault(f => f.Type == "regulator").Name;
        Link = datum.Attributes.Links.App.ToString();
        Section = datum.Attributes.Hierarchy[1].Name;
        Subsection = datum.Attributes.Hierarchy[0].Name;
    }

    public string RuleId { get; set; }
    public string Type { get; set; }
    public string RuleNumber { get; set; }
    public string RuleTitle { get; set; }
    public string Content { get; set; }
    public long Position { get; set; }
    public DateTimeOffset EffectiveDate { get; set; }
    public DateTimeOffset? ExpirationDate { get; set; }
    public DateTimeOffset PublishedDate { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset ModifiedAt { get; set; }
    public string RegulatorId { get; set; }
    public string RegulatorName { get; set; }
    public string Link { get; set; }
    public string Section { get; set; }
    public string Subsection { get; set; }
}

public class AscentTask
{
    public AscentTask(Datum datum)
    {
        ObligationId = datum.Id;
        Type = datum.Type;
        CreatedAt = datum.Attributes.CreatedAt;
        ModifiedAt = datum.Attributes.ModifiedAt;
        Frequency = datum.Attributes.Frequency;
        Preview = datum.Attributes.Preview;
        StatusChangedAt = datum.Attributes.StatusChangedAt;
        Link = datum.Attributes.Links.Self.ToString();
        RegulatoryRule = datum.Attributes.Hierarchy.FirstOrDefault(f => f.Type == "rule").Id;
        Regulator = datum.Attributes.Hierarchy.FirstOrDefault(f => f.Type == "regulator").Id;
        Citation = datum.Attributes.Citation;
        EffectiveDate = datum.Attributes.StartsAt;
        ExpirationDate = datum.Attributes.EndsAt;
        Status = datum.Attributes.Status;
        ObligationContent = datum.Attributes.Content;
        DueDate = datum.Attributes.DueDate;
    }

    public string ObligationId { get; set; }
    public string Type { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset ModifiedAt { get; set; }
    public string Frequency { get; set; }
    public string Preview { get; set; }
    public DateTimeOffset StatusChangedAt { get; set; }
    public string Link { get; set; }
    public string RegulatoryRule { get; set; }
    public string Regulator { get; set; }
    public string Citation { get; set; }
    public DateTimeOffset EffectiveDate { get; set; }
    public DateTimeOffset? ExpirationDate { get; set; }
    public string Status { get; set; }
    public string ObligationContent { get; set; }
    public DateTimeOffset? DueDate { get; set; }
}
