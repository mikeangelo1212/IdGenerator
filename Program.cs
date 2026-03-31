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
using System;
using System.IO;
using System.Collections;

// CreateId.Initialize();

// QuestPDF.Fluent.Document document = CreateId.CreateDocument();

// document.GeneratgitePdf("hello.pdf");

// document.ShowInCompanion(12500);

const string PATH="src/csv";

Console.WriteLine(Directory.Exists(PATH));
Console.WriteLine($"Respuesta del metodo handler: {CsvHandler.ListFiles("src/csv")}");

