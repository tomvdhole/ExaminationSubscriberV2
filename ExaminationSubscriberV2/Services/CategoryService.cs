using ExaminationSubscriberV2.Data;
using ExaminationSubscriberV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExaminationSubscriberV2.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly IRepository<Category> categoryRepository;

        public CategoryService(IRepository<Category> repository)
        {
            categoryRepository = repository;
        }

        public async Task AddCategoryAsync(Category category)
        {
            await categoryRepository.AddAsync(category);
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await categoryRepository.GetAllAsync();
        }

        public async Task<Category> GetCategoryAsync(Category category)
        {
            return await categoryRepository.Get(category);
        }
    }
}
