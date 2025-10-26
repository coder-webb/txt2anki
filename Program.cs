using System;
using System.IO;

switch (args.Length)
{
    case 1:
        if (args[0].Equals("-h") || args[0].Equals("--help"))
        {
            Console.WriteLine();
            Console.WriteLine("TXT2ANKI minimum in .txt layout requirements:");
            Console.WriteLine("\tyou don't need separate files for notes and terms/definitions");
            Console.WriteLine("\tterms and definitions should be separated by a colon");
            Console.WriteLine("\ta term and definition should be on one line e.g.");
            Console.WriteLine("\tterm:defintion");
            Console.WriteLine("\teach term and definition combo should be on separate lines");
            Console.WriteLine("\tlines without a colon are ignored, lines with a colon will be added to the out .txt file.");
            Console.WriteLine("\tthe first colon indiciates the end of a term and the remainder of the line will be part of the definition");
            Console.WriteLine("\tafter running this program, you can import the newly created text file into Anki and it should just work");
            Console.WriteLine();
            Environment.Exit(0);
            break;
        }
        goto default;
    default:
        Console.WriteLine();
        Console.WriteLine("Use -h or --help");
        Console.WriteLine("or");
        Console.WriteLine("<in .txt> <out .txt>");
        Console.WriteLine();
        Environment.Exit(0);
        break;
}

string inTxt = args[0];
string outTxt = args[1];

StreamReader inTxtReader = new StreamReader(inTxt);
StreamWriter outTxtWriter = new StreamWriter(outTxt);

string inTxtLine = inTxtReader.ReadLine();
string term;
string definition;

while (!inTxtReader.EndOfStream)
{
    if (inTxtLine.IndexOf(":") < 0)
    {
        inTxtLine = inTxtReader.ReadLine();
        continue;
    }
    term = inTxtLine.Substring(0, inTxtLine.IndexOf(":"));
    definition = inTxtLine.Substring(inTxtLine.IndexOf(":") + 1);
    outTxtWriter.WriteLine("\"" + term + "\";" + "\"" + definition + "\";");
    inTxtLine = inTxtReader.ReadLine();
}

inTxtReader.Close();
outTxtWriter.Close();
Environment.Exit(0);
