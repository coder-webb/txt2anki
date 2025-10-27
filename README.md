# txt2anki
<h3>Convert colon separated terms/definitions to a text file importable by Anki</h3><br>

Requirements<br>
```
.NET SDK 9.0
https://dotnet.microsoft.com/en-us/download/dotnet/9.0
```

To run
```
dotnet run Program.cs "in .txt" "out .txt"
```

Tip: You don't need separate files for your notes and terms/definitions (see Example Files)<br>
<br>
Input text file requirements:
<ul>
  <li>lines without a colon are ignored, lines with a colon will be added to the out .txt file.</li>
  <li>the first colon indiciates the end of a term and the remainder of the line will be part of the definition</li>
  <li>a term and definition should be on one line</li>
  <li>terms and definitions should be separated by a colon</li>
</ul>
<br>
After running this program, you can import the newly created text file into Anki and it should just work.
