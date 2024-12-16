namespace GenerateDocument.Soat.Elements
{
    internal static class Footer
    {
        internal static void FooterCertificate(IContainer container)
        {
            container.Row(row =>
            {
                row.RelativeItem().AlignCenter().DefaultTextStyle(TextStyle.Default.FontSize(12)).Column(col =>
                {
                    col.Item().PaddingBottom(4).Text(t =>
                    {
                        t.AlignCenter();
                        t.Span(FooterMessages.Information);
                    });

                    col.Item().Background(Colors.Blue.Darken4).Padding(8).Text(t =>
                    {
                        t.AlignCenter();
                        AddFooterLine(t, FooterMessages.AdditionalInformation);
                        t.SpanWithColor(FooterMessages.LinkInformation).Underline();
                    });
                });
            });
        }

        private static void AddFooterLine(TextDescriptor descriptor, params string[] lines)
        {
            foreach (var line in lines)
            {
                descriptor.SpanWithColor(line);
                descriptor.EmptyLine();
            }
        }

        private static TextSpanDescriptor SpanWithColor(this TextDescriptor descriptor, string text, Color? color = default)
            => descriptor.Span(text).FontColor(color ?? Colors.White);
    }
}