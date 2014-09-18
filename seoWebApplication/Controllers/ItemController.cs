﻿using seoWebApplication.DAL;
using seoWebApplication.DocumentDbModels;
using seoWebApplication.DocumentDbServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace seoWebApplication.Controllers
{
    public class ItemController : Controller
    {
        public ActionResult Index()
        {
            var items = DocumentDBRepository.GetIncompleteItems();
            return View(items);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Item item)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository.CreateItemAsync(item);
                return RedirectToAction("Index");
            }
            return View(item);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository.UpdateItemAsync(item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Item item = (Item)DocumentDBRepository.GetItem(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }
    }
}