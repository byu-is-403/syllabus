# Security


## Contents

- ASP.NET MVC compared to Web Forms
- ASP.NET MVC  Security
- Authorize Attribute
- OpenID
- OAuth
- Wiki Sample
- OpenID vs OAuth
- OAuth 2.0 in MVC
- Change Authentication
- Global Authentication (1)
- Global Authentication (2)
- AuthorizeAttribute for Roles
- Registering External Login Providers


### ASP.NET MVC compared to Web Forms

- MVC does not have as many automatic protections as ASP.NET Web Forms to secure forms like:
- Server Components that automatically encode displayed values to prevent XSS attacks (Cross-Site Scripting (XSS) attacks are a type of injection, in which malicious scripts are injected into otherwise benign and trusted web sites. The end user’s browser has no way to know that the script should not be trusted, and will execute the script. Because it thinks the script came from a trusted source, the malicious script can access any cookies, session tokens, or other sensitive information retained by the browser and used with that site )
- ViewState  is encrypted and validated to prevent tampering (The ViewState indicates the status of the page when submitted to the server. The status is defined through a hidden field placed on each page with a <form runat="server"> control. The ViewState allows ASP.NET to repopulate form fields on each postback to the server, making sure that a form is not automatically cleared when the user hits the submit button.)
- Request Validation intercepts malicious looking data (this is potentially dangerous content such as any HTML markup or JavaScript code in the body, header, query string, or cookies of the request)
- Event Validation prevents injection attacks (Event validation checks the incoming values in a POST to ensure the values are known, good values. If the runtime sees a value it doesn’t know about, it throws an exception.)


### ASP.NET MVC  Security

- MVC gives you more control over markup and how the application works
- This means that you have more  responsibility to make sure you  are taking advantage of necessary security options like HTML encoding through HTML helpers and razor, request validation, etc.)
- NEVER TRUST ANY DATA THE USER GIVES YOU. EVER!


### Authorize Attribute

- Require a user to log in to access the application
- Use the Authorize action filter on a controller (AuthorizeAttribute is default authorization filter included in ASP.NET MVC)
- Authentication is verifying that users are who they say they are using a login mechanism (such as username/password, OpenID, OAuth, etc.)
- Authorization is verifying that they user can do what they want to do with respect to your site
- You can add the attribute to the action such as:

```csharp
[Authorize]
public ActionResult Buy(int id)
{
   … your code here
}
```

- The authorize attribute requires that the user is logged into the site and forbids anonymous access
- Put the security check as close as possible to the thing you are security


### OpenID

- The ASP.NET MVC template with Individual User Accounts authentication includes the AccountController that implements authentication both for OpenID and OAuth
- OpenID is an open standard and decentralized protocol by the non-profit OpenID Foundation that allows users to be authenticated by certain co-operating sites (known as Relying Parties or RP) using a third party service.
- OpenID allows you to use an existing account to sign in to multiple websites, without needing to create new passwords
- OpenID was created for federated authentication, that is, letting a third-party authenticate your users for you, by using accounts they already have. The term federated is critical here because the whole point of OpenID is that any provider can be used (with the exception of white-lists). You don't need to pre-choose or negotiate a deal with the providers to allow users to use any other account they have.OAuth could be used in external partner sites to allow access to protected data without them having to re-authenticate a user
- OpenID is about authentication (ie. proving who you are), OAuth is about authorization (ie. to grant access to functionality/data/etc.. without having to deal with the original authentication).
- OpenID does not require hard coding each the providers you want to use ahead of time. Using discovery, the user can choose any third-party provider they want to authenticate. This discovery feature has also caused most of OpenID's problems because the way it is implemented is by using HTTP URIs as identifiers which most web users just don't get. Other features OpenID has is its support for ad-hoc client registration using a DH exchange, immediate mode for optimized end-user experience, and a way to verify assertions without making another round-trip to the provider.


### OAuth

- OAuth was created to remove the need for users to share their passwords with third-party applications. It actually started as a way to solve an OpenID problem: if you support OpenID on your site, you can't use HTTP Basic credentials (username and password) to provide an API because the users don't have a password on your site.
- OpenID is limited to the 'this is who I am' assertion, while OAuth provides an 'access token' that can be exchanged for any supported assertion via an API
- The most important feature of OAuth is the access token which provides a long lasting method of making additional requests. Unlike OpenID, OAuth does not end with authentication but provides an access token to gain access to additional resources provided by the same third-party service. However, since OAuth does not support discovery, it requires pre-selecting and hard-coding the providers you decide to use. A user visiting your site cannot use any identifier, only those pre-selected by you. Also, OAuth does not have a concept of identity so using it for login means either adding a custom parameter (as done by Twitter) or making another API call to get the currently "logged in" user.


### Wiki Sample

