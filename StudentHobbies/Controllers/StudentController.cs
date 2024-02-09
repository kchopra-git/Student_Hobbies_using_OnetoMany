using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Student_Hobbies.Model;

namespace StudentHobbies.Controllers
{
    public class StudentController : Controller
    {
        private readonly RestClient _client;
        public IActionResult Index()
        {
            return View();
        }

        public StudentController()
        {
            // Replace the base URL with your actual Web API URL
            _client = new RestClient("https://localhost:7296/api/");
        }

        // GET: Student
        public ActionResult Details()
        {
            var request = new RestRequest("Student", Method.Get);
            var response = _client.Execute<List<Student>>(request);
            var students = response.Data;
            return View(students);
        }
       
    }
}
