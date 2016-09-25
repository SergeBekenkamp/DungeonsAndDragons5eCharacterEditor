using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnD.Datalayer.Models;
using DnD.Datalayer.Repositories;
using DnD.Service.Interfaces;

namespace DnD.Service.Services
{
    public class CharacterService : CrudService<Character>, ICharacterService
    {
        public CharacterService(IRepository<Character> repo) : base(repo)
        {
        }

        public Character CreateCharacter()
        {
            var character = new Character();
            var ability = new AbilityScores();
            var charClass = new CharacterClass();
            character.Class = charClass;
            character.AbilityScores = ability;
            character.Name = "RandomFuckingName";
            character.Experience = 9001;
            repo.Create(character);
            return character;
        }

    }


}
