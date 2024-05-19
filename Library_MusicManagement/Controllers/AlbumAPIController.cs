using FluentValidation;
using FluentValidation.Results;
using Library_MusicData.Models;
using Library_MusicData.Repositories.Album;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library_MusicManagement.Controllers
{
    [Route("api/Albums")]
    [ApiController]
    public class AlbumAPIController : ControllerBase
    {

        /////////////////////////////////////////////////////----------------
        private readonly IAlbumRepository _albumRepository;
        private readonly IValidator<AlbumsModel> _validator;

        public AlbumAPIController(
            IAlbumRepository albumRepository,
            IValidator<AlbumsModel> validator
            )
        {
            _albumRepository = albumRepository;
            _validator = validator;
        }
        /////////////////////////////////////////////////////----------------
  

        // GET: api/<AlbumAPIController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var albums = await _albumRepository.GetAllAlbumsAsync();
            return Ok(albums);
        }

        // GET api/<AlbumAPIController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var album = await _albumRepository.GetAlbumByIdAsync(id);
            if (album == null)
                return NotFound();
            return Ok(album);
        }

        // POST api/<AlbumAPIController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AlbumsModel album)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(album);
            if (!validationResult.IsValid)
                return UnprocessableEntity(validationResult);

            await _albumRepository.AddAlbumAsync(album);
            return Created();
        }

        // PUT api/<AlbumAPIController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AlbumsModel album)
        {
            var albumEditable = await _albumRepository.GetAlbumByIdAsync(id);
            if (albumEditable == null)
                return NotFound();

            ValidationResult validationResult = await _validator.ValidateAsync(album);
            if (!validationResult.IsValid)
                return UnprocessableEntity(validationResult);

            album.AlbumID = id; // Ensure the ID matches
            await _albumRepository.EditAlbumAsync(album);
            return Accepted();
        }

        // DELETE api/<AlbumAPIController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var album = await _albumRepository.GetAlbumByIdAsync(id);
            if (album == null)
                return NotFound();
            await _albumRepository.DeleteAlbumAsync(id);
            return NoContent();
        }
    }
}
