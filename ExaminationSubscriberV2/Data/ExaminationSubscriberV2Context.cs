using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExaminationSubscriberV2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSubscriberV2.Data
{
    public class ExaminationSubscriberV2Context : IdentityDbContext<ApplicationUser>
    {
        public ExaminationSubscriberV2Context(DbContextOptions<ExaminationSubscriberV2Context> options)
            : base(options)
        {
        }

        public DbSet<Participant> Participant { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
