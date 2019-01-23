using AutoMapper;
using Store.Model;
using Store.Service;
using Store.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Store.Model.Models;

namespace Store.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IGadgetService _gadgetService;

        public HomeController(ICategoryService categoryService, IGadgetService gadgetService)
        {
            _categoryService = categoryService;
            _gadgetService = gadgetService;
        }

        // GET: Home
        public ActionResult Index(string category = null)
        {
            IEnumerable<CategoryViewModel> viewModelGadgets;
            IEnumerable<Category> categories;

            categories = _categoryService.GetCategories(category).ToList();

            viewModelGadgets = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);
            return View(viewModelGadgets);
        }

        public ActionResult Filter(string category, string gadgetName)
        {
            IEnumerable<GadgetViewModel> viewModelGadgets;
            IEnumerable<Gadget> gadgets;

            gadgets = _gadgetService.GetCategoryGadgets(category, gadgetName);

            viewModelGadgets = Mapper.Map<IEnumerable<Gadget>, IEnumerable<GadgetViewModel>>(gadgets);

            return View(viewModelGadgets);
        }

        [HttpPost]
        public ActionResult Create(GadgetFormViewModel newGadget)
        {
            if (newGadget != null && newGadget.File != null)
            {
                var gadget = Mapper.Map<GadgetFormViewModel, Gadget>(newGadget);
                _gadgetService.CreateGadget(gadget);

                string gadgetPicture = System.IO.Path.GetFileName(newGadget.File.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/images/"), gadgetPicture);
                newGadget.File.SaveAs(path);

                _gadgetService.SaveGadget();
            }

            var category = _categoryService.GetCategory(newGadget.GadgetCategory);
            return RedirectToAction("Index", new { category = category.Name });
        }
    }
}