using GenerateDocument.Soat.Elements;

namespace GenerateDocument.Soat.Documents;

public class SoatDigital(PolicyDetail detail, PolicyHolder holder) : Content(detail, holder), IDocument
{
    public void Compose(IDocumentContainer container)
    {
        container.Page(pg =>
        {
            pg.Margin(35);
            pg.DefaultTextStyle(s => s.FontColor(Colors.Blue.Darken4));
            pg.Size(PageSizes.A4);
            pg.Header().AlignTop().Element(Header.HeaderDocument);
            pg.Content().AlignMiddle().Element(ContentCertificate);
            pg.Footer().AlignBottom().Element(Footer.FooterCertificate);
        });
    }
}