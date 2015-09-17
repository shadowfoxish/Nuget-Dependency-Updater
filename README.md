# Nuget-Dependency-Updater
Licensed under GNU v3
Windows Binaries are available at http://www.shadowfox.xyz/NDU/NugetDependencyUpdater-1.0.0.0.7z

## What is Nuget Dependency Updater?
If you work across multiple .NET projects where some of those projects create Nuget packages your other projects depend on, this utility can ease the copy&paste work of getting updated assemblies from project to project, before you commit, build, and then update your nuget packages.

## Configuring
To configure NDU, click on the tools icon in the bottom left and then click 'Edit Configuration...'

1) Next, click the Items option and to the right, click on the [...] box. (Yay property grid!)

You will need to add at least 2 configurations here to use NDU. 
2) First, add a new Component. A component represents a project that normally generates a nuget package other projects reference. Click 'Add', then click the new item in the list and fill in the options: 
* ContainerKind: Choose component. 
* Name : Will display as a button on the main form, sorted into the 'Component' list.
* Path: Specify the full path to the bin directory you want to copy assemblies and other files from.
* FileGlobs: Click the value to edit, use the form to select individual files. Windows path wildcard (*) is allowed. (This isn't really a Linuxy Glob expression, I just liked the name)
* PackageExpression: Set package expression to a regular expression that would match the nuget package name in the destination project's packages folder. Here's an example: "^MyCompany\.PrimaryService\.[0-9]+\.[0-9]+\.[0-9]+\.[0-9]+$". This regex would match a package folder like MyCompany.PrimaryService.1.0.5.0
* RelativePackagePath: Enter the relative path from the folder into which assemblies should be copied. This should match the location where items are stored when the nuget package is created. Usually something like "lib\net451"

3) Click save.
4) Now add your Project. A project is a destination that has a dependency on a component via nuget. Click Add again, then click the new item in the list and fill in the options:
* ContainerKind: Choose project. 
* Name: Will display as a button on the main form, sorted into the 'Project' list.
* Path: Specify the full path to the packages folder of your project. This is usually found at the root where the solution file is stored. Something like "C:\Code\My.Dependent.Project\packages"
5) Click save, and close out the tool windows.

Configuration is saved on your hard drive at "C:\Users\<user>\AppData\Local\DependencyUpdater" and retrieved each time the program starts.

## Usage
Once your configuration is saved, you should see two columns, Components (sources) and Projects (destinations).
Click one component and one project in the lists and then click the Copy button. The status label at the bottom will change letting you know the files were copied.

Your Visual Studio proj file may need to be updated to allow the version of the DLL you just copied to be referenced. Find the DLL in the References folder of your project and in the properties (F4) choose "Specific Version = False". When you update the Nuget package later after you've checked in your changes, Nuget will automatically switch this back to True.

If you found this program useful or would like to request a feature or report a bug, please leave a comment!