![wikisample](https://cloud.githubusercontent.com/assets/8953261/17107785/f488c904-524d-11e6-9c09-529c725e41e7.png)


### OpenID vs OAuth

- Oauth  (Open Authentication) is used for delegated authorization only -- meaning you are authorizing a third-party service access to use personal data, without giving out a password. Also OAuth "sessions" generally live longer than user sessions. Meaning that OAuth is designed to allow authorization
- i.e. Flickr uses OAuth to allow third-party services to post and edit a persons picture on their behalf, without them having to give out their flicker username and password.
- OpenID is used to authenticate single sign-on identity. All OpenID is supposed to do is allow an OpenID provider to prove that you say you are. However many sites use identity authentication to provide authorization (however the two can be separated out)
- i.e. One shows their passport at the airport to authenticate (or prove) the person's who's name is on the ticket they are using is them.
- OAuth is currently better suited for authorization, because further interactions after authentication are built into the protocol, but both protocols are evolving.
- If you would like more info please visit http://oauth.net/articles/authentication/ 


### OAuth 2.0 in MVC

- We will focus on OAuth instead of OpenID in this course
- Latest version is OAuth 2.0
- OAuth allows users that have multiple accounts on the Internet (Google, FaceBook, etc.) to share those resources between websites (i.e. logging into one and sharing credentials with another)
- By using OAuth a user can log into Facebook using the userid and password and then have access to resources in Facebook to use in their ASP.NET MVC site through registered login providers
- Support for OAuth is provided in MVC through the use of creating a site using the Internet Application template


### Change Authentication

- In an MVC application you have 4 levels of authentication
  - No Authentication – No log on pages will be created
  - Individual User Accounts - Enables a user to register an account, by creating a username and password on the site or by signing in with social providers such as Facebook, Google, Microsoft Account, or Twitter
  - NOTE: The default data store for user profiles in ASP.NET Identity is a SQL Server LocalDB database, which you can deploy to SQL Server or Azure SQL Database for the production site.
  - Organizational Accounts - Configured to use Windows Identity Foundation (WIF) for authentication based on user accounts in Azure Active Directory or Windows Server Active Directory
  - Windows Authentication -  Uses the Windows Authentication IIS module for authentication. The application will display the domain and user ID of the Active directory or local machine account that is logged into Windows but won't include user registration or log-in UI. This option is intended for Intranet web sites
  - NOTE: If you choose this option then the Startup.Auth.cs will NOT be included in the project and no authentication middleware will be configured
- The AccountController handles login and registration but does not restrict access


### Global Authentication (1)

- You can place the AuthorizeAttribute attribute on actions or entire controllers to prevent unauthorized access so that attempting to access a restricted controller action when you're not authorized redirects you to login
- If you don’t want to put the AuthorizeAttribute on every controller you can create a base class 

```csharp
namespace InstantMonkeysOnline.Controllers
{
    [Authorize]
    public class AuthorizedController : Controller
    {
    }
}
```

- AND then have other controllers inherit from this class:
```csharp
public class HomeController : AuthorizedController
{
    public ActionResult Index()
    {
        ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

        return View();
    }        
}
```

### Global Authentication (2)


- Another option is to apply an action filter to all actions in your application
- Modify the FilterConfig.cs file in the App_Start to include  

```csharp
public static void RegisterGlobalFilters(GlobalFilterCollection filters)
{
	filters.Add(new System.Web.Mvc.AuthorizeAttribute());
	filters.Add(new HandleErrorAttribute());
}
```

- The problem with this is that whenever you create a controller, it will restrict access to the entire site including the AccountController (IOW, a user would have to log in before being able to access the login site – not going to work)
- You can use the `[AllowAnonymous]` attribute on any method to opt out of authorization
```csharp
[AllowAnonymous]
Public ActionResult Login(string returnUrl)
{
	ViewBag.ReturnUrl = returnUrl;
	return View();
}
```

### AuthorizeAttribute for Roles

- This attribute allows you to prevent anonymous access to a controller or controller action

```csharp
[Authorize(Roles=“Administrator”)]
public class StoreManagerController : Controller
```

- You can also provide multiple roles 

```csharp
[Authorize(Roles=“Administrator, SuperAdmin”)]
public class StoreManagerController : Controller
```

- You can also specify users and roles

```csharp
[Authorize(Roles=“Administrator, SuperAdmin”, Users=“Greg,Rodney,Scott”)]
public class StoreManagerController : Controller
```


### Registering External Login Providers

- In the App_Start\Startup.Auth.cs you need to explicitly enable external sites for login
- This is where you place all authentication provider information in the ConfigureAuth method:

```csharp
public void ConfigureAuth(IAppBuilder app)
{
    app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie); 
    app.UseFacebookAuthentication(appId: “Your App ID", appSecret: “Your App Secret");
}
```

- Here is a link of Facebook permissions https://developers.facebook.com/docs/facebook-login/permissions/v2.2
- Here is a link of Google permissions http://www.oauthforaspnet.com/providers/google/guides/aspnet-mvc5/ (this one would help you with your homework)
- However, the danger in this is that if your site is ever compromised, an attacker could subvert the login to your site or capture the user’s login information
- Stick with well known trusted login providers










