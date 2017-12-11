# Security


## Contents

- Authentication
- Authorization
- OpenID
- OAuth
- ASP.NET MVC 5 Security


### Authentication

- Authentication is when an application needs to know the identity of the current user and is the process of verifying who you are.


### Authorization

- Authorization is when an application needs to know the identity of the current user. It is the process of verifying that you have access to something. 


### OpenID Connection

- The ASP.NET MVC template with Individual User Accounts authentication includes the AccountController that implements authentication both for OpenID and OAuth
- Allows computing clients to verify the identity of an end-user based on the authentication performed by an authorization serversing accounts they already have. The term federated is critical here because the whole point of OpenID is that any provider can be used (with the exception of white-lists). You don't need to pre-choose or negotiate a deal with the providers to allow users to use any other account they have.OAuth could be used in external partner sites to allow access to protected data without them having to re-authenticate a user
- OpenID is about authentication (ie. proving who you are), OAuth is about authorization (ie. to grant access to functionality/data/etc.. without having to deal with the original authentication).
- 

### OAuth

- OAuth was created to remove the need for users to share their passwords with third-party applications. It actually started as a way to solve an OpenID problem: if you support OpenID on your site, you can't use HTTP Basic credentials (username and password) to provide an API because the users don't have a password on your site.
- OpenID is limited to the 'this is who I am' assertion, while OAuth provides an 'access token' that can be exchanged for any supported assertion via an API
- Oauth (Open Authentication) is used for delegated authorization only -- meaning you are authorizing a third-party service access to use personal data, without giving out a password. 


### ASP.NET MVC 5 Security

- We are seeing more processing happening on the client side.
- In Visual Studio Community 2017, much of the security can be handled by something call ASP.NET Identity
- Much of this is implemented through OWIN (Open Web Interface for .NET)
- OWIN is the interface between the .NET application and the .NET web server
- OWIN authentication middleware replaces the Forms Authentication module
- OWIN authentication middleware issues authentication cookies or uses external logins like facebook, google, twitter etc...
- In order to use OWIN you must install Microsoft.AspNet.Identity.OWIN via the NuGet package manager
- Choose Tools, NuGet Package Manager, Package Manager Console
- Type in Install-Package Microsoft.aspnet.identity.owin and press Enter (OWIN authentication middleware)
- You need one more reference so Type in Install-Package Microsoft.Owin.Host.systemWeb (handles OWIN requests)
- Look at the references for the project and notice the Microsoft.aspnet.identity.owin and the other OWIN libraries included
- Create a new ASP.NET MVC Framework web application and change the Authentication to Individual User Accounts (look at references)


### Claims Based Identity

- Identity is "who is the user and what are they?"
- Identity does not have to be issued by your own application. You can use a 3rd party such as Facebook or Google
- Identity is used to authenticate
- Claims are how you represent identity data within the application and represents a single piece of information about the user (i.e. first name)
- The claims are issued by an identity provider (your own app or a 3rd party like Google) you trust
- Identity is used in the Identity management (process of identifying a user), Authentication (who are you) uses the Identity management, and Authorization (what is the user able to do)


### ASP.NET Identity

- The storage and management of the identities of users
- Often called an Identity Store (or user store)
- Database that is only concerned with identities (you only store user info in this database, nothing else!)
- Benefits include: Password Hashing, User Lockout (stops brute force attacks), Two Factor Authentication (user more than user name and password), External Logins, Tokenization (create and use tokens to confirm users)
- Why re-invent the wheel when it is already created and proven secure?


### Create user, assign a claim and verify user credentials

- Create a new Visual Studio C# CONSOLE application and provide a name
- Go to the NuGet Package manager console and type:
- install-package Microsoft.AspNet.Identity.Core (Asp.net identity library)
- install-package Microsoft.AspNet.Identity.Framework (logic to interact with the database and the default schema DefaultConnection)
- Modify the App.config (since this is a console app) - DefaultConnection is reserved and automatically used

```asp.net
  <connectionStrings>
    <add name="DefaultConnection" connectionString="Data Source=OWNER-HP;Initial Catalog=Attendance;Integrated Security=True;Pooling=False" providerName="System.Data.SqlClient" />
  </connectionStrings>
 ```

- Main class of identity is the UserManager class
- The UserStore class is used to link to the UserManager object and represents the DefaultConnection database

