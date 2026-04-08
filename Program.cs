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
using Application.Records;

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
    Console.ReadLine();
    Environment.Exit(0);
}
string? csvUrl=CsvHandler.ListFiles("src/csv");

if(csvUrl is null){
    Console.WriteLine("==========CSV path non existent==========");
    Console.ReadLine();
    Environment.Exit(0);
}

string[,] csvFull=CsvHandler.LoadCsv(csvUrl);

// Console.WriteLine(csvFull.Length);
// el arreglo es [y,x]   [0,0],[0,1],[0,2],[0,3],[0,2],
//                      [1,0],[1,1],[1,2],[1,3],[1,4]
// GetLength(1, son las columnas)
// GetLength(0, son las filas)

int csvOption;




        Console.WriteLine(
@"============================================================================
This template has three fields to fill, the csv must have at least two columns
(Full name and Role/Position) in order to work.
1.-Full name
2.-Role/Position
3.-Employee image
If the image url is not provided in the CSV. The program will look for the image file 
in the src/img folder which name isclosest to the full name and provide such image in the template
Please select the columns you want to use to fill these required fields.");


string[] templateFields=["Full name","Role/Position","Employee Image"];
List<int> columnOptions=new List<int>();
do
{
    if (columnOptions.Count >= 2&&!(columnOptions.Count==3))
    {       
        char charOption;
        
        do
        {
            Console.WriteLine("==========Do you have a csv column with image names?==========\n[y/N]?: ");
            try
            {   
                charOption = Console.ReadLine()![0];
            }
            catch (Exception e)
            {
                Console.WriteLine($"==========Invalid Input==========\n{e}");
                continue;
            }
            if (charOption == 'y' || charOption == 'Y')
            {
                Console.WriteLine("Fuck yes");
                break;
            }
            else if (charOption == 'n' || charOption == 'N')
            {
                columnOptions.Add(-1);
            }
            
        }while(columnOptions.Count<=2);
        
    }
    try
    {
        if (columnOptions.Count >= templateFields.Length)
        {
            break;
        }
        else
        {
            Console.WriteLine("==========CSV Columns==========\n");
            for (int i = 0; i < csvFull.GetLength(1); i++)
            {   
                string padding= (i+1)%3==0?"\n":"   ";
                Console.Write($"Column <{i}>: {csvFull[0,i]}{padding}");
            }
            Console.WriteLine($"==========Select a column for: {templateFields[columnOptions.Count]}==========");
            Console.WriteLine("");//extra line for formatting
            csvOption = Math.Abs(Convert.ToInt32(Console.ReadLine()));//Math.Abs to always have a positive
            
        }
        
    }
    catch (Exception e)
    {
        Console.WriteLine($"==========Invalid Input==========\n{e}");
        continue;
    }
    if (csvOption >= csvFull.GetLength(1))
    {
        Console.WriteLine("==========Out of range input==========");
    }
    else
    {
        columnOptions.Add(csvOption);    
    }
    
    Console.WriteLine($"Length of options now:  {columnOptions.Count}");


}while (true);

if (columnOptions.Contains(-1))
{
    Console.WriteLine("buscamos en folder");
}
else
{
    Console.WriteLine("columna con archivo");
}
List<TemplateInfo> _templateInfo=[];

for (int y = 0; y < csvFull.GetLength(0); y++)
{
    _templateInfo.Add(new TemplateInfo(
        new string(IMAGE_PATH+csvFull[y,columnOptions[0]]+csvFull[y,columnOptions[1]]);
        csvFull[y,columnOptions[0]],
        csvFull[y,columnOptions[1]],
        columnOptions[2]==-1?
            LevenshteinDistance.Compute(new string(IMAGE_PATH+csvFull[y,columnOptions[0]]+csvFull[y,columnOptions[1]]),"")
            :
            csvFull[y,columnOptions[2]]
        //if we have -1, it means we searching the folder for images close to the name
        //we are gonna search for an image url with no spaces, trimmed. And compare that
        //trim(folderURL+firstname+lastname) and compare it with the contents of imagesUrl

        //So we are gonna ask this shit, throughout the whole array in a custom function that receives two parameters
        // LevenshteinDistance.Compute(new string(IMAGE_PATH+csvFull[y,columnOptions[0]]+csvFull[y,columnOptions[1]]),"")
        //The values go in and consume said Levenshtein method, and then stores the results in an array, then we pick the 
        // one with the highest score and choose that to put into the record's field, if we don't find shit then we return null or something i dunno
        //This method gives us in base to 1, how siimilar are the two values,1 being identical
        // static double Similarity(string s, string t)
        // {
        //     int distance = LevenshteinDistance.Compute(s, t);
        //     int maxLength = Math.Max(s.Length, t.Length);
            
        //     if (maxLength == 0) return 1.0; // both empty

        //     return 1.0 - (double)distance / maxLength;
        // }
    ));
}//add iteration on folder and iteration on csv readout

foreach (var item in _templateInfo)
{
    System.Console.WriteLine(item.FullName);
}

Console.WriteLine("SE cayo el sistema");
Console.WriteLine(columnOptions);
Console.ReadLine();


