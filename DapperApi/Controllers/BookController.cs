using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace DapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ILibraryRepository _libraryRepository;
        private readonly IPeopleRepository _peopleRepository;
        public BookController(ILibraryRepository libraryRepository, IPeopleRepository peopleRepository)
        {
            _libraryRepository = libraryRepository;
            _peopleRepository = peopleRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetBookById(int id)
        {
            try
            {
                var book = await _libraryRepository.GetBookById(id);
                if (book == null)
                {
                    return NotFound(new
                    {
                        Message = "No se encontró el libro"
                    });
                }
                else
                {
                    book.Author = await _peopleRepository.GetAuthorById(book.AuthorId);
                    return Ok(book);
                }
            }
            catch (Exception ex)
            {
                {
                    return StatusCode(500, new { Message = ex.Message });
                }
            }
        }
    }
}