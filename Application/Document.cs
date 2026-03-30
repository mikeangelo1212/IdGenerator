using QuestPDF.Companion;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;


namespace Application;

public static class CreateId
{
    public static void Initialize(){        
        QuestPDF.Settings.License = LicenseType.Community;
        QuestPDF.Settings.EnableCaching = true;
    }

    public static Document CreateDocument()
    {
        return Document.Create(container =>
        {   
            PageSize _pageSize=new PageSize(5.5f, 8.5f, Unit.Centimetre);
            
            for (int i = 0; i < 2; i++)
            {
                
            }
            
            container.Page(page =>
            {   
                page.Size(_pageSize);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(20));
                
                page.Content()
                    .Width(_pageSize.Width)
                    .Height(_pageSize.Height)
                    .Padding(0)
                    .Layers(x =>
                    {   
                        x.Layer().Image("src/img/plantilla.png").FitUnproportionally();
                        x.PrimaryLayer().Column(column =>
                        {
                            column.Item().Height(_pageSize.Height/6);
                            column.Item()
                                .Height(_pageSize.Height/2)
                                .ExtendHorizontal()
                                .AlignMiddle()
                                .AlignCenter()
                                .Image("src/img/plantilla.png").FitArea();
                            column.Item()
                            .Shadow(new BoxShadowStyle
                            {
                                Color = Colors.White,
                                Blur = 12,
                                Spread = 6
                            })
                            .Column(y =>
                            {
                                y.Item()
                                    .ExtendHorizontal()
                                    .Text("Alfredo Jimenez").Bold()
                                    .AlignCenter()
                                    .FontSize(18);
                                y.Item()
                                    .ExtendHorizontal()
                                    .Text("subrol")
                                    .AlignCenter()
                                    .FontSize(12);
                            });
                        });
                    });      
            });
            
            
        });

        xd.GeneratePdf();
    }
    
}