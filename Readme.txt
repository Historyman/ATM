App is built on .NET Core and requires the .NET Core SDK Found here: https://www.microsoft.com/net/download/core

To create a published release version go to .\ATM and type the following command:
dotnet publish -c Release

You can run the published program by going to .\ATM\bin\Release\publish\netcoreapp1.1 and typing the following commmand:
dotnet ATM.dll

If you want to build a self-contained .exe please open a command line in the ATM folder and type the following based on your windows version.

Windows 10 64bit:
dotnet publish -c Release -r win10-x64

Windows 10 32bit:
dotnet publish -c Release -r win10-x86

Windows 7 64bit:
dotnet publish -c Release -r win7-x64

Windows 7 32bit:
dotnet publish -c Release -r win7-x86

.exe will be in a designated folder in the .\ATM\bin\Release\netcoreapp1.1  directory
