using AutoMapper;
using BooksApi.Interfaces;
using BooksApi.Models;
using BookStore.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public AuthorController(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AuthorDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetAuthors()
        {
            var authors = _mapper.Map<List<AuthorDto>>(_authorRepository.GetAuthors());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(authors);
        }
        [HttpGet("{authorId}")]
        [ProducesResponseType(200, Type = typeof(AuthorDto))]
        [ProducesResponseType(400)]
        public IActionResult GetAuthor(int authorId)
        {
            if (!_authorRepository.AuthorExists(authorId))
            {
                return NotFound();
            }
            var author = _mapper.Map<AuthorDto>(_authorRepository.GetAuthor(authorId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(author);
        }

        [HttpDelete("{authorId}")]
        [ProducesResponseType(204)] // No Content
        [ProducesResponseType(400)]
        public IActionResult DeleteAuthor(int authorId)
        {
            if (!_authorRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var author = _authorRepository.GetAuthor(authorId);

            if (!_authorRepository.DeleteAuthor(author))
            {
                ModelState.AddModelError("", $"Something went wrong deleting {author.FirstName} {author.LastName}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpPut("{authorId}")]
        [ProducesResponseType(204)] // No Content
        [ProducesResponseType(400)]
        public IActionResult UpdateAuthor(int authorId, [FromBody] AuthorDto updateAuthor)
        {
            if (updateAuthor == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var author = _mapper.Map<Author>(updateAuthor);

            if (!_authorRepository.UpdateAuthor(author))
            {
                ModelState.AddModelError("", $"Something went wrong updating {author.FirstName} {author.LastName}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult CreateAuthor([FromBody] AuthorDto createAuthor)
        {

            if (createAuthor == null)
            {
                return BadRequest(ModelState);
            }

            var author = _authorRepository.GetAuthor(createAuthor.FirstName, createAuthor.LastName);
            if (author != null)
            {
                ModelState.AddModelError("", $"Author {createAuthor.FirstName} {createAuthor.LastName} already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authorObj = _mapper.Map<Author>(createAuthor);

            if (!_authorRepository.CreateAuthor(authorObj))
            {
                ModelState.AddModelError("", $"Something went wrong saving {authorObj.FirstName} {authorObj.LastName}");
                return StatusCode(500, ModelState);
            }

            return Ok("Author Created");

        }

        [HttpGet("{authorId}/books")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetBooksByAuthor(int authorId)
        {

            if (!_authorRepository.AuthorExists(authorId))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var books = _mapper.Map<List<BookDto>>(_authorRepository.GetBooksByAuthor(authorId));
            return Ok(books);
        }
    }
}