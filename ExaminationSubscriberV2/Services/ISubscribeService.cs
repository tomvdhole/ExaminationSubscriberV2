using ExaminationSubscriberV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExaminationSubscriberV2.Services
{
    public interface ISubscribeService
    {
        Task Subscribe(Participant participant);
        Task UpdateSubscription(Participant participant);
    }
}
