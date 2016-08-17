# ASP.NET MVC 5 Deployment


## One Click Deploy

- Visual Studio has different methods to deploy your web application but the easiest method is through the one-click publish option
- This deploys your app directly from Visual Studio and connects to a destination server, copies project files to the server, etc.
- In order to deploy an MVC web app you will first need to set up an account with a hosting company
- Make sure the hosting company supports ASP.NET
- Then you will need to create a publish profile that specifies the server you are deploying to, your credentials for logging into that server, and other deployment info


#### Publish

- The Publish button is Visual Studio by clicking Build | Publish Security
- Click on the Custom entry

![custom](https://cloud.githubusercontent.com/assets/8953261/17108485/fcbddeb8-5250-11e6-958a-238e03463285.png)

#### Profile

- Enter a descriptive name for this custom hosting destination

![newcustomprofile](https://cloud.githubusercontent.com/assets/8953261/17108500/161271e4-5251-11e6-969d-aef1852f3e1a.png)

- Click the OK button


#### Connection Info

- There are different ways to publish (Web Deploy, Web Deploy Package, FTP, File System)
- Choose whichever one you feel most comfortable to work with
- This is an example of FTP

![publishweb](https://cloud.githubusercontent.com/assets/8953261/17108520/2f2b5d30-5251-11e6-9d81-bc67ad571fff.png)


#### Test Connection

- Make sure you test the connection by clicking on the Validate Connection button
- If it works you should see a green check mark

![validateconnection](https://cloud.githubusercontent.com/assets/8953261/17108539/42a7ecde-5251-11e6-9192-e196c37d0f99.png)


#### Publish Files

- Then click on the Publish button and the files will be published through FTP to your specified server
- If the publish succeeded you will see something similar to:

![consolepublish](https://cloud.githubusercontent.com/assets/8953261/17108566/58cd0742-5251-11e6-8b20-328718c0e101.png)






