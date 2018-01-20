using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ExaminationSubscriberV2.Data.Options;
using Microsoft.Extensions.Options;
using ExaminationSubscriberV2.Services;
using ExaminationSubscriberV2.Models;
using System.Collections.Generic;

namespace ExaminationSubscriberV2.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            CreateOrUpdateDatabase(serviceProvider);
            await CreationOfRoles(serviceProvider);
            await CreationOfUsers(serviceProvider);
            await CreationOfCategories(serviceProvider);
        }

        #region Private Methods
        private static void CreateOrUpdateDatabase(IServiceProvider serviceProvider)
        {
            var examinationSubscriberV2Context = serviceProvider.GetRequiredService<ExaminationSubscriberV2Context>();
            examinationSubscriberV2Context.Database.Migrate();
        }

        private async static Task CreationOfRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            IOptions<InitializationOptions> optionsAccessor = serviceProvider.GetRequiredService<IOptions<InitializationOptions>>();
            InitializationOptions options = optionsAccessor.Value;

            foreach (var roleName in options.Roles)
            {
                var roleExists = await roleManager.RoleExistsAsync(roleName);
                if (!roleExists)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

        private async static Task CreationOfUsers(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            IOptions<InitializationOptions> optionsAccessor = serviceProvider.GetRequiredService<IOptions<InitializationOptions>>();
            InitializationOptions options = optionsAccessor.Value;

            int userCounter = -1;
            foreach (string user in options.UserNames)
            {
                userCounter++;
                var _user = await userManager.FindByNameAsync(user);
                if (_user == null)
                {
                    var appUser = new ApplicationUser
                    {
                        UserName = user
                    };
                    var creationOfUser = await userManager.CreateAsync(appUser, options.PassWords[userCounter]);
                    if (creationOfUser.Succeeded)
                    {
                        await userManager.AddToRoleAsync(appUser, options.Roles[userCounter]);
                    }
                }
            }
        }

        private async static Task CreationOfCategories(IServiceProvider serviceProvider)
        {
            var categoryService = serviceProvider.GetRequiredService<ICategoryService>();
            List<Category> categories =  await categoryService.GetAllCategoriesAsync();

            await CheckAndIfNecessaryAdd(new Category { TypeOfParticipants = "Kids", ExaminationType = "Form" }, categories, categoryService);
            await CheckAndIfNecessaryAdd(new Category { TypeOfParticipants = "Kids", ExaminationType = "Rhytm" }, categories, categoryService);
            await CheckAndIfNecessaryAdd(new Category { TypeOfParticipants = "Kids", ExaminationType = "Official" }, categories, categoryService);

            await CheckAndIfNecessaryAdd(new Category { TypeOfParticipants = "Youth", ExaminationType = "Form" }, categories, categoryService);
            await CheckAndIfNecessaryAdd(new Category { TypeOfParticipants = "Youth", ExaminationType = "Rhytm" }, categories, categoryService);
            await CheckAndIfNecessaryAdd(new Category { TypeOfParticipants = "Youth", ExaminationType = "Official" }, categories, categoryService);

            await CheckAndIfNecessaryAdd(new Category { TypeOfParticipants = "Beginners", ExaminationType = "Form" }, categories, categoryService);
            await CheckAndIfNecessaryAdd(new Category { TypeOfParticipants = "Beginners", ExaminationType = "Rhytm" }, categories, categoryService);
            await CheckAndIfNecessaryAdd(new Category { TypeOfParticipants = "Beginners", ExaminationType = "Official" }, categories, categoryService);

            await CheckAndIfNecessaryAdd(new Category { TypeOfParticipants = "Advanced", ExaminationType = "Form" }, categories, categoryService);
            await CheckAndIfNecessaryAdd(new Category { TypeOfParticipants = "Advanced", ExaminationType = "Rhytm" }, categories, categoryService);
            await CheckAndIfNecessaryAdd(new Category { TypeOfParticipants = "Advanced", ExaminationType = "Official" }, categories, categoryService);
        }

        private async static Task CheckAndIfNecessaryAdd(Category category, List<Category> categories, ICategoryService categoryService)
        {
            bool found = false;
            foreach(Category cat in categories)
            {
                if(category.TypeOfParticipants == cat.TypeOfParticipants &&
                   category.ExaminationType == cat.ExaminationType)
                {
                    found = true;
                }
            }

            if (found == false)
            {
                await categoryService.AddCategoryAsync(category);
            }
        }
        #endregion Private Methods
    }
}