# Entity Framework


## Contents

1. .NET Entity Framework (EF)
2. Models
3. Navigational Properties
4. Creating a Model
5. Foreign Keys
6. Creating your own Primary Key Value
7. DbContext
8. Working with the Database
9. Seeding the Database
11. LocalDB
12. Controllers and Data


## .NET Entity Framework (EF)

- NET Framework data-access technology is known as the Entity Framework (Also known as EF)
- Supports a development paradigm called Code First
- Code First is when you create model objects by writing simple classes
- Now you can create the database from the model by the system
- Creating models is like creating the skeleton of a database table


## Models

- You create models in the Models folder

  ```csharp
  public class Student
  {
    public int ID { get; set; }
    public string LastName { get; set; }
    public string FirstMidName { get; set; }
    public DateTime EnrollmentDate { get; set; }
    
    public virtual ICollection<Enrollment> Enrollments { get; set; }
  }
  ```

- The ID property becomes the primary key for the column and can either be named ID or classnameID 
- This happens by default by the EF and you do not control it


### Navigational Properties

- Enrollments is a navigational property meaning. that they hold an entity relating to other entities (similar to a foreign key)
- For example, the Enrollments property of this Student entity will hold all of the Enrollment entities that are related to that Student entity
- If a student row (entity) was enrolled in two courses, then the Enrollments property would hold the two enrollment rows
- Navigational properties are defined as virtual so that "lazy loading" can occur
- Lazy loading means that when the entity is first read, related data isn't retrieved. But the first time you try to access the navigation property, the data required for that navigation property is automatically retrieved. This results in multiple queries sent to the database — one for the entity itself and one each time that related data for the entity must be retrieved.
- If the navigational property can hold more than one entity (more than one enrollment row) then it must be defined as an ICollection data type
- This is automatically handled by the DbContext class


### Creating a Model

- You can create a new model by adding a new class to the Models folder
- .NET looks for a property that is either ID or classnameID and sets it as the primary key (NOTE: if you use ID without classname it makes it easier to implement inheritance in the data model.)
- For example, in the code below, EnrollmentID is automatically declared as the primary key

```csharp
public class Enrollment
{
  public int EnrollmentID { get; set; }
  public int CourseID { get; set; }
  public int StudentID { get; set; }
  public Grade? Grade { get; set; }
  
  public virtual Course Course { get; set; }
  public virtual Student Student { get; set; }
}
```


#### Foreign Keys

- If you notice, CourseID is of type int. That means it is a foreign key to the Course class but only holds one entity of type Course
- The same goes for the StudentID navigational property
- The Grade property is of type Grade. This "could" be a class. However, if we added the following to the model then we see it is an enum. Meaning that it can be either the value A, B, C, D, or F.

```csharp
public enum Grade
{
  A, B, C, D, F
}
```

- The question mark ? tells the system that the value can be null (unknown or not assigned yet)
- The syntax for  a foreign key is <navigation property name><primary key property name> or <primary key property name>  (CourseID is the primary key in the Course model so you could just use that same primary key as a foreign key in another model)


#### Creating your own Primary Key value

```csharp
public class Course
{
  [DatabaseGenerated(DatabaseGeneratedOption.None)]
  public int CourseID { get; set; }
  public string Title { get; set; }
  public int Credits { get; set; }
  
  public virtual ICollection<Enrollment> Enrollments { get; set; }
}
```

- The DatabaseGenerated(DatabaseGeneratedOption.None) indicates that the source code will be responsible for creating the primary key value rather than the EF
- CourseID is the primary key
- Enrollments is navigational property and there can be more than one enrollment record associated with each course record


## DbContext

- The database context class (DbContext) is the foundation class used to create an entity included in the model
- When you create a new model it is based upon the System.Data.Entity.DbContext class
- You will want to create a model for each table you want to work with from the database
- The DbContext class acts as the database
- Within the DbContext class you define DbSets (representing the tables or entitites)
- By default, the EF tries to pluralize the variable names you created using the DbSet class

```csharp
public class SchoolContext : DbContext
{
  public SchoolContext() : base("SchoolContext") {}
  
  public DbSet<Student> Students { get; set; }
  public DbSet<Enrollment> Enrollments { get; set; }
  public DbSet<Course> Courses { get; set; }
  
  protected override void OnModelCreating(DbModelBuilder modelBuilder)
  {
    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
  }
}
```
- As stated earlier, the DbSet class represents an entity (table) within the database
- If you have a navigational property you do not really need to create a DbSet for it since the EF does it for you. However, it is probably more readable if you do. In this case you did NOT have to create it for Enrollment or Course since Student refers to those entities
  
  
  `public SchoolContext() : base("SchoolContext")`
  
- This is the name of the connection string that will be added to the Web.config file.
- If you don't specifically specify the connection string then the EF assumes it is the name of the class (in this case it is SchoolContext – same name as what you specified – BUT more readable)
  
  
  `modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();`
  
- This statement in the OnModelCreating method prevents the default table names from being pluralized (student class becomes students class – big pain!) – Your choice to include the statement


## Working with the Database

- Default behavior is to create a database only if it doesn't exist (and throw an exception if the model has changed and the database already exists)
- You can specify a seed method to recreate the database and load it with info
 
  
  `public class SchoolInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<SchoolContext>`
  
- This method specifies that it will be called if the model changes. It will then drop the database and recreate it
- Then you can include a seed method in this class that loads the data into the DbContext and saves it


### Seeding the Database

```csharp
protected override void Seed(SchoolContext context)
{
  var students = new List<Student> {
    new Student{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
    new Student{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
    new Student{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
    new Student{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
    new Student{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
    new Student{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
    new Student{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
    new Student{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
  };
  
  students.ForEach(s => context.Students.Add(s));
  context.SaveChanges();
}
```

- You can call this seed method by modifying the Web.config file

```xml
<entityFramework>
  <contexts>
    <context type="ContosoUniversity.DAL.SchoolContext, ContosoUniversity">
      <databaseInitializer type="ContosoUniversity.DAL.SchoolInitializer, ContosoUniversity" />
    </context>
  </contexts>
</entityFramework>
```

- The context type specifies the fully qualified context class name and the assembly it's in, and the databaseinitializer type specifies the fully qualified name of the initializer class and the assembly it's in
- When you don't want EF to use the initializer, you can set an attribute on the context element: disableDatabaseInitialization="true"
- When you access the database for the first time in running the application the Entity Framework compares the database to the model. If there's a difference, the application drops and re-creates the database.


## Local DB

- LocalDB is a lightweight version of the SQL Server Express Database Engine and comes with the EF and .NET (not recommended for production though since it does not work with IIS)
- You can put LocalDB database files in the App_Data folder of a web project
- To work with a LocalDB SQL database you must add a connection string to the Web.config file in the root folder

```xml
<connectionStrings>
  <add name="SchoolContext" connectionString="Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=ContosoUniversity;Integrated Security=SSPI;" providerName="System.Data.SqlClient"/>
</connectionStrings>
```

- The DbContext class "SchoolContext" handles the task of connecting to the database and mapping objects to database records. The connection string in the Web.config file specifies the name and type of database. 


## Controllers and Data

- You can create a controller that works with the EF and views
- When creating the controller you can select a model already created which creates a link between the view and the data structure
- You can also specify the Data Context which specifies how the objects will be mapped to the data
- Since the model is in place along with the Data Context and Connection String, the controller has everything it needs to create the code necessary to work with the data







