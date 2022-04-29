using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gartencenter.Model
{
    public class Lieferant
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Country { get; set; }
        public ICollection<Lieferung> Lieferungen { get; set; }
    }
}
