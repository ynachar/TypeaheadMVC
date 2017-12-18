using System;

namespace TypeAheadControl.Models
{
    public class Patient
    {
        public Int64 Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public string PhoneNumber { get; set; }
        public string InputString { get; set; }
    }
}