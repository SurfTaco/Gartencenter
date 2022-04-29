using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gartencenter.Model
{
    public class Lieferung
    {
        public int Id { get; set; }
        [Required]
        public DateTime DayOfDelivery { get; set; }
        [Required]
        public int Amount { get; set; }

        public int ArticleID { get; set; }
        public Article Article { get; set; }

        public int LieferantId { get; set; }
        public Lieferant Lieferant { get; set; }
    }
}
