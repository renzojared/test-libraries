using GenerateDocument.Sample.Entities;

namespace GenerateDocument.Sample.Fakes;

public static class FakeInvoiceDocument
{
    private static readonly Random Random = new();

    public static InvoiceModel GetInvoiceDetails()
    {
        var items = Enumerable
            .Range(1, 8)
            .Select(i => GenerateRandomOrderItem())
            .ToList();

        return new InvoiceModel(
            Random.Next(1_000, 10_000),
            DateTime.Now,
            DateTime.Now + TimeSpan.FromDays(14),
            GenerateRandomAddress(),
            GenerateRandomAddress(),
            items,
            Placeholders.Paragraph());
    }

    private static OrderItem GenerateRandomOrderItem()
        => new OrderItem(
            Placeholders.Label(),
            (decimal)Math.Round(Random.NextDouble() * 100, 2),
            Random.Next(1, 10));

    private static Address GenerateRandomAddress()
        => new Address(
            Placeholders.Name(),
            Placeholders.Label(),
            Placeholders.Label(),
            Placeholders.Label(),
            Placeholders.Email(),
            Placeholders.PhoneNumber());
}