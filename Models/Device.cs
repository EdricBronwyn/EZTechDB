using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EZTech.Models
{
    public class Device
    {
        public int DeviceID { get; set; }

        [Required(ErrorMessage = "Device name is required.")]
        [StringLength(50, ErrorMessage = "Device name cannot exceed 50 characters.")]
        public string DeviceName { get; set; }

        [Required(ErrorMessage = "Device type is required.")]
        [StringLength(50, ErrorMessage = "Device type cannot exceed 50 characters.")]
        public string DeviceType { get; set; }
    }
}