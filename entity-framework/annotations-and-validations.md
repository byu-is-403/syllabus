# Annotations and Validations

## Contents

- Validations
- Annotations
- Requited Attribute
- DisplayName Attribute
- StringLength Attribute
- RegularExpression Attribute
- How does Regex Work?
- Regex Samples
- Range Attribute
- Compare Attribute
- Error Messages
- ModelState
- Controllers and Validation Errors
- Display Annotations
- ScaffoldColumn Attribute
- DisplayFormat Attribute
- ReadOnly Attribute
- DataType Attribute


### Validations

- Validation logic should execute on the browser and also on the server
- It browser validation provides the uses instant feedback
- The server validation is because we should validate any data arriving to the server


### Annotations

- Annotations are means to add the validation through the use of metadata which describes the data on a web page 
- Data Annotations allow us to describe the rules we want applied to our model properties, and ASP.NET MVC will take care of enforcing them and displaying appropriate messages to our users
- Data Annotations provide server side validation
- Attributes to use in Data Annotations:
  - Required
  - DisplayName
  - StringLength
  - RegularExpression
  - Range
  - Compare


#### Required Attribute

- The Required attribute validates that the user entered information within a property of the model
- You define the validation through the use of editing the model and the [ ] (square brackets) along with the word Required

```csharp
[Required]
public string FirstName { get; set; }
```

- This statement binds the required attribute to the FirstName property for the model. If the user leaves it empty or if it is NULL, a validation error is raised. 
- You would see a message like "The FirstName field is required" when the user submits the form


#### DisplayName Attribute

- The DisplayName is NOT a validation but it IS an attribute within a property of the model
- This attribute defines the text we want used on form fields and validation messages  

```csharp
[DisplayName("Genre")]
public int      GenreId    { get; set; }
```

- If you use in your view the following:

```html
@Html.LabelFor(x => x.GenreId)

would generate:

<label for="GenreId">Genre</label>
```

- You could also use the Display attribute and then specify the metadata you want to modify

```csharp
[Display(Name = "Color Code")]
public string Color { get; set; }
```

#### StringLength Attribute

- The StringLength attribute defines a maximum length for a string field

```csharp
[Required(ErrorMessage = "An Album Title is required")]
[StringLength(160)]
public string Title { get; set; }
```

- This statement indicates that the maximum string length for the Title property will be 160 characters
- It also specifies that it is required and if they leave it empty or null then the error message "An Album Title is required" will be displayed
- You can also specify the minimum number of characters that should be entered by using the MinimumLength attribute
	
```csharp
[StringLength(255, MinimumLength = 8)]
  // OR
[StringLength(255, MinimumLength = 8, ErrorMessage = "Invalid")]
```
	

#### RegularExpression Attribute

- The RegularExpression attribute invokes the regex (stands for Regular Expression) and is a special text string describing a pattern used either for searching or string matching
- It is used to make sure only certain characters have been used for input
- For example, if you want to try and validate a name you might assume that a name will not contain numbers of special characters and only upper and lower case alphabet values should be accepted
- Like other attributes, the RegularExpression is expecting a parameter of type string
	
	```csharp
	[RegularExpression(@"^[0-9]{0,15}$", ErrorMessage = "PhoneNumber should contain only numbers")]
	
	[RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Please Enter Correct Email Address")]
	```
	
- Be aware that there are attributes/data types already built in that you can use in the model to ensure proper data entry. For example:
	
	```csharp
	[Email(ErrorMessage = "Bad email")]
	
  // OR simply specify that the property is an EmailAddress
  
	[EmailAddress]
	```
	
#### How does Regex work?

- There are some characters with special meanings:  ` \ ^ $ . | ? * + ( ) [ ] { }`
- If you want to use any of these characters as a literal character (IOW, no special meaning) then you would need to "escape" them with a backslash: `\`.
- NOTE: The `{ }` usually does not require the escape
- Character set uses the `[ ]` (the hyphen within the `[ ]` acts as a range)
	
	
	`[0-9a-fA-F]` indicates you can have a single digit, a lower case `a` through `f`, and an upper case `A` through `F`

- A caret ^ negates the value
	
	
	`q[^u]` indicates that you can allow the letter "q" followed by a character that is NOT a "u"

- If the character after a hyphen is an opening bracket then it is interpreted as a subtraction operator rather than a range operator
	
	
	`[a-z-[aeiuo]]` indicates you can have an a through z but it cannot include a vowel of a, e, i, u, or o
	
	
	`[0-9-[0-6-[0-3]]]` indicates you can have 0 through 9 but not 0 through 6 but exclude 0 through 3 meaning you can 		have the result of 0123789

- For more information on regex in C#, please look at 
  
  
  http://www.mikesdotnetting.com/article/46/c-regular-expressions-cheat-sheet
  

##### Samples

- Zip code (matches 12345 and 12345-5432)
	
	
	`^\d{5}([\-]\d{4})?$`
	
- US States
	
	
	`^(?:(A[KLRZ]|C[AOT]|D[CE]|FL|GA|HI|I[ADLN]|K[SY]|LA|M[ADEINOST]|N[CDEHJMVY]|O[HKR]|P[AR]|RI|S[CD]|T[NX]|UT|V[AIT]|W[AIVY]))$`


- Phone Number – Matches phone numbers with or with out extensions,  (555) 555-555 and (555) 555-5555 123
	
	
	`^\+?\(?\d+\)?(\s|\-|\.)?\d{1,3}(\s|\-|\.)?\d{4}[\s]*[\d]*$`
	

#### Range Attribute

- The Range attribute specifies the minimum and maximum constraints for a numerical value
	
	```csharp
  [Range(0,17)]
  public int MinorAge { get; set; }
	```
	
- The values are inclusive and can work with integers and doubles


#### Compare Attribute

- The Compare attribute makes sure that 2 properties on a model object have the same value
- For example, maybe you have the user enter their email address and then enter it again as a confirmation

```csharp
[EmailAddress]
public string Email { get; set; }

