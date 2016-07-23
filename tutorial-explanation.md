# Tutorial Explanation

This tutorial explains the syntax used in the generated scaffolding code resulting from the EF Tutorial.


## Teams, Index View

- `@Html.DisplayNameFor` (extracts the column name out of the table i.e. teamName)
- `@Html.DisplayFor` (extracts the column text out of the table i.e. Utah Jazz)
- `@Html.ActionLink` (text to display as a link, controller to call (Edit in the Teams controller), what data to pass the controller (teamID)

![indexviewmodels](https://cloud.githubusercontent.com/assets/8953261/17080633/858d5624-50f3-11e6-9d6a-0d47e58a1930.png)

![displaynamefortablenameview](https://cloud.githubusercontent.com/assets/8953261/17080637/a0ca2bd8-50f3-11e6-96e8-f4b508face6c.png)

![foreachindexview](https://cloud.githubusercontent.com/assets/8953261/17080638/ad1561fa-50f3-11e6-8d1f-2323ead8881c.png)


## Teams Controller

![teamscontroller](https://cloud.githubusercontent.com/assets/8953261/17080639/c17c6c60-50f3-11e6-891b-7e83be067cd8.png)

![indexgetcontroller](https://cloud.githubusercontent.com/assets/8953261/17080643/da99ab04-50f3-11e6-98ff-c447dc2079cc.png)


In the Index View, if you clicked on the Edit action in the View it would take you to the Edit ActionResult in the Team Controller

**NOTE: This is in the Index View**


![editlinkview](https://cloud.githubusercontent.com/assets/8953261/17080644/f537a0ec-50f3-11e6-8cd7-7f5555deae53.png)


**Here is the Edit GET Action Method in the Teams Controller**

![editgetcontroller](https://cloud.githubusercontent.com/assets/8953261/17080648/0999dc4e-50f4-11e6-9f7a-768e42a2bf2c.png)


**Here is the Edit POST Action Method**

![editpostcontroller](https://cloud.githubusercontent.com/assets/8953261/17080654/21a371a6-50f4-11e6-90b6-5528493a0591.png)


**Here is the Create POST Action Method**

![createpostcontroller](https://cloud.githubusercontent.com/assets/8953261/17080656/3885ca2c-50f4-11e6-9306-8f1c6854eea2.png)


**Here is the Delete View**

![htmlbeginformview](https://cloud.githubusercontent.com/assets/8953261/17080659/505ab5e0-50f4-11e6-88be-9b8ebe12c401.png)


**Here is the DELETE Get**

![deletegetcontroller](https://cloud.githubusercontent.com/assets/8953261/17080661/69086f9c-50f4-11e6-85fd-af56e12e01aa.png)


**Here is the DELETE Post**

![deletepostcontroller](https://cloud.githubusercontent.com/assets/8953261/17080662/81bdd7f2-50f4-11e6-8100-5254bc165f37.png)

