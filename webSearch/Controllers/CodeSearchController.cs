using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webSearch.Models;
using webSearch.Services;

namespace webSearch.Controllers
{
    public class CodeSearchController : Controller
    {
        // GET: CodeSearch
        private readonly CodeSearchService _codeSearchService;

        public CodeSearchController()
        {
            _codeSearchService = new CodeSearchService();
        }

        [HttpGet]
        public ActionResult Index()
        {
            CodeSearchViewModel model =
                new CodeSearchViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Search(CodeSearchViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.FolderPath))
            {
                ModelState.AddModelError(
                    "FolderPath",
                    "Please enter a folder path.");

                return View("Index", model);
            }

            if (string.IsNullOrWhiteSpace(model.SearchPattern))
            {
                ModelState.AddModelError(
                    "SearchPattern",
                    "Please enter a search pattern.");

                return View("Index", model);
            }

            model.Results = _codeSearchService.Search(
                model.FolderPath,
                model.SearchPattern);

            return View("Index", model);
        }
    }
}