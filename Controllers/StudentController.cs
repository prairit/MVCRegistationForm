using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAL;
using DTO;
using MVCForm.Models;

namespace MVCRegistationForm.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            StudentBAL stdbal = new StudentBAL();
            List<StudentDTO> ListStudents=stdbal.GetBL();
            return View(ListStudents);
        }

        /*
        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View(ListStudents.SingleOrDefault(e=>e.StudentID==id));
        }*/

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                StudentDTO newStudent = new StudentDTO();
                newStudent.FirstName = collection["FirstName"];
                newStudent.LastName = collection["LastName"];
                newStudent.EmailID = collection["EmailID"];
                newStudent.PhoneNumber = Convert.ToInt64(collection["PhoneNumber"]);
                newStudent.Gender = collection["Gender"];
                newStudent.State = collection["State"];
                newStudent.Country = collection["Country"];
                StudentBAL stdbal=new StudentBAL();
                stdbal.AddBL(newStudent);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            //return View(ListStudents.SingleOrDefault(e => e.StudentID == id));
            return View();
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                StudentBAL stdbal =new StudentBAL();
                stdbal.UpdateBL(new StudentDTO
                {
                    StudentID = id,
                    FirstName = collection["FirstName"],
                    LastName = collection["LastName"],
                    EmailID = collection["EmailID"],
                    PhoneNumber =Convert.ToInt64(collection["PhoneNumber"]),
                    Gender = collection["Gender"],
                    State = collection["State"],
                    Country = collection["Country"]
                });

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            //return View(ListStudents.SingleOrDefault(e => e.StudentID == id));
            StudentBAL stdbal = new StudentBAL();
            List<StudentDTO> listStudentDtos = stdbal.GetBL();
            return View(listStudentDtos.SingleOrDefault(e=>e.StudentID==id));
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                StudentBAL stdbal= new StudentBAL();
                stdbal.DeleteBL(new StudentDTO{StudentID = id});

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
