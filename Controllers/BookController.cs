using AutoMapper;
using BooksApi.Interfaces;
using BookStore.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {

        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BookController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetBooks()
        {
            var books = _mapper.Map<List<BookDto>>(_bookRepository.GetBooks());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(books);
        }
        [HttpGet("{bookId}")]
        [ProducesResponseType(200, Type = typeof(BookDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetBook(int bookId)
        {
            if (!_bookRepository.BookExists(bookId))
            {
                return NotFound();
            }
            var book = _mapper.Map<BookDto>(_bookRepository.GetBook(bookId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(book);
        }

        [HttpGet("{bookId}/stores")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<StoreDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetStoresByBook(int bookId)
        {
            var stores = _mapper.Map<List<StoreDto>>(_bookRepository.GetStoresByBook(bookId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(stores);
        }

    }
}