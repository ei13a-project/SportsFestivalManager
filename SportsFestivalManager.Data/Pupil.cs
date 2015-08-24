using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace SportsFestivalManager.Data
{
    [Table("Pupils")]
    public class Pupil : Person
    {
        [ForeignKey("ClassId")]
        public Class Class { get; set; }

        public Guid ClassId { get; private set; }
    }
}
