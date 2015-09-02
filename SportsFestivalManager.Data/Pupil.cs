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
        private Class _class;

        [ForeignKey(nameof(ClassId))]
        public Class Class
        {
            get { return _class; }
            set
            {
                _class = value;
                ClassId = Class.Id;
            }
        }

        internal Guid ClassId { get; private set; }

        public Pupil()
        {

        }
    }
}
