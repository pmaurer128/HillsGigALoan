using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GigaLoan_Model
{
    [DataContract]
    public class DTO_College
    {
        [DataMember]
        public int CollegeID { get; set; }
        [DataMember]
        public string CollegeName { get; set; }
    }

    [DataContract]
    public class DTO_CORE_GigAlert
    {
        public DTO_CORE_GigAlert()
        { }

        [DataMember]
        public int AlertID { get; set; }
        [DataMember]
        public int ClientID { get; set; }
        [DataMember]
        public int TypeID { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Comment { get; set; }
        [DataMember]
        public double PaymentAmt { get; set; }
        [DataMember]
        public double Long { get; set; }
        [DataMember]
        public double Lat { get; set; }
        [DataMember]
        public DateTime DateCreated { get; set; }
        [DataMember]
        public bool Active { get; set; }
    }
}
