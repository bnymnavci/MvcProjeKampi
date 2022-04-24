﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var headingValues = headingManager.GetList();
            return View(headingValues);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value=x.CategoryId.ToString()
                                                  }).ToList();
            List<SelectListItem> valueWriter = (from x in writerManager.GetList()
                                                select new SelectListItem
                                                {
                                                    Text=x.WriterName + " "+ x.WriterSurname,
                                                    Value=x.WriterId.ToString()
                                                }).ToList();
            ViewBag.categoryValues = valueCategory;
            ViewBag.writerValues = valueWriter;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate =DateTime.Parse( DateTime.Now.ToShortDateString());
            headingManager.AddHeading(heading);
            return RedirectToAction("Index");
        }
    }
}