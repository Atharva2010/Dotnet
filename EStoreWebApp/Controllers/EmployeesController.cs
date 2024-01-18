using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EStoreWebApp.Models;
using HRAPP.Services;
using HRAPP.Entities;

namespace EStoreWebApp.Controllers;
public class EmployeesController : Controller 
{
    private readonly IEmployeeService _svc;
    public EmployeesController(IEmployeeService svc){
        Console.WriteLine("Employee Controller Constructor is being Invoked..");
        this._svc=svc;
    }

    [HttpGet]
    public IActionResult Index()
    {
        Console.WriteLine("EMployee Index Action Method is called...");
        List<Employee> employees = _svc.GetAll();
        TempData["allemployees"]=employees;
        return View();
    }


    // public IActionResult List()
    // {
    //     Console.WriteLine("Employee Index Action Method is Called....");
    //     List<Employee> employees = _svc.GetAll();
    //     return View(employees);
    // }
    public IActionResult Details(int id)
    {
        Employee emp = _svc.GetById(id);
        return View(emp);
    }

    public IActionResult Edit(int id){
         List<Employee> employees=_svc.GetAll();
         var e= employees.Find((emp)=>emp.Id==id);    
        return View(e);
     }

    [HttpPost]
    public IActionResult Edit(Employee emp){   
        _svc.Update(emp);
        List<Employee> employees=_svc.GetAll();
        return RedirectToAction("Index","Employees",null);
    }

    public IActionResult Delete(int id){
        
        Console.WriteLine("delete the employee");
         _svc.Delete(id);
        List<Employee> employees=_svc.GetAll();
       
        return RedirectToAction("Index","Employees",null);
    }

    public IActionResult Register()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Register(IFormCollection form)
    {
        Console.WriteLine("Inside Register");
        Console.WriteLine(form["firstName"].ToString());
        var id = int.Parse(form["Id"].ToString());
        var firstName = form["FirstName"].ToString();
        var lastName = form["LastName"].ToString();
        var email = form["Email"].ToString();
        var address = form["Address"].ToString();
        Employee emp = new Employee();
        emp.Id = id;
        emp.FirstName = firstName;
        emp.LastName = lastName;
        emp.Email = email;
        emp.Address = address;
        Console.WriteLine(emp);

        _svc.Insert(emp);

        return RedirectToAction("Index");
    }

}