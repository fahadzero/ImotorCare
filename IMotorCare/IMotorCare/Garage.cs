using System;
using System.Collections.Generic;
using System.Text;

namespace IMotorCare
{
    public class Person
    {
        public string id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string longitude { get; set; }
        public string lattitude { get; set; }
        public string garage_name { get; set; }
        public string garage_address { get; set; }
        public string speciality { get; set; }
        public string contact { get; set; }
        public string type { get; set; }
        public string byte_image { get; set; }
    }
    public class Data
    {
        public List<Person> People { get; set; }
        public string Message { get; set; }
    }

    public class Garage
    {
        public int status { get; set; }
        public string status_message { get; set; }
        public Data Data { get; set; }
    }
}
