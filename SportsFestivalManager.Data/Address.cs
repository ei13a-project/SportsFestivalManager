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
        public string Location { get; set; }

        [Required, StringLength(10)]
        public string PostalCode { get; set; }

        [Required, StringLength(100)]
        public string Street { get; set; }

        [Required, StringLength(10)]
        public string HouseNumber { get; set; }
        
        public Address()
        {
            Id = Guid.NewGuid();
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
