using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Diagnostics.CodeAnalysis;

namespace SportsFestivalManager.Data
{
    [Table("Addresses")]
    public class Address
    {
        [Key, Column("AddressId")]
        public Guid Id { get; private set; }

        [Required, StringLength(100)]
        public string Location { get; private set; }

        [Required, StringLength(10)]
        public string PostalCode { get; private set; }

        [Required, StringLength(100)]
        public string Street { get; private set; }

        [Required, StringLength(10)]
        public string HouseNumber { get; private set; }

        public virtual ICollection<Person> People { get; private set; }
        
        public Address(string location, string postalCode, string street, string houseNumber)
            : this()
        {
            if (string.IsNullOrWhiteSpace(location))
                throw new ArgumentNullException(nameof(location));
            if (string.IsNullOrWhiteSpace(postalCode))
                throw new ArgumentNullException(nameof(postalCode));
            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentNullException(nameof(street));
            if (string.IsNullOrWhiteSpace(houseNumber))
                throw new ArgumentNullException(nameof(houseNumber));
            
            Location = location;
            PostalCode = postalCode;
            Street = street;
            HouseNumber = houseNumber;
        }
        private Address()
        {
            Id = Guid.NewGuid();
            People = new HashSet<Person>();
        }

        public bool Equals(Address obj)
        {
            return obj != null
                && (obj.Id == Id
                    || (obj.Location == Location
                        && obj.PostalCode == PostalCode
                        && obj.Street == Street
                        && obj.HouseNumber == HouseNumber));
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Address);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
