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
        private Address _address;

        [Key, Column("PersonId")]
        public Guid Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonNo { get; }

        [Required, StringLength(100)]
        public string FirstName { get; set; }

        [Required, StringLength(100)]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        [NotMapped]
        public int Age
        {
            get
            {
                var age = DateTime.Today.Year - BirthDate.Year;
                if (BirthDate > DateTime.Today.AddYears(-age))
                    age--;
                return age;
            }
        }
        
        public bool Active { get; set; }

        [ForeignKey(nameof(AddressId))]
        public Address Address
        {
            get { return _address; }
            set
            {
                _address = value;
                AddressId = Address.Id;
            }
        }

        internal Guid AddressId { get; private set; }

        internal protected Person()
        {
            Id = Guid.NewGuid();
            Active = true;
        }
    }
}
