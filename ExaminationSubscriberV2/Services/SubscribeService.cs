
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExaminationSubscriberV2.Models;

namespace ExaminationSubscriberV2.Services
{
    public class SubscribeService : ISubscribeService
    {
        private readonly IParticipantService participantService;
        private readonly ICategoryService categoryService;

        public SubscribeService(IParticipantService _participantService,
                                ICategoryService _categoryService)
        {
            participantService = _participantService;
            categoryService = _categoryService;
        }

        public async Task Subscribe(Participant participant)
        {
            await DefineCategory(participant);
            await SaveCategoryToParticipant(participant);
        }

        public async Task UpdateSubscription(Participant participant)
        {
            await DefineCategory(participant);
            await UpdateCategoryToParticipant(participant);
        }

        #region Private Methods
        private async Task DefineCategory(Participant participant)
        {
            await DefineCategoriesForKids(participant);
            await DefineCategoriesForYouth(participant);
            await DefineCategoriesForBeginners(participant);
            await DefineCategoriesForAdvanced(participant);
        }

        private async Task SaveCategoryToParticipant(Participant participant)
        {
            await participantService.AddAsync(participant);
        }

        private async Task UpdateCategoryToParticipant(Participant participant)
        {
            await participantService.UpdateAsync(participant);
        }

        private async Task DefineCategoriesForKids(Participant participant)
        {
            if (participant.Age == 7 && (participant.NumberOfRedRibbons == "0" || participant.NumberOfRedRibbons == "1"))
            {
                if (participant.NumberOfRedRibbons == "0")
                {
                    Category category = await categoryService.GetCategoryAsync(new Category { TypeOfParticipants = "Kids", ExaminationType = "Form" });
                    participant.Category = category;
                }

                if (participant.NumberOfRedRibbons == "1")
                {
                    Category category = await categoryService.GetCategoryAsync(new Category { TypeOfParticipants = "Kids", ExaminationType = "Rhytm" });
                    participant.Category = category;
                }
            }

            if ((participant.Age >= 8 && participant.Age < 11) &&
               (participant.Grade == "0e Kyu" ||
                participant.Grade == "9e Kyu" ||
                participant.Grade == "8e Kyu" ||
                participant.Grade == "7e Kyu" ||
                participant.Grade == "6e Kyu"))
            {
                if (participant.NumberOfRedRibbons == "0")
                {
                    Category category = await categoryService.GetCategoryAsync(new Category { TypeOfParticipants = "Kids", ExaminationType = "Form" });
                    participant.Category = category;
                }

                if (participant.NumberOfRedRibbons == "1")
                {
                    Category category = await categoryService.GetCategoryAsync(new Category { TypeOfParticipants = "Kids", ExaminationType = "Rhytm" });
                    participant.Category = category;
                }

                if (participant.NumberOfRedRibbons == "2")
                {
                    Category category = await categoryService.GetCategoryAsync(new Category { TypeOfParticipants = "Kids", ExaminationType = "Official" });
                    participant.Category = category;
                }
            }
        }

        private async Task DefineCategoriesForYouth(Participant participant)
        {
            if ((participant.Age >= 11 && participant.Age < 14) &&
               (participant.Grade == "0e Kyu" ||
                participant.Grade == "9e Kyu" ||
                participant.Grade == "8e Kyu" ||
                participant.Grade == "7e Kyu" ||
                participant.Grade == "6e Kyu"))
            {
                if (participant.NumberOfRedRibbons == "0")
                {
                    Category category = await categoryService.GetCategoryAsync(new Category { TypeOfParticipants = "Youth", ExaminationType = "Form" });
                    participant.Category = category;
                }

                if (participant.NumberOfRedRibbons == "1")
                {
                    Category category = await categoryService.GetCategoryAsync(new Category { TypeOfParticipants = "Youth", ExaminationType = "Rhytm" });
                    participant.Category = category;
                }

                if (participant.NumberOfRedRibbons == "2")
                {
                    Category category = await categoryService.GetCategoryAsync(new Category { TypeOfParticipants = "Youth", ExaminationType = "Official" });
                    participant.Category = category;
                }
            }
        }

        private async Task DefineCategoriesForBeginners(Participant participant)
        {
            if ((participant.Age >= 14) &&
               (participant.Grade == "0e Kyu" ||
                participant.Grade == "9e Kyu" ||
                participant.Grade == "8e Kyu" ||
                participant.Grade == "7e Kyu" ||
                participant.Grade == "6e Kyu"))
            {
                if (participant.NumberOfRedRibbons == "0")
                {
                    Category category = await categoryService.GetCategoryAsync(new Category { TypeOfParticipants = "Beginners", ExaminationType = "Form" });
                    participant.Category = category;
                }

                if (participant.NumberOfRedRibbons == "1")
                {
                    Category category = await categoryService.GetCategoryAsync(new Category { TypeOfParticipants = "Beginners", ExaminationType = "Rhytm" });
                    participant.Category = category;
                }

                if (participant.NumberOfRedRibbons == "2")
                {
                    Category category = await categoryService.GetCategoryAsync(new Category { TypeOfParticipants = "Beginners", ExaminationType = "Official" });
                    participant.Category = category;
                }
            }
        }

        private async Task DefineCategoriesForAdvanced(Participant participant)
        {
                if (participant.Grade == "5e Kyu" || participant.Grade == "4e Kyu" || participant.Grade == "3e Kyu" || participant.Grade == "2e Kyu")
                {
                    if (participant.NumberOfRedRibbons == "0")
                    {
                        Category category = await categoryService.GetCategoryAsync(new Category { TypeOfParticipants = "Advanced", ExaminationType = "Form" });
                        participant.Category = category;
                    }

                    if (participant.NumberOfRedRibbons == "1")
                    {
                        Category category = await categoryService.GetCategoryAsync(new Category { TypeOfParticipants = "Advanced", ExaminationType = "Rhytm" });
                        participant.Category = category;
                    }

                    if (participant.NumberOfRedRibbons == "2")
                    {
                        Category category = await categoryService.GetCategoryAsync(new Category { TypeOfParticipants = "Advanced", ExaminationType = "Official" });
                        participant.Category = category;
                    }
                }
            }
        #endregion
    }
}
