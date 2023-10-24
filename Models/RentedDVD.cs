using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EZTech.Models
{
    public class RentedDVD
    {
        public int RentedDVDID { get; set; }

        [Required(ErrorMessage = "Rental date is required.")]
        [DataType(DataType.Date)]
        public DateTime RentalDate { get; set; }

        [Required(ErrorMessage = "Return date is required.")]
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }

        // Navigation properties
        public int CustomerID { get; set; } // Foreign key to Customer
        public int DVDPlanID { get; set; } // Foreign key to DVDPlan

        public virtual Customer Customer { get; set; } // Navigation property to Customer
        public virtual DVDPlan DVDPlan { get; set; }
    }
}