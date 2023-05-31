namespace StockControl.Models
{
    public class UserRolesViewModel
    {
        public Employee Employee {get; set;}
        public User User { get; set; }
        public Department Department { get; set;}

        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Department> Departments { get; set; }
    }
}
