using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace webApiAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get([FromQuery]int id, string query)
        {
            string Text = "";
            if (query == "studentList")
            {
                Student obj = new Student();
                List<Student> students = obj.GetStudentList();
                foreach (Student std in students)
                {
                    Text += "Student id is: " + std.Id + ",Student First Name is: " + std.FirstName +
                        ",Student last name is: " + std.LastName + ",Student Divison is " + std.Divison +
                        "Student Grade is:" + std.Grade+"\n";
                }
            }
            else
                Text = "Wrong query";
            return Text;

        }

        // POST api/values
        [HttpPost("{id}")]
        public List<Student> Post(int id, [FromBody] Student student)
        {
            Student obj = new Student();
            List<Student> std = obj.GetStudentList();
            std.Add(student);
            return std;

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public List<Student> Put(int id, [FromBody] Student student)
        {
            Student newStudent = new Student();
            List<Student> StudentList = newStudent.GetStudentList();
            foreach (Student std in StudentList)
            {
                if (std.Id == student.Id)
                {
                    std.Id = student.Id;
                    std.FirstName = student.FirstName;
                    std.LastName = student.LastName;
                    std.Grade = student.Grade;
                    std.Divison = student.Divison;
                    break;
                }
            }
            
            return StudentList;






        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public List<Student> Delete(int id, [FromBody] Student student)
        {
            Student std = new Student();
            List<Student> StudentList = std.GetStudentList();
            int i = 0;
            int flag = 0;
            for (i = 0; i < StudentList.Count; i++)
            {
                if (student.Id == StudentList[i].Id)
                {
                    flag = 1;
                    break;
                }
            }

            if (flag == 1)
                StudentList.RemoveAt(i);
            return StudentList;
        }
    }

    public class Student
    {
       public Student()
        {

        }

        public Student(int v1, string v2, string v3, string v4, double v5)
        {
            this.Id = v1;
            this.FirstName = v2;
            this.LastName = v3;
            this.Divison = v4;
            this.Grade = v5;
        }

        // Id, FirstName, LastName, Division, Grade
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Divison { get; set; }
        public double Grade { get; set; }

        public List<Student> studentList = new List<Student>();


        public List<Student> GetStudentList()
        {           
            studentList.Add(new Student(1011, "Aman", "Prakash", "A", 9.2));
            studentList.Add(new Student(1012, "Saket", "Saurabh", "B", 9.7));
            studentList.Add(new Student(1013, "Shivani", "Priya", "A", 9.2));
            studentList.Add(new Student(1014, "Prateeksha", "Shukla", "C", 8.5));
            studentList.Add(new Student(1015, "Pankaj", "Singh", "B", 8.8));
            return studentList;
        }

        
        

    }
}
