using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Employee
{
    public string PassportSeries { get; }
    public string PassportNumber { get; }
    public string LastName { get; }

    public Employee(string passportSeries, string passportNumber, string lastName)
    {
        PassportSeries = passportSeries;
        PassportNumber = passportNumber;
        LastName = lastName;
    }

    public string GetFullName()
    {
        return LastName;
    }

    public string GetPassportSeries()
    {
        return PassportSeries;
    }

    public string GetPassportNumber()
    {
        return PassportNumber;
    }

    public override string ToString()
    {
        return $"Passport: {PassportSeries}-{PassportNumber}, Last Name: {LastName}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        var isAutoMode = false;
        foreach (var arg in args)
        {
            if (arg.Equals("auto", StringComparison.OrdinalIgnoreCase))
            {
                isAutoMode = true;
                break;
            }
        }

        if (isAutoMode)
        {
            string partialLastName = null;
            string partialPassportSeries = null;
            string partialPassportNumber = null;

            if (args.Length == 4 && args[0].Equals("auto", StringComparison.OrdinalIgnoreCase))
            {
                partialLastName = args[1];
                partialPassportSeries = args[2];
                partialPassportNumber = args[3];
            }
            else
            {
                Console.WriteLine("Usage: dotnet run auto [PartialLastName] [PartialPassportSeries] [PartialPassportNumber]");
                return;
            }

            var lastNamePattern = new Regex(partialLastName.Replace("...", ".*"));
            var passportSeriesPattern = new Regex(partialPassportSeries.Replace("...", ".*"));
            var passportNumberPattern = new Regex(partialPassportNumber.Replace("...", ".*"));

            var employees = new List<Employee>
            {
                new Employee("AI", "98765", "Artemenko"),
                new Employee("FI", "12345", "Petrenko"),
                new Employee("QW", "67890", "Ivanenko"),
                new Employee("MX", "86123", "Artemenko")
            };

            var potentialMatches = new List<Employee>();

            foreach (var employee in employees)
            {
                var fullName = employee.GetFullName();
                var passportSeries = employee.GetPassportSeries();
                var passportNumber = employee.GetPassportNumber();

                if (lastNamePattern.IsMatch(fullName) &&
                    passportSeriesPattern.IsMatch(passportSeries) &&
                    passportNumberPattern.IsMatch(passportNumber))
                {
                    potentialMatches.Add(employee);
                }
            }

            if (potentialMatches.Count > 0)
            {
                Console.WriteLine("Potential Matches for the damaged passport:");
                foreach (var match in potentialMatches)
                {
                    Console.WriteLine(match);
                }
            }
            else
            {
                Console.WriteLine("No potential matches found for the damaged passport.");
            }
        }
        else
        {
            Console.Write("Enter a partial last name: ");
            var partialLastName = Console.ReadLine();
            var lastNamePatternString = partialLastName.Replace("...", ".*");
            var lastNamePattern = new Regex(lastNamePatternString);

            Console.Write("Enter a partial passport series: ");
            var partialPassportSeries = Console.ReadLine();
            var passportSeriesPatternString = partialPassportSeries.Replace("...", ".*");
            var passportSeriesPattern = new Regex(passportSeriesPatternString);

            Console.Write("Enter a partial passport number: ");
            var partialPassportNumber = Console.ReadLine();
            var passportNumberPatternString = partialPassportNumber.Replace("...", ".*");
            var passportNumberPattern = new Regex(passportNumberPatternString);

            var employees = new List<Employee>
            {
                new Employee("AI", "98765", "Artemenko"),
                new Employee("FI", "12345", "Petrenko"),
                new Employee("QW", "67890", "Ivanenko"),
                new Employee("MX", "86123", "Artemenko")
            };

            var potentialMatches = new List<Employee>();

            foreach (var employee in employees)
            {
                var fullName = employee.GetFullName();
                var passportSeries = employee.GetPassportSeries();
                var passportNumber = employee.GetPassportNumber();

                if (lastNamePattern.IsMatch(fullName) &&
                    passportSeriesPattern.IsMatch(passportSeries) &&
                    passportNumberPattern.IsMatch(passportNumber))
                {
                    potentialMatches.Add(employee);
                }
            }

            if (potentialMatches.Count > 0)
            {
                Console.WriteLine("Potential Matches for the damaged passport:");
                foreach (var match in potentialMatches)
                {
                    Console.WriteLine(match);
                }
            }
            else
            {
                Console.WriteLine("No potential matches found for the damaged passport.");
            }
        }
    }
}
