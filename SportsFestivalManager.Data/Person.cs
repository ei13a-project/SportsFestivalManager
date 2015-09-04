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
        public int PersonNo { get; set; }

        [Required, StringLength(100)]
        public string FirstName { get; set; }

        [Required, StringLength(100)]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        [Column("ClassName")]
        public string Class { get; set; }

        [Column("Gender"), Required, StringLength(10)]
        internal string GenderString { get; private set; }

        [NotMapped]
        public Gender Gender
        {
            get { return (Gender)Enum.Parse(typeof(Gender), GenderString); }
            set { GenderString = value.ToString(); }
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

        public Guid AddressId { get; private set; }

        internal protected Person()
        {
            Id = Guid.NewGuid();
            Active = true;
            Gender = Gender.Female;
        }
    }
}
