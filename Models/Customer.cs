using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EZTech.Models
{
    public class Customer
    {
        public Customer()
        {
            CustomerPlans = new List<CustomerPlan>();
        }

        public int CustomerID { get; set; }

        [Required(ErrorMessage = "User name is required.")]
        [StringLength(50, ErrorMessage = "User name cannot exceed 50 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, ErrorMessage = "Password cannot exceed 100 characters.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        public string Email { get; set; }

        // Define a navigation property for CustomerPlans
        public virtual ICollection<CustomerPlan> CustomerPlans { get; set; }
        public int MaxDevices { get; set; }
        public decimal SubscriptionPrice { get; set; }
    }
}
