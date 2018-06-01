using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL.Models;
using Web.Models;

namespace Web.Controllers
{
    public class StudentsController : Controller
    {


        // GET: Students
        public async Task<ActionResult> Index()
        {
            List<Student> students = new StudentRepository().GetAll().ToList();
            return View(students);
        }

        // GET: Students/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Student student = await new StudentRepository().FindBy(c => c.Id == id).FirstAsync();
            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Address")] Student student)
        {
            if (ModelState.IsValid)
            {
                StudentRepository studentRepository = new StudentRepository();
                studentRepository.Add(student);
                studentRepository.Save();

                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await new StudentRepository().FindBy(c => c.Id == id).FirstOrDefaultAsync();

            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Address")] Student student)
        {
            if (ModelState.IsValid)
            {
                StudentRepository studentRepository = new StudentRepository();
                studentRepository.Edit(student);
                studentRepository.Save();

                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await new StudentRepository().FindBy(c => c.Id == id).FirstOrDefaultAsync();
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            StudentRepository studentRepository = new StudentRepository();
            Student student = await studentRepository.FindBy(c => c.Id == id).FirstOrDefaultAsync();
            studentRepository.Delete(student);
            studentRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    base.Dispose();
            //}
            //base.Dispose(disposing);
        }
    }
}
