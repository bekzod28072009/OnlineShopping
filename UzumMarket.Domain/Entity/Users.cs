using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UzumMarket.Domain.Common;
using UzumMarket.Domain.Enums;

namespace UzumMarket.Domain.Entity
{
    public class Users : Auditable
    {
        public int UserId { get; set; }
        public string Username { get; set; } 
        public string Email { get; set; } 
        public string Password { get; set; } 
        public string FullName { get; set; } 
        public string Address { get; set; } 
        public string PhoneNumber { get; set; } 
        public string PaymentInformation { get; set; } 
        public List<Order> OrderHistory { get; set; } 
        public List<Item> ShoppingCart { get; set; } 
        public List<Item> Wishlist { get; set; } 
        public AccountStatus AccountStatus { get; set; } 
        public UserRole Role { get; set; } 
    }
}
