using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace SportsFestivalManager.Data
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        public virtual ICollection<Discipline> Disciplines { get; }

        public Category()
        {
            CategoryId = Guid.NewGuid();
            Disciplines = new HashSet<Discipline>();
        }
    }
}
