using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.CommonModel
{
   public class EmailDetails
    {
        public string emailFromAddress { get; set; }

        public string emailFromName { get; set; }

        public string emailToAddress { get; set; }

        public string emailToName { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
}
