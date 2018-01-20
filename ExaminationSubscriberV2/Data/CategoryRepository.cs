using ExaminationSubscriberV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSubscriberV2.Data
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly ExaminationSubscriberV2Context examinationSubscriberV2Context;

        public CategoryRepository(ExaminationSubscriberV2Context context)
        {
            examinationSubscriberV2Context = context;
        }

        public async Task AddAsync(Category entity)
        {
            await examinationSubscriberV2Context.Category.AddAsync(entity);
            await examinationSubscriberV2Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> Get(Category entity)
        {
            return await examinationSubscriberV2Context.Category.Where<Category>(c => c.TypeOfParticipants == entity.TypeOfParticipants && c.ExaminationType == entity.ExaminationType).SingleOrDefaultAsync<Category>();
        }

        public async Task<Category> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await examinationSubscriberV2Context.Category.ToListAsync<Category>();
        }

        public async Task UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
