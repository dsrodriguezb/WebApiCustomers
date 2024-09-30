using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace WebApiCustomers.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [StringLength(100)] 
        public required string Name { get; set; }
        [StringLength(255)] 
        public required string Address { get; set; }
        [Range(0, 110)]
        public required int Age { get; set; }
        [StringLength(15)] 
        public required string Phone { get; set; }
        public DateTime CreationDate { get; set; }
        [EmailAddress]
        [StringLength(256)]
        public required string Email { get; set; }
        public bool Active { get; set; }
        public int Status { get; set; }

    }
    public record customerDto (string Name, string Address, int Age, string Phone, string Email);
}
