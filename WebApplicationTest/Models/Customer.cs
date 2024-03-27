using System.ComponentModel.DataAnnotations;

namespace WebApplicationTest.Models
{
    public class Customer
    {
         
        public int Id { get; set; }

        public string CustomerName { get; set; } = "";
        public string CustomerAddress { get; set; } = "";
        public string CustomerEmail { get; set; } = "";

    }
}
