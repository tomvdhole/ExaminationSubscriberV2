using ExaminationSubscriberV2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExaminationSubscriberV2.Data
{
    public class ParticipantRepository : IRepository<Participant>
    {
        private readonly ExaminationSubscriberV2Context context;

        public ParticipantRepository(ExaminationSubscriberV2Context _context)
        {
            context = _context;
        }

        public async Task AddAsync(Participant entity)
        {
            await context.Participant.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Participant entity)
        {
            context.Participant.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<Participant> Get(Participant entity)
        {
            return await context.Participant.FirstOrDefaultAsync<Participant>(p => p.Id == entity.Id);
        }

        public async Task<Participant> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Participant>> GetAllAsync()
        {
            return await context.Participant.ToListAsync<Participant>();
        }

        public async Task UpdateAsync(Participant entity)
        {
            Participant origParticipant = await context.Participant.AsNoTracking<Participant>().SingleOrDefaultAsync(c => c.Id == entity.Id);
            context.Entry<Participant>(origParticipant).Context.Update<Participant>(entity);
            context.SaveChanges();
        }
    }
}
