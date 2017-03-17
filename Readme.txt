App is built on .NET Core and requires the .NET Core SDK Found here: https://www.microsoft.com/net/download/core
If you want to run a published .exe please open a command line in the ATM folder and type the following based on your windows version

Windows 10 64bit:
dotnet publish -c Release -r win10-x64

Windows 10 32bit:
dotnet publish -c Release -r win10-x86

Windows 7 64bit:
dotnet publish -c Release -r win7-x64

Windows 7 32bit:
dotnet publish -c Release -r win7-x86