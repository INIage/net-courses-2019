using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7.Core.Dto
{
    public class TraderToRemove
    {
        [Required]
        public int TraderId { get; set; }
    }
}
