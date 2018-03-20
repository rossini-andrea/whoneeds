# whoneeds - A different kind of dependency inspector

`whoneeds.exe` is a command line utility to report dependants on a .Net library.
The main difference is in the approach, rather than opening an assembly and
reporting all its dependencies, it scans all the assemblies in a folder printing
all those depending upon a specified input pattern.

This small utility saved my life in a non trivial refactoring job, and I am sharing
it in the hope it will be useful.

## Compiling

Build the `whoneeds` project and copy the output `whoneeds.exe` to your favourite
command line tools folder.

## Usage

Enter a folder with .Net assemblies and invoke the command like this:

```
C:\Windows\Microsoft.NET\Framework\v2.0.50727>whoneeds forms
aspnet_regsql => System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
Microsoft.Build.Tasks => System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
Microsoft.Build.VisualJSharp => System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
Microsoft.VisualBasic.Compatibility.Data => System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
Microsoft.VisualBasic.Compatibility => System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
Microsoft.VisualBasic => System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
System.Configuration.Install => System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
System.Deployment => System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
System.Design => System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
System.Drawing.Design => System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
System.Messaging => System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
System.ServiceProcess => System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
System.Web => System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
System.Web.Mobile => System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089

```

You can also use a **RegExp**:

```C:\Windows\Microsoft.NET\Framework\v4.0.30319>whoneeds ^system.xml$
caspol => System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
ComSvcConfig => System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
DataSvcUtil => System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
EdmGen => System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
Microsoft.Build.Conversion.v4.0 => System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
Microsoft.Build => System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
Microsoft.Build.Engine => System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
Microsoft.Build.Tasks.v4.0 => System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
Microsoft.Build.Utilities.v4.0 => System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
^C

```

## References

* [.Net Regular Expressions Quick Reference](https://docs.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference)
