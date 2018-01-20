using System;
using System.Threading;

namespace BankManagement.Models
{
    public class Customer 
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }

        public DateTime  DayOfBirth { get; set; }

        public int PinCode { get; set; }

        public string PhoneNumber { get; set; }

        private static int counter = 0;

        private static int code = 1000;

        public Customer(string firstname, string lastname, string address, DateTime dayofbirth, string phonenumber)
        {
            this.Id = Interlocked.Increment(ref counter);
            this.PinCode = Interlocked.Increment(ref code);

            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Address = address;
            this.DayOfBirth = dayofbirth;
            this.PhoneNumber = phonenumber;
        }

    }
}
