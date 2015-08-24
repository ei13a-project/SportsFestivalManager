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
        internal string ValueTypeName
        {
            get { return ValueTypeConverter.Name; }
            private set { ValueTypeConverter = ValueTypeConverters.Instance.GetConverter(value); }
        }

        [NotMapped]
        public IValueTypeConverter ValueTypeConverter { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public Guid CategoryId { get; private set; }

        public Discipline()
        {
            DisciplineId = Guid.NewGuid();
        }
    }
}
