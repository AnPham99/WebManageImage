using Contracts;
using Entities.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryryRepository _categoryRepository;
        public CategoryService(ICategoryryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges)
        {
            return await _categoryRepository.GetAllCategoriesAsync(trackChanges);
        }

        public async Task<Category> GetCategoryByIdAsync(int categoryId, bool trackChanges)
        {
            return await _categoryRepository.GetCategoryByIdAsync(categoryId, trackChanges);
        }
    }
}
