using System.Security.Cryptography.X509Certificates;
using QuestPDF.Companion;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;


namespace Application;

public static class CsvHandler
{
    public static string ListFiles(string path)
    {
        string [] files= Directory.GetFiles(path);
        bool flag = true;
        int option=0;
        
        while (flag)
        {
            Console.WriteLine($"==========Files in directory==========");
            for (int i = 0; i < files.Length; i++)
            {
                char[] fileAux=files[i].ToCharArray();
                for (int j = 0; j < fileAux.Length; j++)
                {
                    if (fileAux[j] == '\\')
                    {
                        fileAux[j] = '/';
                    }
                }
                files[i]=new string(fileAux);
                Console.WriteLine($"{i}.- {files[i]}");
            }
            
            try
            {
                Console.WriteLine("==========Please select a file==========");
                option = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("==========Invalid Input==========");
                continue;
            }

            if (option > files.Length)
            {
                Console.WriteLine("==========Option out of range==========");
            }
            else
            {
                Console.WriteLine($"File is found by FileExists?: {File.Exists(files[option])}");
                Console.WriteLine($"{files[option]} selected");
                flag=false;

            }
        }
        return files[option];
    }

    // http://csharphelper.com/howtos/howto_read_csv_file.html
    // Load a CSV file into an array of rows and columns.
    // Assume there may be blank lines but every line has
    // the same number of fields.
    public static string[,] LoadCsv(string filename)
    {
        // Get the file's text.
        string whole_file = File.ReadAllText(filename);

        // Split into lines.
        whole_file = whole_file.Replace('\n', '\r');
        string[] lines = whole_file.Split(new char[] { '\r' },
            StringSplitOptions.RemoveEmptyEntries);

        // See how many rows and columns there are.
        int num_rows = lines.Length;
        int num_cols = lines[0].Split(',').Length;

        // Allocate the data array.
        string[,] values = new string[num_rows, num_cols];

        // Load the array.
        for (int r = 0; r < num_rows; r++)
        {
            string[] line_r = lines[r].Split(',');
            for (int c = 0; c < num_cols; c++)
            {
                values[r, c] = line_r[c];
            }
        }

        // Return the values.
        return values;
    }
    
}