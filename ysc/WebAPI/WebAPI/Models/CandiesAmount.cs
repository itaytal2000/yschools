using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class CandiesAmount
    {
        [Key]
        public string caName { get; set; }
        public int amount { get; set; }
    }
}
