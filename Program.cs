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
using System.Timers;

// CreateId.Initialize();

// QuestPDF.Fluent.Document document = CreateId.CreateDocument();

// document.GeneratgitePdf("hello.pdf");

// document.ShowInCompanion(12500);

const string CSV_PATH="src/csv";
const string IMAGE_PATH="src/img";

Console.WriteLine(Directory.Exists(CSV_PATH));
Console.WriteLine(Directory.Exists(IMAGE_PATH));
List<string>? imagesUrl= CreateId.SearchImages(IMAGE_PATH);

if(imagesUrl is null)
{
    Console.WriteLine("==========Image path non existent==========");
    Console.ReadKey();
    Environment.Exit(0);
}

// string[,] csvFull=CsvHandler.LoadCsv(CsvHandler.ListFiles("src/csv"));

// Console.WriteLine(csvFull.Length);
//el arreglo es [y,x]   [0,0],[0,1],[0,2],[0,3],[0,2],
//                      [1,0],[1,1],[1,2],[1,3],[1,4]
// GetLength(1, son las columnas)
// GetLength(0, son las filas)

// bool flag=true;
// int option;
// do
// {
//     Console.WriteLine("==========CSV Columns==========\n");
//     for (int i = 0; i < csvFull.GetLength(1); i++)
//     {
//         Console.WriteLine($"Column <{i}>: {csvFull[0,i]}");
//     }
//     try
//     {
//         Console.WriteLine("==========Select a column==========");
//         option = Convert.ToInt32(Console.ReadLine());
//     }
//     catch (Exception e)
//     {
//         Console.WriteLine($"==========Invalid Input==========\n{e}");
//         continue;
//     }
//     flag=false;
// }while (flag);


