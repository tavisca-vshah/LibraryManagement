using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using libraryManagement.Entities;
using libraryManagement.Services;
using Microsoft.Extensions.Logging;

namespace libraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly ILibraryRepository _libraryRepository;
        private readonly ILogger<AuthorsController> _logger;
        

        public AuthorsController(ILibraryRepository libraryRepository, ILogger<AuthorsController> logger) 
        {
            _libraryRepository = libraryRepository;
            _logger = logger;
        }

        // GET: api/Authors
        [HttpGet]
        public IEnumerable<Author> GetAuthors()
        {
            var authorsFromRepo = _libraryRepository.GetAuthors();
            _logger.LogInformation("Index page says hello");
            return authorsFromRepo;
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public ActionResult<Author> GetAuthor(Guid id)
        {
            var author = _libraryRepository.GetAuthor(id);

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }

        [HttpPost]
        public ActionResult<Author> PostAuthor(Author author)
        {
            _libraryRepository.AddAuthor(author);
            _libraryRepository.Save();

            return CreatedAtAction("GetAuthor", new { id = author.Id }, author);
        }

       
        [HttpDelete("{id}")]
        public ActionResult<Author> DeleteAuthor(Guid id)
        {
            var author =  _libraryRepository.GetAuthor(id);
            if (author == null)
            {
                return NotFound();
            }

            _libraryRepository.DeleteAuthor(author);
            _libraryRepository.Save();

            return author;
        }

        
    }
}
