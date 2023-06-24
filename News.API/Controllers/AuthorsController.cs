using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News.BL;

namespace News.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorManager authorManager;

        public AuthorsController(IAuthorManager _authorManager)
        {
            authorManager = _authorManager;
        }


        [HttpGet]
        [Route("All")]
        [Authorize(Policy = "Admin")]
        public ActionResult<List<AuthorReadDTO>> GetAllAuthors()
        {
            return authorManager.GetAll();
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        [Route("Add")]
        public ActionResult Add(AuthorAddDTO authorAdd)
        {
            var response = authorManager.Add(authorAdd);

            if (response == 0)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpGet]
        [Authorize(Policy = "Admin")]
        [Route("GetAuthor/{id}")]
        public ActionResult<AuthorEditDTO> GetAuthor(Guid id)
        {
            AuthorEditDTO? author = authorManager.GetByID(id);
            if (author == null)
            {
                return BadRequest();
            }
            return author;
        }

        [HttpPut]
        [Authorize(Policy = "Admin")]
        [Route("Update")]
        public ActionResult Update(AuthorEditDTO authorEdit)
        {
            var response = authorManager.Update(authorEdit);

            if (response == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete]
        [Authorize(Policy = "Admin")]
        [Route("Delete/{id}")]
        public ActionResult Delete(Guid id)
        {
            var response = authorManager.Delete(id);
            if (response == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }


    }
}
