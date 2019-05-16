using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MV.ApplicationService.Interfaces;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MV.WebApi.Controllers
{
  public class MovieController : BaseController
  {
    private readonly IMovieAppService movieService;

    public MovieController(IMovieAppService movieService)
    {
      this.movieService = movieService;
    }

    [HttpGet("upcoming/{page}")]
    public async Task<IActionResult> GetUpcoming([FromRoute] int page)
    {
      var data = await movieService.GetUpcoming(page);

      return Ok(data);
    }

    [HttpGet("genre")]
    public async Task<IActionResult> GetGenres()
    {
      var data = await movieService.GetGenres();

      return Ok(data);
    }

    [HttpGet("genre/{id}")]
    public async Task<IActionResult> GetGenreById([FromRoute] int id)
    {
      var data = await movieService.GetMovieByGenreId(id);

      return Ok(data);
    }

    [HttpGet("popular/{page}")]
    public async Task<IActionResult> GetPopulars([FromRoute] int page)
    {
      var data = await movieService.GetPopulars(page);

      return Ok(data);
    }

    [HttpGet("search/{id}/{page}")]
    public async Task<IActionResult> SearchMovie([FromRoute]string id, [FromRoute] int page)
    {
      var data = await movieService.SearchMovie(id, page);

      return Ok(data);
    }


    [HttpGet("toprated/{page}")]
    public async Task<IActionResult> GetTopRatedMovies([FromRoute] int page)
    {
      var data = await movieService.GetTopRatedMovies(page);

      return Ok(data);
    }

    [HttpGet("intheater/{page}")]
    public async Task<IActionResult> GetInTheaterMovies([FromRoute] int page)
    {
      var data = await movieService.GetInTheaterMovies(page);

      return Ok(data);
    }


    [HttpGet("similar/{id}")]
    public async Task<IActionResult> GetSimilar([FromRoute]int id)
    {
      var data = await movieService.GetSimilar(id);

      return Ok(data);
    }

    [HttpGet("videos/{id}")]
    public async Task<IActionResult> GetVideos([FromRoute]int id)
    {
      var data = await movieService.GetVideos(id);

      return Ok(data);
    }

    [HttpGet("credits/{id}")]
    public async Task<IActionResult> GetCredits([FromRoute]int id)
    {
      var data = await movieService.GetCredits(id);

      return Ok(data);
    }

    [HttpGet("reviews/{id}")]
    public async Task<IActionResult> GetReviews([FromRoute]int id)
    {
      var data = await movieService.GetReviews(id);

      return Ok(data);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
      return Ok(await movieService.Get(id));
    }
  }
}
