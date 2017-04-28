using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VestHQDataModels;
using VestHQBusinessLib;

namespace VestHQWeb.Controllers
{
    public class EmployeeSurveyResponseController : Controller
    {
        //private VestHQDbContext db = new VestHQDbContext();


        // GET: EmployeeSurveyResponse
        public async Task<ActionResult> Index()
        {
            //var employeeSurveyResponses = db.EmployeeSurveyResponses.Include(e => e.Employee).Include(e => e.SurveyQuestion);
            var employeeSurveyResponses = EmployeeSurveyResponseLib.GetAllEmployeeSurveyResponses();
            return View(await employeeSurveyResponses);
        }

        // GET: EmployeeSurveyResponse/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeSurveyResponse employeeSurveyResponse = await EmployeeSurveyResponseLib.GetEmployeeSurveyResponse(id);
            //EmployeeSurveyResponse employeeSurveyResponse = await db.EmployeeSurveyResponses.FindAsync(id);
            if (employeeSurveyResponse == null)
            {
                return HttpNotFound();
            }
            return View(employeeSurveyResponse);
        }

        // GET: EmployeeSurveyResponse/Create
        public async Task<ActionResult> Create()
        {
            var employees = await EmployeerLib.GetAllEmployees();
            var surveyQuestions = await SurveyQuestionLib.GetAllSurveyQuestions();
            ViewBag.EmployeeId = new SelectList(employees, "Id", "FullName");
            ViewBag.SurveyQuestionId = new SelectList(surveyQuestions, "Id", "Text");

            //ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FirstName");
            //ViewBag.SurveyQuestionId = new SelectList(db.SurveyQuestions, "Id", "Text");
            return View();
        }

        // POST: EmployeeSurveyResponse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,EmployeeId,SurveyQuestionId,Answer")] EmployeeSurveyResponse employeeSurveyResponse)
        {
            if (ModelState.IsValid)
            {
                await EmployeeSurveyResponseLib.InsertEmployeeSurveyResponse(employeeSurveyResponse);
                //db.EmployeeSurveyResponses.Add(employeeSurveyResponse);
                //await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            var employees = await EmployeerLib.GetAllEmployees();
            var surveyQuestions = await SurveyQuestionLib.GetAllSurveyQuestions();
            ViewBag.EmployeeId = new SelectList(employees, "Id", "FullName", employeeSurveyResponse.EmployeeId);
            ViewBag.SurveyQuestionId = new SelectList(surveyQuestions, "Id", "Text", employeeSurveyResponse.SurveyQuestionId);
            return View(employeeSurveyResponse);
        }

        // GET: EmployeeSurveyResponse/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeSurveyResponse employeeSurveyResponse = await EmployeeSurveyResponseLib.GetEmployeeSurveyResponse(id);

            //EmployeeSurveyResponse employeeSurveyResponse = await db.EmployeeSurveyResponses.FindAsync(id);
            if (employeeSurveyResponse == null)
            {
                return HttpNotFound();
            }
            var employees = await EmployeerLib.GetAllEmployees();
            var surveyQuestions = await SurveyQuestionLib.GetAllSurveyQuestions();
            ViewBag.EmployeeId = new SelectList(employees, "Id", "FullName", employeeSurveyResponse.EmployeeId);
            ViewBag.SurveyQuestionId = new SelectList(surveyQuestions, "Id", "Text", employeeSurveyResponse.SurveyQuestionId);

            //ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FirstName", employeeSurveyResponse.EmployeeId);
            //ViewBag.SurveyQuestionId = new SelectList(db.SurveyQuestions, "Id", "Text", employeeSurveyResponse.SurveyQuestionId);
            return View(employeeSurveyResponse);
        }

        // POST: EmployeeSurveyResponse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,EmployeeId,SurveyQuestionId,Answer")] EmployeeSurveyResponse employeeSurveyResponse)
        {
            if (ModelState.IsValid)
            {
                await EmployeeSurveyResponseLib.UpdateEmployeeSurveyResponse(employeeSurveyResponse);
                //db.Entry(employeeSurveyResponse).State = EntityState.Modified;
                //await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            var employees = await EmployeerLib.GetAllEmployees();
            var surveyQuestions = await SurveyQuestionLib.GetAllSurveyQuestions();
            ViewBag.EmployeeId = new SelectList(employees, "Id", "FirstName", employeeSurveyResponse.EmployeeId);
            ViewBag.SurveyQuestionId = new SelectList(surveyQuestions, "Id", "Text", employeeSurveyResponse.SurveyQuestionId);
            //ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FirstName", employeeSurveyResponse.EmployeeId);
            //ViewBag.SurveyQuestionId = new SelectList(db.SurveyQuestions, "Id", "Text", employeeSurveyResponse.SurveyQuestionId);
            return View(employeeSurveyResponse);
        }

        // GET: EmployeeSurveyResponse/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeSurveyResponse employeeSurveyResponse = await EmployeeSurveyResponseLib.GetEmployeeSurveyResponse(id);

            //EmployeeSurveyResponse employeeSurveyResponse = await db.EmployeeSurveyResponses.FindAsync(id);
            if (employeeSurveyResponse == null)
            {
                return HttpNotFound();
            }
            return View(employeeSurveyResponse);
        }

        // POST: EmployeeSurveyResponse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            await EmployeeSurveyResponseLib.DeleteEmployeeSurveyResponse(id);

            //EmployeeSurveyResponse employeeSurveyResponse = await db.EmployeeSurveyResponses.FindAsync(id);
            //db.EmployeeSurveyResponses.Remove(employeeSurveyResponse);
            //await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
