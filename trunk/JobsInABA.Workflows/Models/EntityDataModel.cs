using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace JobsInABA.Workflows.Models
{
    public class PhoneWorkFlows
    {
        public int PhoneID { get; set; }
        public Nullable<int> CountryID { get; set; }
        public string Number { get; set; }
        public string Ext { get; set; }
        public Nullable<int> PhoneTypeID { get; set; }
    }
}
