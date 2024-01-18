using HRAPP.Entities;
using MySql.Data.MySqlClient;

namespace HRAPP.Repositories;


public class MySqlDBManager
{

    public MySqlDBManager() { }

    public List<Employee> GetAll()
    {
        List<Employee> employees = new List<Employee>();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = @"server=localhost; port=3306; user=root; password=root; database=dotnetmodule";
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT * from employees";
        try
        {
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = int.Parse(reader["id"].ToString());
                string? firstName = reader["firstName"].ToString();
                string? lastName = reader["lastName"].ToString();
                string? email = reader["email"].ToString();
                string? address = reader["address"].ToString();
                Employee emp = new Employee();
                emp.Id = id;
                emp.FirstName = firstName;
                emp.LastName = lastName;
                emp.Email = email;
                emp.Address = address;
                employees.Add(emp);
            }
        }

        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
        return employees;
    }

    public Employee GetById(int id)
    {
        Console.WriteLine("Getting Employee Details");
        Employee employee = new Employee();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = @"server=localhost; port=3306; user=root; password=root; database=dotnetmodule";
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT * from employees WHERE id=" + id;
        try
        {
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                int empId = int.Parse(reader["id"].ToString());
                string? firstName = reader["firstName"].ToString();
                string? lastName = reader["lastName"].ToString();
                string? email = reader["email"].ToString();
                string? address = reader["address"].ToString();

                employee.Id = empId;
                employee.FirstName = firstName;
                employee.LastName = lastName;
                employee.Address = address;
                employee.Email = email;
            }
            reader.Close();
        }
        catch (Exception e)
        {

        }
        finally
        {
            con.Close();
        }
        return employee;
    }

    public void InsertNew(Employee emp)
    {

        Console.WriteLine("Inserting Employee Details");

        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = @"server=localhost; port=3306; user=root; password=root; database=dotnetmodule";
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "INSERT INTO employees values(" + emp.Id + ",'" + emp.FirstName + "','" + emp.LastName + "','" + emp.Email + "','" + emp.Address + "')";

        try
        {
            con.Open();
            cmd.ExecuteNonQuery();

        }
        catch (Exception e)
        {

        }
        finally
        {
            con.Close();
        }

    }

    public Employee DeleteById(int id)
    {

        Console.WriteLine(" Deleting Employee Details");

        Employee employee = new Employee();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = @"server=localhost; port=3306; user=root; password=root; database=dotnetmodule";
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "DELETE  from employees WHERE id=" + id;
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();

        }
        catch (Exception e)
        {

        }
        finally
        {
            con.Close();
        }
        return employee;
    }


    public void UpdateEmp(Employee emp)
    {

        Console.WriteLine(" Updating Employee Details");

        Employee employee = new Employee();
        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = @"server=localhost; port=3306; user=root; password=root; database=dotnetmodule";
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "UPDATE employees SET firstName= '" + emp.FirstName + "',lastName='" + emp.LastName + "',email='" + emp.Email + "',address='" + emp.Address + "'WHERE id=" + emp.Id + "";
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();

        }
        catch (Exception e)
        {

        }
        finally
        {
            con.Close();
        }
    }
}