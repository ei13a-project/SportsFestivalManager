using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace SportsFestivalManager.Data
{
    [Table("Disciplines")]
    public class Discipline
    {
        [Key]
        public Guid DisciplineId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Unit { get; set; }
        
        [Column("ValueType")]
        [Required]
        [StringLength(50)]
        internal string ValueTypeString
        {
            get { return ValueType.ToString(); }
            private set { ValueType = (DisciplineValueType)Enum.Parse(typeof(DisciplineValueType), value); }
        }

        [NotMapped]
        public DisciplineValueType ValueType { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        internal Guid CategoryId { get; private set; }
    }
}
