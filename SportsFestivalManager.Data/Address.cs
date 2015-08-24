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
        [Key]
        public Guid AddressId { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        [Required]
        [StringLength(10)]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(100)]
        public string Street { get; set; }

        [Required]
        [StringLength(10)]
        public string HouseNumber { get; set; }
        
        public Address()
        {
            AddressId = Guid.NewGuid();
        }
    }
}
