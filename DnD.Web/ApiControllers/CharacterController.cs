using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using DnD.Datalayer.Models;

namespace DungeonsAndDragons.ApiControllers
{
    /// <summary>
    /// Controller for editing, creating, updating and deleting characters.
    /// </summary>
    public class CharacterController : ApiController
    {
        [HttpGet]
        public Character CreateNewCharacter()
        {
            return new Character() {Id = 1,};
        }

        [HttpPost]
        public bool UpdateCharacter(Character character)
        {
            return true;
        }
    }
}