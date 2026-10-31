# Winflux (beta)

![A screenshot of Winflux's About module.](.github/Winflux_AboutScr.png "Winflux")

Winflux is a personal tool to customize your Windows installation to the maximum, featuring tools to purge features and applications, activate your copy of Windows, a built-in recreation of NotMyFault, and more. It is currently in early stages.

## Features

- Activate Hidden Themes + Other Normally Inaccessible Customization Options
- Disable Advertising, Upselling, and Telemetry Features
- Manage or Disable Windows Update, Store, and Defender
- Enable Debugging Information and Tools (BSOD details, Windows 7 boot menu, etc.)
- PURGE Windows Features and Applications (Copilot / AI, Microsoft Edge, etc.)
- Check Windows activation status and *legally* activate your copy of Windows
- A reimplementation of NotMyFault, a tool to crash your system for testing purposes

and more coming soon.

## Installation

To run Winflux, you must have the .NET 6.0 runtime installed. You can download it from [Microsoft's official website](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).
Then, once you run Winflux, you will need to give Winflux administrative permissions to allow registry tweaks to take effect, amongst other features.

## Compiling

To compile Winflux, you will need the .NET 6.0 SDK installed. You can download it from [Microsoft's official website](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).
You can then clone the repository and build it using Visual Studio 2022 or later, or by using the `dotnet build` command in a terminal. Your terminal or Visual Studio must be running with administrative privileges, otherwise it will not build and you will be prompted to restart and run as an adminstrator.