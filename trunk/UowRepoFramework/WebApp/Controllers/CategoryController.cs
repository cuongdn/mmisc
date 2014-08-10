﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Model;
using Repository.Pattern.UnitOfWork;
using Service;

namespace WebApp.Controllers
{
    public class CategoryController : Controller
    {
        public IUnitOfWorkAsync UnitOfWork { get; set; }
        public ICategoryService CategoryService { get; set; }

        public CategoryController(IUnitOfWorkAsync unitOfWork, ICategoryService service)
        {
            UnitOfWork = unitOfWork;
            CategoryService = service;
        }

        // GET: Category
        public ActionResult Index()
        {
            return View(CategoryService.Query().Select());
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", data);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
