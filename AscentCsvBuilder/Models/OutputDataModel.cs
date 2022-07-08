using CsvHelper.Configuration.Attributes;

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

    [Name("Regulation ID")]
    public string RegulatorId { get; set; }

    [Ignore]
    public string Type { get; set; }

    [Name("Name")]
    public string Name { get; set; }

    [Name("Region")]
    public string Region { get; set; }

    [Name("Country")]
    public string Country { get; set; }

    [Name("State/Territory")]
    public string State { get; set; }

    [Name("Link")]
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

    [Name("Rule ID")]
    public string RuleId { get; set; }

    [Ignore]
    public string Type { get; set; }

    [Name("Rule Number")]
    public string RuleNumber { get; set; }

    [Name("Rule Title")]
    public string RuleTitle { get; set; }

    [Name("Content")]
    public string Content { get; set; }

    [Ignore]
    public long Position { get; set; }

    [Name("Effective Date")]
    public DateTimeOffset EffectiveDate { get; set; }

    [Name("Expiration Date")]
    public DateTimeOffset? ExpirationDate { get; set; }

    [Name("Published Date")]
    public DateTimeOffset PublishedDate { get; set; }

    [Ignore]
    public DateTimeOffset CreatedAt { get; set; }

    [Ignore]
    public DateTimeOffset ModifiedAt { get; set; }

    [Name("Regulator")]
    public string RegulatorId { get; set; }

    [Ignore]
    public string RegulatorName { get; set; }

    [Name("Link")]
    public string Link { get; set; }

    [Name("Section")]
    public string Section { get; set; }

    [Name("Subsection")]
    public string Subsection { get; set; }
}

public class Obligation
{
    public Obligation(Datum datum)
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
        SupportingInformation = string.Empty;
    }

    [Name("Obligation ID")]
    public string ObligationId { get; set; }

    [Ignore]
    public string Type { get; set; }

    [Ignore]
    public DateTimeOffset CreatedAt { get; set; }

    [Ignore]
    public DateTimeOffset ModifiedAt { get; set; }

    [Name("Frequency")]
    public string Frequency { get; set; }

    [Ignore]
    public string Preview { get; set; }

    [Ignore]
    public DateTimeOffset StatusChangedAt { get; set; }

    [Name("Link")]
    public string Link { get; set; }

    [Name("Regulatory Rule")]
    public string RegulatoryRule { get; set; }

    [Name("Regulator")]
    public string Regulator { get; set; }

    [Name("Citation")]
    public string Citation { get; set; }

    [Name("Effective Date")]
    public DateTimeOffset EffectiveDate { get; set; }

    [Name("Expiration Date")]
    public DateTimeOffset? ExpirationDate { get; set; }

    [Name("Status")]
    public string Status { get; set; }

    [Name("Obligation Content")]
    public string ObligationContent { get; set; }

    [Name("Due Date")]
    public DateTimeOffset? DueDate { get; set; }

    [Name("Supporting Information")]
    public string SupportingInformation { get; set; }
}
