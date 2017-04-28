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
    public class SurveyQuestionController : Controller
    {
        private VestHQDbContext db = new VestHQDbContext();

        // GET: SurveyQuestion
        public async Task<ActionResult> Index()
        {
            return View(await db.SurveyQuestions.ToListAsync());
        }

        // GET: SurveyQuestion/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyQuestion surveyQuestion = await db.SurveyQuestions.FindAsync(id);
            if (surveyQuestion == null)
            {
                return HttpNotFound();
            }
            return View(surveyQuestion);
        }

        // GET: SurveyQuestion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SurveyQuestion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Text,Order")] SurveyQuestion surveyQuestion)
        {
            if (ModelState.IsValid)
            {
                db.SurveyQuestions.Add(surveyQuestion);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(surveyQuestion);
        }

        // GET: SurveyQuestion/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyQuestion surveyQuestion = await db.SurveyQuestions.FindAsync(id);
            if (surveyQuestion == null)
            {
                return HttpNotFound();
            }
            return View(surveyQuestion);
        }

        // POST: SurveyQuestion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Text,Order")] SurveyQuestion surveyQuestion)
        {
            if (ModelState.IsValid)
            {
                await SurveyQuestionLib.UpdateSurveyQuestion(surveyQuestion);
                //db.Entry(surveyQuestion).State = EntityState.Modified;
                //await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(surveyQuestion);
        }

        // GET: SurveyQuestion/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyQuestion surveyQuestion = await SurveyQuestionLib.GetSurveyQuestion(id);
            //SurveyQuestion surveyQuestion = await db.SurveyQuestions.FindAsync(id);
            if (surveyQuestion == null)
            {
                return HttpNotFound();
            }
            return View(surveyQuestion);
        }

        // POST: SurveyQuestion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            SurveyQuestion surveyQuestion = await SurveyQuestionLib.DeleteSurveyQuestion(id);
            //SurveyQuestion surveyQuestion = await db.SurveyQuestions.FindAsync(id);
            //db.SurveyQuestions.Remove(surveyQuestion);
            //await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
