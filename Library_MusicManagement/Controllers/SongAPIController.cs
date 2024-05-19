using FluentValidation;
using FluentValidation.Results;
using Library_MusicData.Models;
using Library_MusicData.Repositories.Song;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library_MusicManagement.Controllers
{
    [Route("api/Songs")]
    [ApiController]
    public class SongAPIController : ControllerBase
    {
        private readonly ISongRepository _songRepository;
        private readonly IValidator<SongsModel> _validator;

        public SongAPIController(
            ISongRepository songRepository
            , IValidator<SongsModel> validator)
        {
            _songRepository = songRepository;
            _validator = validator;
        }


        // GET: api/<SongAPIController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var songs = await _songRepository.GetAllSongsAsync();
            return Ok(songs);
        }

        // GET api/<SongAPIController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var song = await _songRepository.GetSongByIdAsync(id);
            if (song == null)
                return NotFound();
            return Ok(song);
        }

        // POST api/<SongAPIController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SongsModel song)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(song);
            if (!validationResult.IsValid)
                return UnprocessableEntity(validationResult);

            await _songRepository.AddSongAsync(song);
            return Created();
        }

        // PUT api/<SongAPIController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SongsModel song)
        {
            var songEditable = await _songRepository.GetSongByIdAsync(id);
            if (songEditable == null)
                return NotFound();

            ValidationResult validationResult = await _validator.ValidateAsync(song);
            if (!validationResult.IsValid)
                return UnprocessableEntity(validationResult);

            song.SongID = id; // Ensure the ID matches
            await _songRepository.EditSongAsync(song);
            return Accepted();
        }

        // DELETE api/<SongAPIController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var song = await _songRepository.GetSongByIdAsync(id);
            if (song == null)
                return NotFound();
            await _songRepository.DeleteSongAsync(id);
            return NoContent();
        }
    }
}
