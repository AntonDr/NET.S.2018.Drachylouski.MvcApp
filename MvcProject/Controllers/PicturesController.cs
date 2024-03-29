﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcProject.Data;
using MvcProject.Models;

namespace MvcProject.Controllers
{
    public class PicturesController : Controller
    {
        private PictureContext db = new PictureContext();

        // GET: Pictures
        public ActionResult Index()
        {
            return View(db.Pictures.ToList());
        }

        // GET: Pictures/Details/5
        //public ActionResult Details(int id)
        //{
        //    //if (id == null)
        //    //{
        //    //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    //}
        //    Picture picture = db.Pictures.Find(id);
        //    if (picture == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(picture);
        //}

        // GET: Pictures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pictures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PictureId,Content")] Picture picture,HttpPostedFileBase image)
        {
            if (image !=null)
            {
                picture.Content = new byte[image.ContentLength];
                image.InputStream.Read(picture.Content, 0, image.ContentLength);
            }

            db.Pictures.Add(picture);
            db.SaveChanges();
            //if (ModelState.IsValid)
            //{
            //    db.Pictures.Add(picture);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            return View(picture);
        }

        // GET: Pictures/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Picture picture = db.Pictures.Find(id);
        //    if (picture == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(picture);
        //}

        // POST: Pictures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "PictureId,Content")] Picture picture)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(picture).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(picture);
        //}

        //GET: Pictures/Delete/5
        public ActionResult Delete()
        {
            return View(db.Pictures.ToList());
        }

        [HttpPost]
        public ActionResult Delete(IEnumerable<int> picturesId)
        {
            foreach (var id in picturesId)
            {
                var picture = db.Pictures.Single(p => p.PictureId == id);
                db.Pictures.Remove(picture);
            }

            db.SaveChanges();
            return RedirectToAction("Delete");
        }

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    var picture = db.Pictures.Single(p => p.PictureId == id);
        //    db.Pictures.Remove(picture);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
