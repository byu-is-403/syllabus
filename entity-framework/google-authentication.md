# How to grab information from Google authentication

- In the AccountController.cs file in the Controllers folder there is a method called ExternalLoginCallback
- Under the SignInStatus.Success case statement you can extract the information from Google

```csharp
  // GET: /Account/ExternalLoginCallback
  [AllowAnonymous]
  public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
  {
      var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
      if (loginInfo == null)
      {
          return RedirectToAction("Login");
      }

      // Sign in the user with this external login provider if the user already has a login
      var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
      switch (result)
      {
          case SignInStatus.Success:
              if (loginInfo.Login.LoginProvider == "Google")
              {
                  var externalIdentity = AuthenticationManager.GetExternalIdentityAsync(DefaultAuthenticationTypes.ExternalCookie);

                  var emailClaim = externalIdentity.Result.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);

                  var lastNameClaim = externalIdentity.Result.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname);

                  var givenNameClaim = externalIdentity.Result.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName);


                  var email = emailClaim.Value;
                  var firstName = givenNameClaim.Value;
                  var lastname = lastNameClaim.Value;
              }
              return RedirectToLocal(returnUrl);
          case SignInStatus.LockedOut:
              return View("Lockout");
          case SignInStatus.RequiresVerification:
              return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
          case SignInStatus.Failure:
          default:
              // If the user does not have an account, then prompt the user to create an account
              ViewBag.ReturnUrl = returnUrl;
              ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
              return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
      }
  }
```
