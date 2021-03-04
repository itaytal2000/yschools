using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Order
    {
        [Key]
        public int oId { get; set; }
        public int caId { get; set; }
        public int cuId { get; set; }
        public int amount { get; set; }
        public DateTime createdDate { get; set; }
        public bool enabled { get; set; }

    }
}
