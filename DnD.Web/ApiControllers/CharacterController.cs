using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using DnD.Datalayer.Models;
using DnD.Service.Interfaces;
using DnD.Service.Services;

namespace DungeonsAndDragons.ApiControllers
{
    /// <summary>
    /// Controller for editing, creating, updating and deleting characters.
    /// </summary>
    [RoutePrefix("api/character")]
    [AllowAnonymous]
    public class CharacterController : ApiController
    {
        private ICharacterService characterService;

        public CharacterController(ICharacterService charService)
        {
            characterService = charService;
        }

        [HttpGet]
        public Character CreateNewCharacter()
        {
            return characterService.CreateCharacter();
        }

        [HttpPost]
        public bool UpdateCharacter(Character character)
        {
            return true;
        }
    }
}