using Microsoft.AspNetCore.Mvc;

namespace EfCoreRelationShip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private static List<Character> ziak = new List<Character>
            {
                new Character {
                    Id = 1,
                    FirstName = "Janko",
                    LastName = "Mrkvicka",
                    Age = 20
                }
            };

        private readonly DataContext _context;

        public CharacterController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]

        /*public async Task<ActionResult<List<Character>>> addHadikParts(Character request)
        {
            _context.Characters.Add(request);
            await _context.SaveChangesAsync();

            return Ok(await _context.Characters.ToListAsync());
        }*/
        public async Task<IEnumerable<string>> Get(int id, string firstName, string lastName, int age)
        {

            //vytvorenie objektu chatacter a priradenie hodnot
            Character character = new Character();
            character.Id = id;
            character.FirstName = firstName;
            character.LastName = lastName;
            character.Age = age;


            //pridanie a uloženie do databazy
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();


            //len pre debuging
            return new string[]{
            $"id  {character.Id}",
            $"FirstName {character.FirstName}",
            $"LastName {character.LastName}",
            $"Age {character.Age}"
         };
        }

        [HttpGet]
        [Route("ziaci")]
        public async Task<ActionResult<List<Character>>> daj()
        {


            return Ok(ziak);
        }
    }
}
