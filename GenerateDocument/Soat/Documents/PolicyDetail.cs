namespace GenerateDocument.Soat.Documents;

public record PolicyDetail(
    string PolicyNumber,
    DateOnly FromInitial,
    DateOnly ToInitial,
    DateOnly FromFinal,
    DateOnly ToFinal);