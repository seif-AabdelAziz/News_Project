using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News.BL;

namespace News.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsManager newsManager;

        public NewsController(INewsManager _newsManager)
        {
            newsManager = _newsManager;
        }

        [HttpGet]
        [Route("Published")]
        public ActionResult<List<NewsReadDTO>> GetAll()
        {

            return newsManager.ReadPublished();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<NewsReadDetailsDTO> ReadDetails(Guid id)
        {
            NewsReadDetailsDTO? response = newsManager.ReadDetails(id);
            if (response == null)
            {
                return NotFound();
            }
            return response;
        }


        [HttpGet]
        [Route("All")]
        [Authorize(Policy = "Admin")]
        public ActionResult<List<NewsReadDetailsDTO>> ReadAllNews()
        {
            var response = newsManager.ReadAll();
            if (response == null)
            {
                return NotFound();
            }

            return response;
        }

        [HttpPost]
        [Route("Add")]
        [Authorize(Policy = "Admin")]
        public ActionResult AddNews(NewsAddDTO newsAddDTO)
        {
            var response = newsManager.Add(newsAddDTO);

            if (response == 0)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpGet]
        [Route("update/{id}")]
        [Authorize(Policy = "Admin")]
        public ActionResult<NewsEditDTO> editDetails(Guid id)
        {
            NewsEditDTO? response = newsManager.EditNews(id);
            if (response == null)
            {
                return NotFound();
            }
            return response;
        }

        [HttpPut]
        [Authorize(Policy = "Admin")]
        [Route("Update")]
        public ActionResult Update(NewsEditDTO newsEditDTO)
        {
            int response = newsManager.Update(newsEditDTO);
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
            int response = newsManager.Delete(id);
            if (response == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }

    }
}
