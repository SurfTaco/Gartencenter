using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gartencenter.Model
{
    public class Article
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public ICollection<Lieferung> Lieferungen { get; set; }

    }
}
