using AutoMapper;
using BooksApi.Interfaces;
using BookStore.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;
        public StoreController(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<StoreDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetStores()
        {
            var stores = _mapper.Map<List<StoreDto>>(_storeRepository.GetStores());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(stores);
        }

        [HttpGet("{storeId}")]
        [ProducesResponseType(200, Type = typeof(StoreDto))]
        [ProducesResponseType(400)]
        public IActionResult GetStore(int storeId)
        {
            var store = _mapper.Map<StoreDto>(_storeRepository.GetStore(storeId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(store);
        }

        [HttpGet("{storeId}/books")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetBooksByStore(int storeId)
        {
            var books = _mapper.Map<List<BookDto>>(_storeRepository.GetBooksByStore(storeId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(books);
        }
    }
}