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
        public BaseModel()
        {
            DateCreated = DateTimeOffset.Now;
        }

        [Index]
        public int Id { get; set; }

        public DateTimeOffset DateCreated { get; set; }

        public DateTimeOffset DateUpdated
        {
            get { return DateTimeOffset.Now; }
            private set { }
        }
    }
}
