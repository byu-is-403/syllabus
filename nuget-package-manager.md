# NuGet Package Manager

## Contents

- What is NuGet
- Manage NuGet Packages Dialog
- Package Manager Console


### What is NuGet

- NuGet is the package manager (i.e. libraries) for the Microsoft development platform .NET
- It is a repository for developers to upload and download software that can be used within their .NET applications
- As of the beginning of this course (August 18, 2015) there are almost 41,000 packages that can be downloaded and installed to save you time and effort in getting your job done
- When you add a package to your .NET environment, all dependent packages are also installed
- When you update a package, NuGet makes sure that all dependent packages are also updated
- There are 2 ways to access NuGet within the .NET environment
  - Manage NuGet Packages Dialog
  - Package Manager Console
- Although not included in this course, it is good to know that you have the ability to create your own packages to share software with other developers


### Manage NuGet Packages Dialog

- Manage NuGet Packages Dialog is accessed by right clicking the References node in the solution Explorer and choosing Manage NuGet Packages
- The Manage NuGet Packages dialog window allows you to see all packages currently installed and allow you to search for software available to download and incorporate into your application
- http://nugetmusthaves.com/Category/MVC shows the "must haves" for MVC that you can download and install (i.e. Elmah is a global error handler that logs all errors)
- The Manage NuGet Packages dialog also helps you keep packages updated
- The Settings button allows you to configure how you want NuGet to run (i.e. automatically check for and download missing packages)
- As you click on each available package, NuGet will display information such as package dependencies, version, description, etc.


### Package Manager Console

- The Package Manager Console provides a shell based console window to install and maintain packages and provides a little more control over the NuGet options
- You can run the console by choosing Tools | Library Package Manager | Package Manager Console (NOTE: the console window will be displayed)
- In the console window you have the ability to run actions (i.e. get-package, install-package, etc.)
- If you would like to use the console rather than the dialog you can review the commands at this link https://docs.nuget.org/consume/package-manager-console and also at https://nuget.codeplex.com/wikipage?title=Package%20Manager%20Console%20Command%20Reference%20(v1.3) 



