using ExaminationSubscriberV2.Data;
using ExaminationSubscriberV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExaminationSubscriberV2.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly IRepository<Participant> participantRepository;

        public ParticipantService(IRepository<Participant> participantRepository)
        {
            this.participantRepository = participantRepository;
        }

        public async Task AddAsync(Participant participant)
        {
            await participantRepository.AddAsync(participant);
        }

        public async Task<List<Participant>> GetAllParticipants()
        {
            return await participantRepository.GetAllAsync();
        }

        public async Task<Participant> GetAsync(Participant participant)
        {
            return await participantRepository.Get(participant);
        }

        public async Task UpdateAsync(Participant participant)
        {
            await participantRepository.UpdateAsync(participant);
        }

        public async Task DeleteAsync(Participant participant)
        {
            await participantRepository.DeleteAsync(participant);
        }
    }
}
