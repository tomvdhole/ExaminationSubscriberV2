using ExaminationSubscriberV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExaminationSubscriberV2.Services
{
    public interface IParticipantService
    {
        Task<List<Participant>> GetAllParticipants();
        Task AddAsync(Participant participant);
        Task<Participant> GetAsync(Participant participant);
        Task UpdateAsync(Participant participant);
        Task DeleteAsync(Participant participant);
    }
}
