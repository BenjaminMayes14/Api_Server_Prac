using Microsoft.AspNetCore.Mvc;
using WebApi_PracServer.models;

namespace WebApi_PracServer.Controllers
{
    public class PersonController : Controller
    {
        [Route("api/[controller]")]
        public IActionResult Index()
        {
            return View();
        }

        private static readonly List<Person> _Persons = new()
        {
            new Person ( 0, "ben", "myemail@gmail.com", 40 )
        };

        //===================Read===================================================

        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetAll()
        {
            return Ok(_Persons);
        }

        [HttpGet("{id}")]
        public ActionResult<Person> GetById(int id)
        {
            var Person = 
                _Persons.FirstOrDefault(t => t.Id == id); // get person object from object list
            if (Person is null)
                return NotFound(); // return NOT FOUND if object not found
            return Ok(Person); // return NO CONTENT
            // return Person is null ? NotFound() : Ok(Person); // return NOT FOUND if object not found, else return OK with person object
        }

        //===================Create=================================================

        [HttpPost]
        public ActionResult<Person> Create(Person Person)
        {
            Person.Id = 
                _Persons.Max(t => t.Id) + 1; // set id to max id + 1
            _Persons.Add(Person); // add person object to object list
            return CreatedAtAction(
                nameof(GetById), 
                new { id = Person.Id }, 
                Person  ); // return CREATED AT ACTION
        }

        //===================Update=================================================

        [HttpPut("{id}")]
        public IActionResult Update(int id, Person updated)
        {
            var Person = 
                _Persons.FirstOrDefault(p => p.Id == id); // get person object from object list
            if (Person is null) 
                return NotFound(); // return NOT FOUND if object not found
            Person.Name = updated.Name; // update name
            Person.Email = updated.Email; // update email
            Person.Age = updated.Age; // update age
            return NoContent(); // return NO CONTENT
        }

        //===================Delete=================================================

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Person = 
                _Persons.FirstOrDefault(t => t.Id == id); // get person object from object list
            if (Person is null) 
                return NotFound(); // return NOT FOUND if object not found
            _Persons.Remove(Person); // delete person object
            return NoContent(); // return NO CONTENT
        }
    }
}

//======================================================================================
// End-Of-File
//======================================================================================