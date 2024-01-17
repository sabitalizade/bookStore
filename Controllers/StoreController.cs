using AutoMapper;
using BooksApi.Interfaces;
using BooksApi.Models;
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

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(StoreDto))]
        [ProducesResponseType(400)]
        public IActionResult CreateStore([FromBody] StoreDto storeDto)
        {
            if (storeDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_storeRepository.StoreExists(storeDto.Name))
            {
                ModelState.AddModelError("", "Store Exists!");
                return StatusCode(404, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var store = _mapper.Map<Stores>(storeDto);

            if (!_storeRepository.CreateStore(store))
            {
                ModelState.AddModelError("", $"Something went wrong saving the store " +
                                                $"{store.Name}");
                return StatusCode(500, ModelState);
            }

            return Ok("Store Created");
        }

        [HttpDelete("{storeId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult DeleteStore(int storeId)
        {

            if (!_storeRepository.StoreExists(storeId))
            {
                return NotFound();
            }

            if (!_storeRepository.DeleteStore(storeId))
            {
                ModelState.AddModelError("", $"Something went wrong deleting the store " +
                                                $"{storeId}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}