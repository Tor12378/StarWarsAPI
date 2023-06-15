using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StarWarsAPI.Data;
using StarWarsAPI.Models;
using System.Threading.Tasks;

namespace StarWarsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharactersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public CharactersController(AppDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return Ok();
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
                return Ok();
            else
                return BadRequest("Invalid login attempt.");
        }

        [HttpGet("{id}")]
        public IActionResult GetCharacter(int id)
        {
            var character = _context.Characters.FirstOrDefault(c => c.Id == id);
            if (character == null)
                return NotFound();

            return Ok(character);
        }

        [HttpPost]
        public IActionResult CreateCharacter([FromBody] Character character)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Characters.Add(character);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCharacter), new { id = character.Id }, character);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCharacter(int id, [FromBody] Character updatedCharacter)
        {
            var character = _context.Characters.FirstOrDefault(c => c.Id == id);
            if (character == null)
                return NotFound();


            character.Name = updatedCharacter.Name;
            character.BirthDate = updatedCharacter.BirthDate;
            character.Planet = updatedCharacter.Planet;
            character.Gender = updatedCharacter.Gender;
            character.Race = updatedCharacter.Race;
            character.Height = updatedCharacter.Height;
            character.HairColor = updatedCharacter.HairColor;
            character.EyeColor = updatedCharacter.EyeColor;
            character.Description = updatedCharacter.Description;
            character.Movies = updatedCharacter.Movies;

            _context.SaveChanges();

            return Ok(character);
        }

        [HttpGet]
        public IActionResult GetAllCharacters()
        {
            var characters = _context.Characters.ToList();
            return Ok(characters);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCharacter(int id)
        {
            var character = _context.Characters.FirstOrDefault(c => c.Id == id);
            if (character == null)
                return NotFound();

            _context.Characters.Remove(character);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
