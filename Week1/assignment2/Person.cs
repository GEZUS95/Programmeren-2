using System;
using System.Collections.Generic;
using System.Text;

namespace assignment2
{
    struct Person
    {
        public string FirstName;
        public string LastName;
        public GenderType Gender;
        public int Age;
        public string City;
    }

    public enum GenderType
    {
        Male, Female
    }
}
