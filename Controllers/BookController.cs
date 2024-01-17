using AutoMapper;
using BooksApi.Interfaces;
using BooksApi.Models;
using BookStore.Dtos; 
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {

        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;
        public BookController(IBookRepository bookRepository, IAuthorRepository authorRepository, IStoreRepository storeRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _storeRepository = storeRepository;
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

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(BookDto))]
        [ProducesResponseType(400)]
        public IActionResult CreateBook([FromBody] BookDto bookToCreate)
        {

            if (bookToCreate == null)
            {
                return BadRequest(ModelState);
            }

            if (!_authorRepository.AuthorExists(bookToCreate.AuthorId))
            {
                ModelState.AddModelError("", "Author doesn't exist!");
                return BadRequest(ModelState);
            }

            if (!_storeRepository.StoreExists(bookToCreate.StoreId))
            {
                ModelState.AddModelError("", "Store doesn't exist!");
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Console.Write("Started............................................", bookToCreate);
            var book = _mapper.Map<Book>(bookToCreate);
            Console.Write("Ended............................................", bookToCreate);


            if (!_bookRepository.CreateBook(book, bookToCreate.AuthorId, bookToCreate.StoreId))
            {
                ModelState.AddModelError("", $"Something went wrong saving the book " +
                                                $"{book.Title}");
                return StatusCode(500, ModelState);
            }

            return Ok("Success");
        }

    }
}