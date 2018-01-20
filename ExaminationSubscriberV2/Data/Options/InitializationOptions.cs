using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExaminationSubscriberV2.Data.Options
{
    public class InitializationOptions
    {
        public string[] UserNames { get; set; }
        public string[] PassWords { get; set; }
        public string[] Roles { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
    }
}