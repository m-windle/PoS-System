using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SofkhaPOSLib.Database;

namespace SofkhaPOSLib
{
    public class Employee
    {
        private int employeeID;
        private string firstName;
        private string lastName;

        public int EmployeeID { get { return employeeID; } }
        public string FirstName { get { return firstName; } }
        public string LastName { get { return lastName; } }

        //Constructors
        public Employee() { }
        public Employee(int EID, string FName, string LName)
        {
            this.employeeID = EID;
            this.firstName = FName;
            this.lastName = LName;
        }

        /// <summary>
        /// Constructs an employee object with the database results from the passed ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>
        /// Returns an Employee object with the specific ID
        /// </returns>
        public static Employee FindEmployee(int ID)
        {
            string query = "SELECT * FROM Employee_T WHERE ID=" + ID;
   
            DataRowCollection results = DatabaseController.GetQueryResults(query, new Dictionary<string,object>());

            if (results.Count > 0)
                return new Employee((int)results[0]["ID"], (string)results[0]["FirstName"], (string)results[0]["LastName"]);
            else
                Logging.Log("WARNING: Unknown employee ID {0}", ID);
                return new Employee(0, "Unknown", "Employee");
        }

        /// <summary>
        /// Constructs an array of employee objects from the data in the Employee_T Table
        /// </summary>
        /// <returns>
        /// Returns an array of Employee objects
        /// </returns>
        public static Employee[] GetAllEmployees()
        {
            string query = "SELECT * FROM Employee_T";
            List<Employee> employees = new List<Employee>();
            Employee outEmployee; 

            DataRowCollection results = DatabaseController.GetQueryResults(query, new Dictionary<string, object>());

            foreach(DataRow i in results)
            {
                outEmployee = new Employee((int)i["ID"], (string)i["FirstName"], (string)i["LastName"]);
                employees.Add(outEmployee);
            }

            return employees.ToArray();
        }

        public override string ToString()
        {
            return this.EmployeeID + ": " + this.LastName + ", " + this.FirstName;
        }
    }
}
