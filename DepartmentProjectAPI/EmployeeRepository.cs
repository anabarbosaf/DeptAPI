using DepartmentProjectAPI.Models;
using System.Data.SqlClient;

namespace DepartmentProjectAPI
{
    // EmployeeRepository.cs

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SqlConnection _sqlConnection;

        public EmployeeRepository(IConfiguration configuration)
        {
            _sqlConnection = new SqlConnection(configuration.GetConnectionString("EmployeeAppCon"));
        }

        // Outros métodos...

        public IEnumerable<Employee> GetByDepartment(int departmentId)
        {
            var query = @"
            SELECT EmployeeId, EmployeeName, Department, DepartmentId, Rg, PhotoFileName
            FROM dbo.Employees
            WHERE DepartmentId = @DepartmentId
        ";

            using (var command = new SqlCommand(query, _sqlConnection))
            {
                command.Parameters.AddWithValue("@DepartmentId", departmentId);

                _sqlConnection.Open();
                var reader = command.ExecuteReader();

                var employees = new List<Employee>();

                while (reader.Read())
                {
                    var employee = new Employee
                    {
                        EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                        EmployeeName = reader["EmployeeName"].ToString(),
                        Department = reader["Department"].ToString(),
                        DepartmentId = Convert.ToInt32(reader["DepartmentId"]),
                        Rg = Convert.ToInt32(reader["Rg"]),
                        PhotoFileName = reader["PhotoFileName"].ToString()
                    };

                    employees.Add(employee);
                }

                _sqlConnection.Close();

                return employees;
            }
        }
    }
}