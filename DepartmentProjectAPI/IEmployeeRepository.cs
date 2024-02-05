using DepartmentProjectAPI.Models;

namespace DepartmentProjectAPI
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetByDepartment(int departmentId);
    }
}