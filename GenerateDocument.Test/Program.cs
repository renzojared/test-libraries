using GenerateDocument.Sample.Documents;
using GenerateDocument.Sample.Fakes;
using GenerateDocument.Soat.Documents;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

QuestPDF.Settings.License = LicenseType.Community;

var detail = new PolicyDetail(
    "S0000012",
    new DateOnly(2024, 1, 1),
    new DateOnly(2024, 1, 1),
    new DateOnly(2024, 1, 1),
    new DateOnly(2024, 1, 1));

var holder = new PolicyHolder(
    "ABC123",
    "SUV",
    "PARTICULAR",
    "1312312321",
    "Kaniel Kerdi",
    12.1m,
    new DateOnly(2024, 1, 1),
    new TimeOnly(16, 15));

var document = new SoatDigital(detail, holder);
document.GeneratePdf(SaveWithName("SoatDigital"));

//Invoice section
var invoice = FakeInvoiceDocument.GetInvoiceDetails();

var docInvoice = new InvoiceDocument(invoice);
docInvoice.GeneratePdf(SaveWithName("Invoice"));
return;

string SaveWithName(string fileName) => $"/Users/renzojared/Downloads/{fileName}.pdf";