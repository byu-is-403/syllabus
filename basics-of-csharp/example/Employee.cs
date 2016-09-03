namespace EmployeeManager
{
    public class Employee
    {
        const int PADDING = 20;

        string Name {get; set;}
        int Age {get; set;}
        string Occupation {get; set;}
        int Salary {get; set;}

        public Employee(string name, int age, string occupation, int salary)
        {
            this.Name = name;
            this.Age = age;
            this.Occupation = occupation;
            this.Salary = salary;
        }

        override public string ToString()
        {
            string description = "";
            description += Name.PadRight(PADDING);
            description += Age.ToString().PadRight(PADDING);
            description += Occupation.PadRight(PADDING);
            description += ("$" + Salary.ToString() + ".00").PadRight(PADDING);

            return description;
        }

        public static string ColumnHeadings()
        {
            string columns = "\n";
            columns += "Name".PadRight(PADDING);
            columns += "Age".PadRight(PADDING);
            columns += "Occupation".PadRight(PADDING);
            columns += "Salary".PadRight(PADDING);
            
            return columns;
        }
    }
}