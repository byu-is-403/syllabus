# NuGet Package Manager

## Contents

- [What is NuGet](#what-is-nuget)
- [Manage NuGet Packages Dialog](#manage-nuget-packages-dialog)
- [Package Manager Console](#package-manager-console)


### What is NuGet?

[NuGet](https://github.com/nuget/home) is the package manager (i.e. libraries) for Microsofts .NET development platform. It serves as a repository for developers to upload and download software that can be used within their .NET applications. As of August 18, 2015, there are almost 41,000 packages that can be downloaded and installed to save you time and effort in getting you job done.

When you add a package to your .NET environment, its dependencies are also installed. When a package is updated, its dependencies are also updated. NuGet helps with many small management tasks like these.

There are 2 ways to access NuGet within the .Net environment: the `Manage NuGet Packages` dialog and the package manager console.

Although not included in this course, it is good to know that _you_ have the ability to create your own packages to share software with other developers. If you're interested in learning more about participating in the community, go to the [NuGet GitHub repository](https://github.com/nuget/home) or check out some open source NuGet packages like the [MongoDB C# Driver](https://github.com/mongodb/mongo-csharp-driver) or the [PayPal Merchant SDK](https://github.com/paypal/merchant-sdk-dotnet).


### Manage NuGet Packages Dialog

The `Manage NuGet Packages` dialog is accessed by right-clicking the References node in the solution explorer and choosing `Manage NuGet Packages`. This dialog window allows you to see all packages currently installed and search for software available to download and incorporate into your application. The `Manage NuGet Packages` dialog also helps you keep packages updated.

The settings button allows you to configure how you want NuGet to run; i.e. automatically check for and download missing packages. As you click on each available package, NuGet will display information such as package dependencies, version, description, and more.

[http://nugetmusthaves.com/Category/MVC](NuGetMustHaves.com) shows the "must haves" for MVC that you can download and install.


### Package Manager Console

The Package Manager Console provides a shell based console window to install and maintain packages and provides a little more control over the NuGet options. You can run the console by navigating to `Tools > Library Package Manager > Package Manager Console` _(NOTE: the console window will be displayed)_. In the console window you have the ability to run actions (i.e. get-package, install-package, etc.).

If you would like to use the console rather than the dialog you can review the commands in the [NuGet package manager console documentation](https://docs.nuget.org/consume/package-manager-console) or on their [GitHub](https://github.com/nuget/home)
