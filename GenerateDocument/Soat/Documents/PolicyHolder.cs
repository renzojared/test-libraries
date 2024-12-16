namespace GenerateDocument.Soat.Documents;

public record PolicyHolder(
    string Plate,
    string Category,
    string Use,
    string Series,
    string FullName,
    decimal Premium,
    DateOnly DateOfIssue,
    TimeOnly TimeOfIssue);