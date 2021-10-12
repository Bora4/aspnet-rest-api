using System;

namespace DoktorSelector.Models
{
    public class DoktorItem { 

        public DoktorItem(int myid, string myphonenumber, string myname, string mysurname, string myspecialty, string myhospital)
        {
            id = myid;
            phonenumber = myphonenumber;
            name = myname;
            surname = mysurname;
            specialty = myspecialty;
            hospital = myhospital;

        }

        public int id { get; set; }
        public string phonenumber { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string specialty { get; set; }
        public string hospital { get; set; }
    }
}
