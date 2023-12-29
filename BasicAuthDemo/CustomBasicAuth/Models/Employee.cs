namespace BasicAuth.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public bool IsActive { get; set; }

        public static List<Employee> GetEmployee()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee() { Id = 1, FirstName = "Yogesh", LastName= "Kumar", Gender = "Male", City = "Delhi", IsActive = true },
                 new Employee() { Id = 1, FirstName = "Sudesh", LastName= "Kumar", Gender = "Male", City = "Delhi", IsActive = true },
                  new Employee() { Id = 1, FirstName = "Rajesh", LastName= "Kumar", Gender = "Male", City = "Delhi", IsActive = true },
                   new Employee() { Id = 1, FirstName = "Pravesh", LastName= "Kumar", Gender = "Male", City = "Delhi", IsActive = true }
            };
            return employees;
        }
    }
}
