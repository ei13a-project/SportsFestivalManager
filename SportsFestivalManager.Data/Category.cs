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
        [Key, Column("CategoryId")]
        public Guid Id { get; set; }

        [Required, StringLength(100), Index(IsUnique = true)]
        public string Name { get; set; }
        
        public virtual ICollection<Discipline> Disciplines { get; }

        public Category()
        {
            Id = Guid.NewGuid();
            Disciplines = new HashSet<Discipline>();
        }
    }
}
