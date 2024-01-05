namespace Aula242ExFixLinq.Entities
{
    internal class Employee
    {
        //Propriedades da classe
        public string Name { get; set; }
        public string Email { get; set; }
        public double Salary { get; set; }

        //Construtor com sobrecarga total
        public Employee(string name, string email, double salary)
        {
            Name = name;
            Email = email;
            Salary = salary;
        }
    }
}
