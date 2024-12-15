namespace GenerateDocument.Entities;

public record OrderItem(
    string Name,
    decimal Price,
    int Quantity);