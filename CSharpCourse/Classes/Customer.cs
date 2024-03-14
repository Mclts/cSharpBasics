using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    internal class Customer
    {
        //Müşterinin özelliklerini tutmak için de propertylerden classlardan yararlanabiliyoruz

        //// field=Alan, tarla :)
        //public string FirstName;

        //Property=özellik
        public int Id { get; set; }
        public string FirstName { get; set; }
        public String LastName { get; set; }
        public string City { get; set; }
    }


    //private string _firstName;
    //public string FirstName
    ////Encapsualtion
    //{
    //    get { return "Mrs." + _firstName; }
    //    set { _firstName = value; }
    //}
}
