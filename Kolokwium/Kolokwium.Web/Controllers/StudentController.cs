using AutoMapper;
using Microsoft.Extensions.Localization;
using Kolokwium.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Kolokwium.ViewModel.VM;
using Microsoft.Extensions.Options;

namespace Kolokwium.Web.Controllers;

public class StudentController : BaseController
{
    private readonly IStudentService _studentService; 
    public StudentController(ILogger logger, IMapper mapper, IStringLocalizer localizer, IStudentService studentService) : base(logger, mapper, localizer)
    {
        _studentService = studentService; 
    }

    public IActionResult Index() {
        var studentVms = _studentService.GetStudents(); 
        return View(studentVms); 
    }

    [HttpGet]
    public IActionResult AddOrUpdateStudent(int? id = null){
        if(id == null)
            return View(); 
        
        var studentVm = _studentService.GetStudent(s => s.Id == id); 
        // var addOrUpdateStudent = Mapper.Map<AddOrUpdateStudentVm>(studentVm); 
        return View(Mapper.Map<AddOrUpdateStudentVm>(studentVm)); 
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddOrUpdateStudent(AddOrUpdateStudentVm addOrUpdateStudentVm){
        // if(addOrUpdateStudentVm == null) throw new ArgumentNullException(); 

        if(ModelState.IsValid){

            _studentService.AddOrUpdateStudent(addOrUpdateStudentVm); 
            return RedirectToAction(nameof(Index)); 
        }
        return View(); 
    }

    [HttpGet]
    public IActionResult DeleteStudent(int id){
        _studentService.DeleteStudent(id); 
        return RedirectToAction(nameof(Index)); 
    }   

}