// See https://aka.ms/new-console-template for more information
using System.Net.ServerSentEvents;
using System.Security.Cryptography.X509Certificates;
using QuestPDF.Companion;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

QuestPDF.Settings.License = LicenseType.Community;
QuestPDF.Settings.EnableCaching = true;

var document = Document.Create(container =>
{   
    PageSize _pageSize=PageSizes.Letter;
    container.Page(page =>
    {   
        page.Size(_pageSize);
        // page.Margin(2, Unit.Centimetre);
        page.PageColor(Colors.White);
        page.DefaultTextStyle(x => x.FontSize(20));
        
        // page.Header()
        //     .Text("hola")
        //     .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);
        
        page.Content()
            .Width(_pageSize.Width)
            .Height(_pageSize.Height)
            .Padding(0)
            .Layers(x =>
            {   
                x.Layer().Image("src/img/plantilla.png").FitUnproportionally();
                x.PrimaryLayer().Column(column =>
                {
                    column.Spacing(20);
                    column.Item().Text(Placeholders.LoremIpsum());
                    column.Item().Image(Placeholders.Image(200, 100));
                });
            });
                
        
        // page.Footer()
        //     .AlignCenter()
        //     .Text(x =>
        //     {
        //         x.Span("Page ");
        //         x.CurrentPageNumber();
        //     });
    });
});

document.GeneratePdf("hello.pdf");

document.ShowInCompanion(12500);