```csharp
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            //A user store will point to the storage database
            //The user manager links to the user store
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            //If the database identified in the App.config does not exist then
            //it will be created by ASP.NET
            //If the user does not exist then the record will be created for the user
            //Look at the database Attendance
            //Look at the tables and open the AspNetUsers
            var creationResult = userManager.Create(new IdentityUser("profganderson"), "MyPassword123!");
            Console.WriteLine("Created: " + creationResult.Succeeded);
            Console.ReadKey();
        }
 ```

- The FindByName for the UserManager class allows you to search the UserStore for a specific UserName
- The AddClaim in the UserManager class adds a new identity claim in the AspNetUserClaims table. You can specify ClaimType and ClaimValue (like a dictionary)

```csharp
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            //A user store will point to the storage database
            //The user manager links to the user store
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            //If the database identified in the App.config does not exist then
            //it will be created by ASP.NET
            //If the user does not exist then the record will be created for the user
            //Look at the database Attendance
            //Look at the tables and open the AspNetUsers
            var creationResult = userManager.Create(new IdentityUser("profganderson"), "MyPassword123!");
            Console.WriteLine("Database Created: " + creationResult.Succeeded);
            Console.ReadKey();

            var userName = "profganderson";
            var userPassword = "MyPassword123!";

            var encryptedUser = userManager.FindByName(userName);
            creationResult = userManager.AddClaim(encryptedUser.Id, new Claim("given_name", "Greg"));
            Console.WriteLine("Claim Created: " + creationResult.Succeeded);
            Console.ReadKey();

        }
    }
}            
```

- Confirm the user identity and the password by using the CheckPassword method in the User Manager class
- Notice the PasswordHash table in the AspNetUsers table

```csharp
            //A user store will point to the storage database
            //The user manager links to the user store
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            //If the database identified in the App.config does not exist then
            //it will be created by ASP.NET
            //If the user does not exist then the record will be created for the user
            //Look at the database Attendance
            //Look at the tables and open the AspNetUsers
            var creationResult = userManager.Create(new IdentityUser("profganderson"), "MyPassword123!");
            Console.WriteLine("Database and User Created: " + creationResult.Succeeded);
            Console.ReadKey();

            var userName = "profganderson";
            var userPassword = "MyPassword123!";

            //The FindByName for the UserManager class allows you to search the UserStore for a specific UserName
            //he AddClaim in the UserManager class adds a new identity claim in the AspNetUserClaims table.You can specify ClaimType and ClaimValue(like a dictionary)

            var encryptedUser = userManager.FindByName(userName);
            creationResult = userManager.AddClaim(encryptedUser.Id, new Claim("given_name", "Greg"));
            Console.WriteLine("Claim Created: " + creationResult.Succeeded);
            Console.ReadKey();

            //The CheckPassword uses the encryption for the PasswordHash field in the AspNetUsers table 
            var isFound = userManager.CheckPassword(encryptedUser, userPassword);
            Console.WriteLine("Password Correct? " + isFound.ToString());
            Console.ReadKey();
```

- In summary, the User Store interacts with the database and the User Manager interacts with the User Store
- The UserManager class also provides the interface to work with the user Identity
- NOTE: SecurityStamp	A GUID automatically created at specific points in the UserManager object lifetime. Typically, it’s created and updated when the password changes or a social login is added or removed. The security stamp generally takes a user information snapshot and automatically logs in users if nothing has changed.

### Roles

- A role is just what a user can do
- You can either add a claim to handle the roles or you can use the RoleManager class
- Add the following records to the AspNetRoles table:
- ID: CLK and Name: CLERK
- ID: MGR and Name: MANAGER
- NOTE: User the encryptedUser.Id variable found by the userManager.FindByName(userName) for the role methods

```csharp
  var addRole = userManager.AddToRole(encryptedUser.Id, "MANAGER");

  bool hasRoles = false;

  try
  {
      hasRoles = userManager.IsInRole(encryptedUser.Id, "MANAGER");                
  }
  catch
  {
      Console.WriteLine(userName + " has no roles");
  }

  if (hasRoles)
  {
      var userRoles = userManager.GetRoles(encryptedUser.Id);
      foreach (var item in userRoles)
      {
          Console.WriteLine("Role: " + item);
      }
  }

  Console.ReadKey();
```
- How to work with roles:

```csharp
var roles = userManager.GetRoles(userId);

userManager.RemoveFromRole(userId, "MANAGER");

var roleStore = new RoleStore<IdentityRole>(context);
roleStore.Create(new IdentityRole("MANAGER"));

var identityRole = roleStore.FindByName("MANAGER");
roleStore.Delete(identityRole);
```
