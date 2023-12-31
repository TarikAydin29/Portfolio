﻿using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    public class PortfolioController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();

        // GET: Portfolio
        public ActionResult Index()
        {
            var items = db.TblSkills.ToList();
            ViewBag.skillsArray = items.Select(x => x.Name).ToArray();
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFeature()
        {
            ViewBag.featureTitle = db.TblFeature.Select(x => x.FeatureTitle).FirstOrDefault();
            ViewBag.featureDescription = db.TblFeature.Select(x => x.FeatureDescription).FirstOrDefault();
            ViewBag.featureImage = db.TblFeature.Select(x => x.FeatureImageUrl).FirstOrDefault();
            ViewBag.featureSkills = db.TblSkills.ToList();
            return PartialView();
        }
        public PartialViewResult MyResume()
        {
            var values = db.TblResume.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialStatistics()
        {
            ViewBag.totalService = db.TblService.Count();
            ViewBag.totalMessage = db.TblMessage.Count();
            ViewBag.totalThanksMessage = db.TblMessage.Where(x => x.MessageSubject.Contains("Teşekkür")).Count();
            ViewBag.happyCustomer = 12;
            return PartialView();
        }
        public PartialViewResult PartialSelfInfo()
        {
            List<TblReference> r= db.TblReference.ToList();
            return PartialView(r);
        }
        public PartialViewResult PartialVideo()
        {
            return PartialView();
        }
        public PartialViewResult PartialProjects()
        {
            var projects = db.TblProject.ToList();
            return PartialView(projects);
        }
        public PartialViewResult PartialReferences()
        {
            List<TblReference> r = db.TblReference.ToList();
            return PartialView(r);
        }
    }
}