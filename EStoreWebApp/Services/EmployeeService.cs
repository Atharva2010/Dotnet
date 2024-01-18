using HRAPP.Entities;
using HRAPP.Repositories;
namespace HRAPP.Services;

public class EmployeeService : IEmployeeService
{

    public EmployeeService()
    {
        Console.WriteLine("Employee Service Constructor is invoked...");
    }

    public List<Employee> GetAll()
    {

        List<Employee> employees = new List<Employee>();
        MySqlDBManager mgr = new MySqlDBManager();
        employees = mgr.GetAll();
        return employees;

    }

    public Employee GetById(int id)
    {
        MySqlDBManager mgr = new MySqlDBManager();
        Employee emp = mgr.GetById(id);
        Console.WriteLine("fetching employee using DBManager");
        return emp;
    }

    public void Insert(Employee emp)
    {
        MySqlDBManager mgr = new MySqlDBManager();
        mgr.InsertNew(emp);
        Console.WriteLine("inserting employee using DBMangager");
    }

    public void Update(Employee emp)
    {
        MySqlDBManager mgr = new MySqlDBManager();
        mgr.UpdateEmp(emp);
        Console.WriteLine("updating employee using DBManager");
    }

    public void Delete(int id)
    {
        MySqlDBManager mgr = new MySqlDBManager();
        mgr.DeleteById(id);
        Console.WriteLine("deleting employee using DBMangager");
    }

}