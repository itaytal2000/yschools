using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Customer
    {
        [Key]
        public int cuId { get; set; }
        public string cuName { get; set; }
        public string password { get; set; }
        public int usId { get; set; }
        public DateTime createdDate { get; set; }
        public bool enabled { get; set; }

    }
}
