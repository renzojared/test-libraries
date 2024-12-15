namespace GenerateDocument.Entities;

public record InvoiceModel(
    int InvoiceNumber,
    DateTime IssueDate,
    DateTime DueDate,
    Address SellerAddress,
    Address CustomerAddress,
    List<OrderItem> Items,
    string Comments);