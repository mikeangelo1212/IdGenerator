// See https://aka.ms/new-console-template for more information
using System.Net.ServerSentEvents;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using QuestPDF.Companion;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Application;

CreateId.Initialize();

QuestPDF.Fluent.Document document = CreateId.CreateDocument();

document.GeneratePdf("hello.pdf");

document.ShowInCompanion(12500);