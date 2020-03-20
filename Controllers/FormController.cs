using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAL;
using DTO;
using MVCRegistationForm.ViewModels;

namespace MVCRegistationForm.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        public ActionResult Index()
        {
            StudentBAL stdbal = new StudentBAL();
            FormIndexViewModel fivm = new FormIndexViewModel
            {
                studentDto = new StudentDTO(),
                ListStudentDto = stdbal.GetBL()
            };
            return View(fivm);
        }

        public ActionResult Create(FormCollection collection)
        {
            StudentBAL stdbal = new StudentBAL();

            stdbal.AddBL(new StudentDTO
            {
                FirstName = collection["studentDto.FirstName"],
                LastName = collection["studentDto.LastName"],
                EmailID = collection["studentDto.EmailID"],
                PhoneNumber = Convert.ToInt64(collection["studentDto.PhoneNumber"]),
                Gender = collection["studentDto.Gender"],
                State = collection["studentDto.State"],
                Country = collection["studentDto.Country"]
        });

            return RedirectToAction("Index");
        }

        public ActionResult Update(FormCollection collection)
        {
            StudentBAL stdbal =new StudentBAL();
            stdbal.UpdateBL(new StudentDTO
            {
                StudentID =Convert.ToInt32(collection["studentDto.StudentID"]),
                FirstName = collection["studentDto.FirstName"],
                LastName = collection["studentDto.LastName"],
                EmailID = collection["studentDto.EmailID"],
                PhoneNumber = Convert.ToInt64(collection["studentDto.PhoneNumber"]),
                Gender = collection["studentDto.Gender"],
                State = collection["studentDto.State"],
                Country = collection["studentDto.Country"]
            });
            return RedirectToAction("Index");
        }

        public ActionResult Delete(FormCollection collection)
        {
            StudentBAL stdbal=new StudentBAL();
            stdbal.DeleteBL(new StudentDTO
            {
                StudentID = Convert.ToInt32(collection["studentDto.StudentID"])
            });

            return RedirectToAction("Index");
        }


    }
}