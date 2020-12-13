using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    [Authorize]
    public class TodolistsController : Controller
    {
        private TodolistsContext db = new TodolistsContext();

        // GET: Todolists
        public ActionResult Index()
        {
            return View(db.Todolists.ToList());
        }

        // GET: Todolists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todolist todolist = db.Todolists.Find(id);
            if (todolist == null)
            {
                return HttpNotFound();
            }
            return View(todolist);
        }

        // GET: Todolists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Todolists/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Task,LimitDate,Priority,Done")] Todolist todolist)
        {
            if (ModelState.IsValid)
            {
                db.Todolists.Add(todolist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(todolist);
        }

        // GET: Todolists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todolist todolist = db.Todolists.Find(id);
            if (todolist == null)
            {
                return HttpNotFound();
            }
            return View(todolist);
        }

        // POST: Todolists/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Task,LimitDate,Priority,Done")] Todolist todolist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(todolist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todolist);
        }

        // GET: Todolists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todolist todolist = db.Todolists.Find(id);
            if (todolist == null)
            {
                return HttpNotFound();
            }
            return View(todolist);
        }

        // POST: Todolists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Todolist todolist = db.Todolists.Find(id);
            db.Todolists.Remove(todolist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Admin()
        {
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult SignOut()
        {
            return RedirectToAction("SignOut", "Login");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
