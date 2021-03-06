// Set static to avoid typing it in
var employeeId = 1;
var grossIncome = 15000;
var taxPercentage = 25M / 100M;
// The employee
var employee = new Employee(employeeId, grossIncome);
// Calculate method
//Current salary
//After 1 year with GradeA
for (int i = 0; i < 5; i++)
{
    var yearZero = TaxCalculation.Calculate(employee, taxPercentage);
    Console.WriteLine("---------------");
    Console.WriteLine(yearZero);
    Console.WriteLine("---------------");
    employee.Increment(Grade.A);
}

public class TaxCalculation
{
    public static TaxCalculation Calculate(Employee employee, decimal taxPercentage = 25m / 100m) =>
        new TaxCalculation(employee, taxPercentage);
    public TaxCalculation(Employee employee, decimal taxPercentage = 25m / 100m)
    {
        Employee = employee;
        Salary = Employee.Salary;
        TaxPercentage = taxPercentage;
        TaxAmount = CalculateTaxAmount(Salary);
        NetPay = CalculateNetPay(Salary);
    }
    public Employee Employee { get; set; }
    public decimal Salary { get; set; }
    public decimal TaxPercentage { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal NetPay { get; set; }
    private decimal CalculateTaxAmount(decimal grossIncome) => (grossIncome * TaxPercentage);
    private decimal CalculateNetPay(decimal grossIncome) => grossIncome - TaxAmount;

    public override string ToString()
    {
        return @"EmployeeID: " + Employee.Id + @"
Gross Salary: " + Employee.Salary + @"
Tax: " + TaxAmount +@"
NetPay: "+NetPay+@""; } 
}

public class Employee
{
    public Employee(int id, decimal salary)
    {
        Id = id;
        Salary = salary;
    }
    public int Id { get; set; }
    public decimal Salary { get; set; }

    public void Increment(Grade grade)
    {
        Salary = Salary * (1 + grade.Increment);
    }
}

public class Grade
{
    public static Grade A => new Grade(2.5m);
    public static Grade B => new Grade(1.5m);
    public static Grade C => new Grade(0m);
    public Grade(decimal incrementPercentage)
    {
        Increment = incrementPercentage / 100m;
    }
    public decimal Increment { get; set; }
}
