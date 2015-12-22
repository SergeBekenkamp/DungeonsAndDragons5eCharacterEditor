using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnD.Datalayer.Models;

namespace DnD.Service.Interfaces
{
    public interface ICharacterService : ICrudService<Character>
    {
        Character CreateCharacter();
    }
}
