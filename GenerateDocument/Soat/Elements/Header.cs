namespace GenerateDocument.Soat.Elements;

internal static class Header
{
    private static readonly TextStyle DefaultStyle = TextStyle.Default.FontSize(14).FontColor(Colors.Pink.Medium);

    internal static void HeaderDocument(IContainer container)
    {
        container.BorderBottom(1).BorderColor(Colors.Pink.Darken4).Row(row =>
        {
            row.RelativeItem().AlignLeft().Column(col =>
            {
                col.Item().Width(200).Image(ImageBase64.Logo);
                col.Spacing(5);
                col.Item().PaddingLeft(5).PaddingTop(5).Text(HeaderMessages.Certificate).Style(DefaultStyle);
                col.Item().PaddingLeft(5).PaddingBottom(5).Text(HeaderMessages.Decree).Style(DefaultStyle);
            });

            row.ConstantItem(250).AlignCenter().Column(col =>
            {
                col.Item().Padding(1);
                col.Item().Text(HeaderMessages.Product).FontSize(62).ExtraBold().FontColor(Colors.Pink.Darken2);
            });
        });
    }
}