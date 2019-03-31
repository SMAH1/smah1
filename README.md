# SMAH1 Library
Multi-libraries that have been implemented or have been collected over the years

## overview
Multi library for use:

* SMAH1.Core: Main classes that are most used
* SMAH1.Log:‌ Related classes for having a logger
* SMAH1.Forms: Implement the necessary controls and classes in the WinForm
* SMAH1.Forms.Chart:‌ A simple chart
* SMAH1.Windows: Popup work only in windows.See project information for on [CodeProject](https://www.codeproject.com/Articles/17502/Simple-Popup-Control).
* SMAH1.Forms.Windows: Implement the necessary controls and classes in a WinForm that works only on Windows

And a sample project called HowToWork

## License
SMAH1.Windows library license is The GNU Lesser General Public License (LGPLv3).
Other libraries license are MIT.

## Detail of libraries

SMAH1.Core

```text
Attributes
  DescriptionsAttribute
Collections
  GenericCollection
  IEnumCount
  List
Export
  CsvExport
  CsvExportDelimiter
  ExportProgressEventArgs
ExtensionMethod
  DateTime
  MD5
  Number
  Graphics
ExtensionMethod.Persian
  FarsiDigit
  IranNationCode
  PersianKeyLayout
Persian
  Date
Serialize
  XmlColor
  XmlFontSerializationHelper
Wildcard
Zip
CreateWhere
EnumInfoBase
GrowableStore
RunningEnvironment
```

SMAH1.Log

```text
Log.Media
  FileLog
  SystemEventLog
Log
  Format
  IMedia
  Item
  Items
  Logger
  PriorityLog
  SegmentItem
Log.Persian
  SegmentItem
```

SMAH1.Forms

```text
Attributes
  MaxMinForFloatAttribute
  MaxMinForIntAttribute
  NotBrowsableIfAttribute
Export
  ExportDataForm
Export.Component
  BaseExportComponentFrom
  CsvExportFrom
ExtensionMethod
  Control
  SelectTextIfFocus
Print
  PrintToGraphics
  SimplePrinterBitmap
SingleLineText
Clock
  ClockTextBox
  MeeGoClock
Clickable
  ButtonDirection
  CheckBox3State
  CheckedListBox
  RadioButtonImage
  SplitButton
DataGridViewComponent
  DataGridViewNumTextBoxColumn
  DataGridViewProgressColumn
  DataGridViewRowNumberColumn
Loading control
PropertyGridComponent
    ColorArrayEditor
    NumericFloatUpDownEditor
PropertyGridEx with support add images into header
Text
    LargeTextViewer
    SmartTextBox
    TextBoxNumeric
Text.Persian
  TextBoxPersianDate
Wait
  WaitPleaseForm
  WaitProgressForm
```

SMAH1.Forms.Chart

```text
BarChart
LineChart
Save/Load Chart configuration

```

SMAH1.Forms.Windows

```text
PersianDate
```

You can run the `HowToWork` application in the project to see features.

## .NET support

SMAH1.Core & SMAH1.Log: .NET40, .NET45, Core2.1  
SMAH1.Forms & SMAH1.Forms.Chart: .NET40, .NET45, Run in Mono  
SMAH1.Windows & SMAH1.Forms.Windows:  .NET40, .NET45, Only work in windows  
Convert to .NET 2 & .NET 3.5 with a little coding  

## How to compile

In Windows:

```text
Open SMAH1-All.sln in Visual Studio
```

In Linux (for .NET Core):

```cmd
dotnet build SMAH1-Basic.sln  --framework netcoreapp2.1
```

## Notes

* These codes are the result of my over 10 years of programming and one of my friends
* No code-style has been respected
* Most classes do not have unit-test
* There are definitely classes that can be improved
* There may be a lot of programming principles (especially older ones)
* This library was created by reviewing it in older library
* Waiting for your pull-request

## Release

Available in `nuget`.  

[SMAH1.Core](https://www.nuget.org/packages/SMAH1.Core)  
[SMAH1.Log](https://www.nuget.org/packages/SMAH1.Log)  
[SMAH1.Forms](https://www.nuget.org/packages/SMAH1.Forms)  
[SMAH1.Forms.Chart](https://www.nuget.org/packages/SMAH1.Forms.Chart)  
[SMAH1.Windows](https://www.nuget.org/packages/SMAH1.Windows)  
[SMAH1.Forms.Windows](https://www.nuget.org/packages/SMAH1.Forms.Windows)  

Install by `Package Manager`:

```text
Install-Package SMAH1.Core
Install-Package SMAH1.Log
Install-Package SMAH1.Forms
Install-Package SMAH1.Forms.Chart
Install-Package SMAH1.Windows
Install-Package SMAH1.Forms.Windows
```

And install by `.NET CLI`:

```text
dotnet add package SMAH1.Core
dotnet add package SMAH1.Log
dotnet add package SMAH1.Forms
dotnet add package SMAH1.Forms.Chart
dotnet add package SMAH1.Windows
dotnet add package SMAH1.Forms.Windows
```

Also get release and sample: [Releases Page](https://github.com/SMAH1/smah1/releases)
