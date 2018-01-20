using System;
using System.Threading;

namespace BankManagement.Models
{
    public class BankAccount 
    {
        public int Id { get; set; }

        public double Balance { get; set; }
        
        public int CustomerId { get; set; }

        public Customer Costumer { get; set; }

        public DateTime Created { get; set; }

        public int PinCode { get; set; }

        private static int counter = 1000;

        public BankAccount(int customer_id, int code)
        {
            this.Id = Interlocked.Increment(ref counter);

            this.PinCode = code;
            this.Balance = 0.00;
            this.CustomerId = customer_id;
            this.Created = DateTime.Now;
        }


    }
}
