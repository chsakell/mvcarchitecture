using Store.Data.Infrastructure;
using Store.Data.Repositories;
using System.Collections.Generic;
using System.Linq;
using Store.Model.Models;

namespace Store.Service
{
    // operations you want to expose
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories(string name = null);
        Category GetCategory(int id);
        Category GetCategory(string name);
        void CreateCategory(Category category);
        void SaveCategory();
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        #region ICategoryService Members

        public IEnumerable<Category> GetCategories(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return _categoryRepository.GetAll();
            else
                return _categoryRepository.GetAll().Where(c => c.Name == name);
        }

        public Category GetCategory(int id)
        {
            var category = _categoryRepository.GetById(id);
            return category;
        }

        public Category GetCategory(string name)
        {
            var category = _categoryRepository.GetCategoryByName(name);
            return category;
        }

        public void CreateCategory(Category category)
        {
            _categoryRepository.Add(category);
        }

        public void SaveCategory()
        {
            _unitOfWork.Commit();
        }

        #endregion
    }
}
