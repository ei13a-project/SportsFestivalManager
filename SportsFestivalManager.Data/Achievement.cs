using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFestivalManager.Data
{
    [Table("Achievements")]
    public class Achievement
    {
        public static Achievement GetAchievement(SportsFestivalManagerContext connection, Festival festival, Discipline discipline, Pupil pupil)
        {
            var achievement = connection.Achievements.FirstOrDefault(x => x.FestivalId == festival.Id && x.DisciplineId == discipline.Id && x.PupilId == pupil.Id);

            if (achievement == null)
                connection.Achievements.Add(achievement = new Achievement(festival, discipline, pupil));

            return achievement;
        }

        private Festival _festival;
        private Discipline _discipline;
        private Pupil _pupil;

        [Key, Column(Order = 0)]
        internal Guid FestivalId { get; private set; }

        [Key, Column(Order = 1)]
        internal Guid DisciplineId { get; private set; }

        [Key, Column(Order = 2)]
        internal Guid PupilId { get; private set; }
        
        [ForeignKey(nameof(FestivalId))]
        public Festival Festival
        {
            get { return _festival; }
            set
            {
                _festival = value;
                FestivalId = Festival.Id;
            }
        }
        
        [ForeignKey(nameof(DisciplineId))]
        public Discipline Discipline
        {
            get { return _discipline; }
            set
            {
                _discipline = value;
                DisciplineId = Discipline.Id;
            }
        }

        [ForeignKey(nameof(PupilId))]
        public Pupil Pupil
        {
            get { return _pupil; }
            set
            {
                _pupil = value;
                PupilId = Pupil.Id;
            }
        }

        [Column("Value")]
        internal string ValueString { get; private set; }

        [NotMapped]
        public object Value
        {
            get { return Discipline.ValueTypeConverter.ConvertToObject(ValueString); }
            set { ValueString = Discipline.ValueTypeConverter.ConvertToString(value); }
        }

        public Achievement(Festival festival, Discipline discipline, Pupil pupil)
        {
            if (festival == null)
                throw new ArgumentNullException(nameof(festival));
            if (discipline == null)
                throw new ArgumentNullException(nameof(discipline));
            if (pupil == null)
                throw new ArgumentNullException(nameof(pupil));

            Festival = festival;
            Discipline = discipline;
            Pupil = pupil;
        }
        private Achievement()
        {

        }
    }
}