[EmailAddress]
[Compare("Email")]
public string ConfirmEmail { get; set; }
```

- When entered, if the addresses do not match, the validator will display a message similar to " 'ConfirmEmail' and 'Email' do not match"	


### Error Messages

- Every validation attribute allows you to pass a parameter for ErrorMessage
	
	```csharp
	[Required(ErrorMessage="The First Name is required")]
	public string FirstName { get; set; }
	```
	
- You can also have a single item in the string

  ```csharp
  [Required(ErrorMessage="The {0} is required")]
	public string FirstName { get; set; }
  ```
  
- The {0} item will extract the property name


### Model State

- ASP.NET MVC executes validation logic during the model binding
- The model binder automatically runs when you have a parameter associated with an action method

```csharp
public ActionResult Create(Album album)

// You can also request model binding using the UpdateModel or TryUpdateModel methods

public ActionResult Create(Album album)
{
	if (TryUpdateModel(album))
	{
	  // …do something here
	}
}

```

- After the model binder has updated the model properties with new values, it uses the model metadata to get all of the validators and executes the validation logic
- Any errors are put into the Model State and the ModelState.IsValid would return a false


### Controllers and Validation Errors

- When validation fails, an action generally renders the same view that posted the model values. This allows the user to see all of the validation errors and fix them

```csharp
[HttpPost]
public ActionResult UpdatePament(Order newOrder)
{
  if (ModelState.IsValid) {
  	//…do the posting and saving
  }
  
  return View(newOrder);
}
```


### Display Annotations

- The Display attributes allows you to set the display name for the model property

  ```csharp
  [Display(Name="First Name")]
	public string FirstName { get; set;}
	
	// Through the use of this attribute you can also control the order in which the properties are displayed in the user interface. Otherwise, the properties are displayed in sequential order. This would display First Name, Last Name, and Address in that order
	
	[Display(Name="First Name", Order=15001)]
	public string FirstName { get; set;}

	[Display(Name="Address ", Order=15003)]
	public string Address { get; set;}

	[Display(Name="Last Name ", Order=15002)]
	public string LastName { get; set;}
	
  ```
  
- The default value for order is 10,000 and the properties using the order will be displayed in ascending order


### ScaffoldColumn Attribute

- The ScaffoldColumn hides a property from the HTML helpers (EditorForModel and DisplayForModel)
- Setting the ScaffoldColumn to false would mean that the EditorForModel would no display an input or label for the field

  ```csharp
  [ScaffoldColumn(false)]
	public string Username { get; set; }
  ```

### DisplayFormat Attribute

- The DisplayFormat attribute allows you to provide various formatting options for the property and is only used with EditorFor and DisplayFor and not by the HTML helpers (i.e. TextBoxFor)

  ```csharp
  [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString="{0:c}")]
	public decimal Total { get; set; }
  ```

- This informs the EditorFor and DisplayFor that the Total property of type decimal will use the dataformatstring of currency and that the system should apply the attribute in the EditMode of the form input


	Output within the TextBox could be:
	
	```
	Total
	$12.10
  ```

### ReadOnly Attribute

- The ReadOnly attribute makes the property read only (imagine that!)
- The tells the model binder to not set the property with a new value from the request

  ```csharp
  [ReadOnly(true)]
  public decimal Total { get; set; }
  ```


### DataType Attribute

- The DataType attribute allows you to provide the runtime with information about the  purpose of the property
	
	```csharp
	[DataType(DataType.Password)]
	public string UserPassword { get; set; }
	```
	
- Here are the different values you can use with the DataType attribute:

  - `CreditCard`  	Represents a credit card number.
  - `Currency`	    Represents a currency value.
  - ``Date``		      Represents a date value.
  - `DateTime`	    Represents an instant in time, expressed as a date and time of day.
  - `EmailAddress`	Represents an e-mail address.
  - `Html`		      Represents an HTML file.
  - `ImageUrl`    	Represents a URL to an image.
  - `MultilineText`	Represents multi-line text.
  - `Password`	    Represent a password value.
  - `PhoneNumber`	  Represents a phone number value.
  - `PostalCode`	  Represents a postal code.
  - `Text`		      Represents text that is displayed.
  - `Time`		      Represents a time value.
  - `Upload`	    	Represents file upload data type.
  - `Url`		        Represents a URL value.























