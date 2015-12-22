using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnD.Datalayer.models;

namespace DnD.Datalayer.Models
{
    public class Character : BaseModel
    {
        public virtual CharacterClass Class { get; set; }
        [ForeignKey("Class")]
        public int ClassId { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }

        public int Experience { get; set; }


    }
}
