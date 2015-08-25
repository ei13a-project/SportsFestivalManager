using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFestivalManager.Data
{
    [Table("Festivals")]
    public class Festival
    {
        [Key, Column("FestivalId")]
        public Guid Id { get; private set; }

        [Column(TypeName = "date"), Index(IsUnique = true)]
        public DateTime Date { get; private set; }

        public Festival(DateTime date)
            : this()
        {
            Date = date;
        }
        private Festival()
        {
            Id = Guid.NewGuid();
        }
    }
}
