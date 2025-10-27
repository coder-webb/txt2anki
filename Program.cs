using System;
using System.IO;

Console.WriteLine(args[0]);
Console.WriteLine(args[1]);
if (args.Length > 2)
{
  Console.WriteLine(args[2]);
}
Console.WriteLine(args.Length);
switch (args.Length)
{
    case 2:
      if (args[1].Equals("-h") || args[1].Equals("--help"))
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
          Environment.Exit(1);
          break;
        }
      goto case 1;
    case 1:
      Console.WriteLine();
      Console.WriteLine("Use -h or --help");
      Console.WriteLine("or");
      Console.WriteLine("<in .txt> <out .txt>");
      Console.WriteLine();
      Environment.Exit(1);
      break;
    default:
      break;
}

string inTxt = args[1];
string outTxt = args[2];

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
