using System;
using System.Collections.Generic;
using System.Text;

namespace MediatrBehavior.Example.Core.Models
{
    public class Professional
    {
        public string Name { get; init; }
        public DateTime HireDate { get; init; }
        public double? Salary { get; init; }

        public Professional(string name, DateTime hireDate, double? salary)
            => (Name, HireDate, Salary) = (name, hireDate, salary);

        private Professional() { }
    }
}
