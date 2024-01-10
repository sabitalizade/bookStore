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
            // var authors = _authorRepository.GetAuthors();
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
    }
}