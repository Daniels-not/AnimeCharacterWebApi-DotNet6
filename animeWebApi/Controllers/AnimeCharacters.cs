using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using animeWebApi.Models;

namespace animeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AnimeCharacters : ControllerBase
    {

        // using the connection in the file Data/DataCharacterContext.cs

        private readonly DataCharacterContext _characterContext;

        // asyning the connection 
        public AnimeCharacters(DataCharacterContext context)
        {
            _characterContext = context;
        }

        [HttpGet]
        // method to get all characters
        public async Task<ActionResult<List<Characters>>> Get()
        {
            // _characterContext.Characters calling the getters an setter from the context 

            return Ok(await _characterContext.Characters.ToListAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<List<Characters>>> GetSingleCharacter(int id)
        {
            var character = await _characterContext.Characters.FindAsync(id);
            if (character == null) 
            {
                return NotFound();
            }
            return Ok(character);
        }

        [HttpPost]
        public async Task<ActionResult<List<Characters>>> AddAnimeCharacter(Characters characters)
        {
            try
            {
                _characterContext.Characters.Add(characters);
                await _characterContext.SaveChangesAsync();
                return Ok(await _characterContext.Characters.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]

        public async Task<ActionResult> UpdateCharacter(Characters characters)
        {
            var specificCharac = await _characterContext.Characters.FindAsync(characters.Id);
            if(specificCharac == null) // if character is null return bad request error not found 
            {
                return BadRequest("No here found");

            }else
            {
                specificCharac.name = characters.name;
                specificCharac.description = characters.description;
                specificCharac.level = characters.level;
                specificCharac.primaryAttack = characters.primaryAttack;
                specificCharac.secundaryAttack = characters.secundaryAttack;
                specificCharac.specialAttack = characters.specialAttack;
                await _characterContext.SaveChangesAsync();
            }

            return Ok(await _characterContext.Characters.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Characters>>> DeleteCharacter(int characters)
        {
            var specificCharac = await _characterContext.Characters.FindAsync(characters);

            if (specificCharac == null)
            {
                return BadRequest("No character found");
            }
            
            _characterContext.Characters.Remove(specificCharac);
            await _characterContext.SaveChangesAsync();

            return Ok(await _characterContext.Characters.ToListAsync());
        }
    }
}
