
using System.Data.Entity;
using DnD.Datalayer.Models;


namespace DnD.Datalayer.Context
{
    public class DnDContext : DbContext
    {
       public DnDContext() : base("name=DnDContext")
       {
           
       }

        public static DnDContext Create()
        {
            return new DnDContext();
        }

        public virtual IDbSet<Character> Characters { get; set;} 
        public virtual IDbSet<CharacterClass> CharacterClasses { get; set; }
        public virtual IDbSet<AbilityScores> AbilityScores { get; set; }

    }
}
