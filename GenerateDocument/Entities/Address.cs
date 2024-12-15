namespace GenerateDocument.Entities;

public record Address(
    string CompanyName,
    string City,
    string State,
    object Email,
    string Phone);