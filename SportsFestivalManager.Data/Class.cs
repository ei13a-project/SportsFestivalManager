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
        [Key]
        public Guid ClassId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }
        
        internal Guid TeacherId { get; private set; }
    }
}
