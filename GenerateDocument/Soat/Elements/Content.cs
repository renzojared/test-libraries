using GenerateDocument.Soat.Documents;

namespace GenerateDocument.Soat.Elements;

public class Content(PolicyDetail detail, PolicyHolder holder)
{
    internal void ContentCertificate(IContainer container)
    {
        container.Extend().Padding(2).Column(col =>
        {
            col.Item().Row(row =>
            {
                row.RelativeItem(50);
                row.RelativeItem(50);
            });
            col.Item().Element(TableContent);
        });
    }

    private void TableContent(IContainer container)
    {
        container.Table(tbl =>
        {
            tbl.ColumnsDefinition(col =>
            {
                col.RelativeColumn(4);
                col.RelativeColumn(2);
                col.RelativeColumn(2);
            });

            tbl.Header(h =>
            {
                h.Cell().Element(StyleHeader).Text(ContentMessages.InsuranceCompany);
                h.Cell().ColumnSpan(2).AlignCenter().Element(StyleHeader).Text(ContentMessages.EmergencyCase);
            });

            tbl.Cell().Padding(1).Image(ImageBase64.InsuranceCompany)
                .WithCompressionQuality(ImageCompressionQuality.High);

            tbl.Cell().ColumnSpan(2).PaddingTop(10).AlignCenter().Text(ContentMessages.ContactNumber).FontSize(40)
                .ExtraBold();

            tbl.Cell().ColumnSpan(3).Text(new string('\\', 96));

            PolicyDetail(tbl, ContentMessages.SectionPolicyDetail);
            tbl.Cell().ColumnSpan(3).Height(10);
            PolicyHolder(tbl, ContentMessages.SectionPolicyHolder);
        });
    }

    private void PolicyDetail(TableDescriptor tableDescriptor, string section)
    {
        tableDescriptor.Cell().ColumnSpan(3).Element(StyleContent).Text(section);

        tableDescriptor.Cell().Text(ContentMessages.PolicyNumberField);
        tableDescriptor.Cell().ColumnSpan(2).Text(ContentMessages.Message1);

        tableDescriptor.Cell().Text(detail.PolicyNumber);
        tableDescriptor.Cell().ColumnSpan(2).Text(ContentMessages.Message2);

        tableDescriptor.Cell().Text(ContentMessages.FromInitialField);
        tableDescriptor.Cell().ColumnSpan(1).Text(ContentMessages.FromFinalField);
        tableDescriptor.Cell().ColumnSpan(1).RowSpan(4).BorderLeft(1).Padding(5).Text(ContentMessages.ValidityMessage);

        tableDescriptor.Cell().PaddingBottom(10).Text(detail.FromInitial.ToShortDateString());
        tableDescriptor.Cell().ColumnSpan(1).PaddingBottom(10).Text(detail.ToInitial.ToShortDateString());

        tableDescriptor.Cell().Text(ContentMessages.ToInitialField);
        tableDescriptor.Cell().ColumnSpan(1).Text(ContentMessages.ToFinalField);

        tableDescriptor.Cell().PaddingBottom(3).Text(detail.FromFinal.ToShortDateString());
        tableDescriptor.Cell().ColumnSpan(1).PaddingBottom(10).Text(detail.ToFinal.ToShortDateString());
    }

    private void PolicyHolder(TableDescriptor tableDescriptor, string section)
    {
        tableDescriptor.Cell().ColumnSpan(3).BorderTop(1).PaddingTop(3).Element(StyleContent).Text(section);

        tableDescriptor.Cell().Text(ContentMessages.PlateField);
        tableDescriptor.Cell().ColumnSpan(2).Text(ContentMessages.FullNameField);

        tableDescriptor.Cell().PaddingBottom(10).Text(holder.Plate);
        tableDescriptor.Cell().ColumnSpan(2).PaddingBottom(10).Text(holder.FullName.ToUpper());

        tableDescriptor.Cell().Text(ContentMessages.CategoryField);
        tableDescriptor.Cell().ColumnSpan(2).Text(ContentMessages.PremiumField);

        tableDescriptor.Cell().PaddingBottom(10).Text(holder.Category);
        tableDescriptor.Cell().ColumnSpan(2).PaddingBottom(10).Text($"S/ {holder.Premium}");

        tableDescriptor.Cell().Text(ContentMessages.UseField);
        tableDescriptor.Cell().ColumnSpan(2).Text(ContentMessages.DateOfIssueField);

        tableDescriptor.Cell().PaddingBottom(10).Text(holder.Use);
        tableDescriptor.Cell().ColumnSpan(2).PaddingBottom(10).Text(holder.DateOfIssue.ToShortDateString());

        tableDescriptor.Cell().Text(ContentMessages.SeriesField);
        tableDescriptor.Cell().ColumnSpan(2).Text(ContentMessages.TimeOfIssueField);

        tableDescriptor.Cell().Text(holder.Series);
        tableDescriptor.Cell().ColumnSpan(2).Text(holder.TimeOfIssue.ToShortTimeString());
    }

    private static IContainer StyleHeader(IContainer container)
        => container.DefaultTextStyle(t => t.SemiBold()).PaddingVertical(5);

    private static IContainer StyleContent(IContainer container)
        => container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5);
}