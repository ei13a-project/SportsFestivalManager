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
        private Category _category;
        private IValueTypeConverter _valueTypeConverter;

        [Key, Column("DisciplineId")]
        public Guid Id { get; set; }

        [Required, StringLength(100), Index(IsUnique = true)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        public string Unit { get; set; }
        
        [Column("ValueType"), Required, StringLength(50)]
        internal string ValueTypeName { get; private set; }

        [NotMapped]
        public IValueTypeConverter ValueTypeConverter
        {
            get { return ValueTypeConverters.Instance.GetConverter(ValueTypeName); }
            set { ValueTypeName = value.Name; }
        }

        [ForeignKey(nameof(CategoryId))]
        public Category Category
        {
            get { return _category; }
            set
            {
                _category = value;
                CategoryId = Category.Id;
            }
        }

        public Guid CategoryId { get; private set; }

        public Discipline()
        {
            Id = Guid.NewGuid();
        }
    }
}
