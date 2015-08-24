using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace SportsFestivalManager.Data
{
    [Table("People")]
    public abstract class Person
    {
        [Key]
        public Guid PersonId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonNo { get; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }
        
        public bool Active { get; set; }

        [ForeignKey("AddressId")]
        public Address Address { get; set; }

        internal Guid AddressId { get; private set; }

        protected Person()
        {
            Active = true;
        }
    }
}
