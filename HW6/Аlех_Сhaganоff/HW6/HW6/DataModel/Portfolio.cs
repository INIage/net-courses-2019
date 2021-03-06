using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6.DataModel
{
    public class Portfolio
    {
        [Key] [Column(Order = 0)]
        public int TraderID { get; set; }
        [Key] [Column(Order = 1)]
        public int ShareId { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
