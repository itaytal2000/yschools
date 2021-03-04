using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Candy
    {
        [Key]
        public int caId { get; set; }
        public string caName { get; set; }
        public string caImage { get; set; }
        public DateTime createdDate { get; set; }
        public bool enabled { get; set; }

    }
}
