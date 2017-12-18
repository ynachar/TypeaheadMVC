using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using TypeAheadControl.Models;

namespace TypeAheadControl.Controllers
{
    public class HomeController : Controller
    {   
        [HttpGet]
        public ActionResult Index()
        {
            ModelState.Clear();

            return View();
        }

        [HttpPost]
        public JsonResult Index(string userInput)
        {
            List<Patient> patients = GetPatientsData();

            if (!string.IsNullOrEmpty(userInput))
            {

                var filteredPatients = patients.Where(x => x.FirstName.Contains(userInput) || x.LastName.Contains(userInput))
                                            .Select(x => x)
                                            .ToList();

                return Json(filteredPatients, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null, JsonRequestBehavior.DenyGet);
            }
        }

        public List<Patient> GetPatientsData()
        {
            List<Patient> patients = new List<Patient>();

            //Read the contents of CSV file
            string filePath = Server.MapPath("~/Files/patients.csv").ToString();
            string csvData = System.IO.File.ReadAllText(filePath);
            Int64 val = 0;

            //Execute a loop over the rows.
            foreach (string row in csvData.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    try
                    {
                        val = Convert.ToInt64(row.Split(',')[0]);
                    }
                    catch
                    {
                        //First row - skip it
                        continue;
                    }
                    patients.Add(new Patient
                    {
                        Id = Convert.ToInt64(row.Split(',')[0]),
                        FirstName = row.Split(',')[1],
                        LastName = row.Split(',')[2],
                        DOB = row.Split(',')[3],
                        PhoneNumber = row.Split(',')[4]
                    });
                }
            }

            return patients;
        }
    }
}