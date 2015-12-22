using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnD.Datalayer.Interfaces;

namespace DnD.Datalayer.models
{
    public class BaseModel : IBaseModel
    {
        [Index]
        public int Id { get; set; }
    }
}
