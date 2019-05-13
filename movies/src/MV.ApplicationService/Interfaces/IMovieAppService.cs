using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MV.ApplicationService.ViewModels;

namespace MV.ApplicationService.Interfaces
{
  public interface IMovieAppService
  {
    MovieViewModel Get(int id);
    Task<IEnumerable<MovieViewModel>> GetUpcoming(int page);
    Task<IEnumerable<MovieGenreViewModel>> GetGenres();
    Task<MovieGenreViewModel> GetGenreById(int id);
    Task<IEnumerable<MovieViewModel>> GetPopulars();
    Task<IEnumerable<MovieViewModel>> SearchMovie(string id);
    Task<IEnumerable<MovieViewModel>> GetTopRatedMovies();
    Task<IEnumerable<MovieViewModel>> GetInTheaterMovies();
    Task<IEnumerable<MovieViewModel>> GetSimilar(int id);
    Task<IEnumerable<MovieVideosViewModel>> GetVideos(int id);
    Task<IEnumerable<MovieCreditsViewModel>> GetCredits(int id);
    Task<IEnumerable<MovieReviewsViewModel>> GetReviews(int id);
  }
}
