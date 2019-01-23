using Store.Data.Infrastructure;
using Store.Data.Repositories;
using Store.Model;
using System.Collections.Generic;
using System.Linq;

namespace Store.Service
{
    // operations you want to expose
    public interface IGadgetService
    {
        IEnumerable<Gadget> GetGadgets();
        IEnumerable<Gadget> GetCategoryGadgets(string categoryName, string gadgetName = null);
        Gadget GetGadget(int id);
        void CreateGadget(Gadget gadget);
        void SaveGadget();
    }

    public class GadgetService : IGadgetService
    {
        private readonly IGadgetRepository _gadgetsRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GadgetService(IGadgetRepository gadgetsRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _gadgetsRepository = gadgetsRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        #region IGadgetService Members

        public IEnumerable<Gadget> GetGadgets()
        {
            var gadgets = _gadgetsRepository.GetAll();
            return gadgets;
        }

        public IEnumerable<Gadget> GetCategoryGadgets(string categoryName, string gadgetName = null)
        {
            var category = _categoryRepository.GetCategoryByName(categoryName);
            return category.Gadgets.Where(g => g.Name.ToLower().Contains(gadgetName.ToLower().Trim()));
        }

        public Gadget GetGadget(int id)
        {
            var gadget = _gadgetsRepository.GetById(id);
            return gadget;
        }

        public void CreateGadget(Gadget gadget)
        {
            _gadgetsRepository.Add(gadget);
        }

        public void SaveGadget()
        {
            _unitOfWork.Commit();
        }

        #endregion
    
    }
}
