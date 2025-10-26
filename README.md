# txt2anki
Convert colon separated terms/definitions to a text file importable by Anki<br>
<br>
To build, run
```
dotnet build txt2anki.csproj
```
The executable is located in
```
txt2anki\bin\Debug\net9.0
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
