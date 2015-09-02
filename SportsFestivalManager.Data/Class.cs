using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace SportsFestivalManager.Data
{
    [Table("Classes")]
    public class Class
    {
        private Teacher _teacher;

        [Key, Column("ClassId")]
        public Guid Id { get; set; }

        [Required, StringLength(100), Index(IsUnique = true)]
        public string Name { get; set; }

        [ForeignKey(nameof(TeacherId))]
        public Teacher Teacher
        {
            get { return _teacher; }
            set
            {
                _teacher = value;
                TeacherId = Teacher.Id;
            }
        }

        internal Guid TeacherId { get; private set; }

        public virtual ICollection<Pupil> Pupils { get; private set; }

        public Class()
        {
            Id = Guid.NewGuid();

            Pupils = new HashSet<Pupil>();
        }
    }
}
