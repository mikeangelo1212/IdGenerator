// See https://aka.ms/new-console-template for more information
using System.Net.ServerSentEvents;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using QuestPDF.Companion;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Application;
using Microsoft.VisualBasic.FileIO;

// CreateId.Initialize();

// QuestPDF.Fluent.Document document = CreateId.CreateDocument();

// document.GeneratePdf("hello.pdf");

// document.ShowInCompanion(12500);

string basePath = AppContext.BaseDirectory;
string filePath = Path.Combine(basePath, "src", "csv", "test.csv");

using (TextFieldParser parser = new TextFieldParser(filePath))

{
    parser.TextFieldType = FieldType.Delimited;
    parser.SetDelimiters(",");
    while (!parser.EndOfData) 
    {
        //Processing row
        string[] fields = parser.ReadFields()!;
        foreach (string field in fields) 
        {
            Console.WriteLine(field);
        }
    }
}