using FluentValidation;
using FluentValidation.Results;
using Library_MusicData.Data;
using Library_MusicData.Models;
using Library_MusicData.Repositories.Artist;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library_MusicManagement.Controllers
{
    [Route("api/Artist")]
    [ApiController]
    public class ArtistAPIController : ControllerBase
    {

        private readonly IArtistRepository _artistRepository;
        private readonly IValidator<ArtistModel> _validator;

        public ArtistAPIController(
            IArtistRepository artistRepository, 
            IValidator<ArtistModel> validator
            )
        {
            _artistRepository = artistRepository;
            _validator = validator;
        }


        // GET: api/<ArtistAPIController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var artist = await _artistRepository.GetAllArtistAsync();

            return Ok(artist);
        }

        // GET api/<ArtistAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ArtistAPIController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ArtistModel artist)
        {
            await _artistRepository.AddArtistAsync(artist);

            ValidationResult validationResult = await _validator.ValidateAsync(artist);

            return Created();
        }

        // PUT api/<ArtistAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ArtistAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
