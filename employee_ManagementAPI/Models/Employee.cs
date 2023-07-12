namespace employee_ManagementAPI.Models
{
    public class Employee
    {
        public int Empno { get; set; }
        public string EmpName { get; set; }
        public double EmpSalary { get; set; }

        public string EmpDesignation { get; set; }

        public  bool isPermanent { get; set; }

        private static int emp_auto = 1340000;

        public Employee()
        {
            emp_auto = emp_auto + 1;
            Empno = emp_auto;
        }

        private static List<Employee> eList = new List<Employee>()
        {
            new Employee() {Empno = 100, EmpName ="Krishna", EmpDesignation ="System Engineer", EmpSalary=20000, isPermanent = true },
             new Employee() {Empno = 101, EmpName ="Vipul", EmpDesignation ="Manager", EmpSalary=75000, isPermanent = true },
              new Employee() {Empno = 102, EmpName ="Srini", EmpDesignation ="Trainee", EmpSalary=10000, isPermanent = false },
               new Employee() {Empno = 103, EmpName ="Raj", EmpDesignation ="Associate", EmpSalary=30000, isPermanent = true },
                new Employee() {Empno =104, EmpName ="Mano", EmpDesignation ="Senior Associate", EmpSalary=60000, isPermanent = true },
        };

        public List<Employee> GetAllEmployees()
        {
            return eList;
        }

        public Employee GetEmployeeByID (int id)
        {
            var emp = eList.Find(e => e.Empno == id);

            if (emp != null)
            {
                return emp;
            }

            throw new Exception("Employee not found");

        }

        public Employee GetEmployeeByName(string name)
        {
            var emp = eList.Find(e => e.EmpName == name);

            if (emp != null)
            {
                return emp;
            }

            throw new Exception("Employee not found");

        }
        public List<Employee> GetPermenantEmployee(bool state)
        {
            var emps = eList.FindAll(e => e.isPermanent == state);
            return emps;
        }
        public int GetTotalEmployees()
        {
            var total = eList.Count;
            return total;
        }

        public string AddEmployee (Employee obj)
        {
            eList.Add(obj);
            return "Employee added";

        }

        public string UpdateEmployee(Employee obj)
        {
            var emp = eList.Find(e => e.Empno == obj.Empno);

            if (emp != null)
            {
                emp.EmpName = obj.EmpName;
                emp.EmpDesignation = obj.EmpDesignation;
                emp.EmpSalary = obj.EmpSalary;
                emp.isPermanent = obj.isPermanent;
                return "employeed has been updated";

            }
          throw new Exception( "employee not found");

        }

        public string DeleteEmployee(int id)
        {
            var emp = eList.Find(e => e.Empno == id);
            if (emp != null)
            {
                eList.Remove(emp);
                return "Employee Deleted";
            }
            throw new Exception("Employee Not Found");

        }


    }
}
