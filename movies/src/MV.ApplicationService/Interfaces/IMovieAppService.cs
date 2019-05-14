using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MV.ApplicationService.ViewModels;

namespace MV.ApplicationService.Interfaces
{
  public interface IMovieAppService
  {
    Task<MovieViewModel> Get(int id);
    Task<TMDBViewModel<MovieViewModel>> GetUpcoming(int page);
    Task<IEnumerable<MovieGenreViewModel>> GetGenres();
    Task<IEnumerable<MovieViewModel>> GetMovieByGenreId(int id);
    Task<TMDBViewModel<MovieViewModel>> GetPopulars(int page);
    Task<TMDBViewModel<MovieViewModel>> SearchMovie(string id, int page);
    Task<TMDBViewModel<MovieViewModel>> GetTopRatedMovies(int page);
    Task<TMDBViewModel<MovieViewModel>> GetInTheaterMovies(int page);
    Task<TMDBViewModel<MovieViewModel>> GetSimilar(int id);
    Task<IEnumerable<MovieVideosViewModel>> GetVideos(int id);
    Task<MovieCreditsViewModel> GetCredits(int id);
    Task<IEnumerable<MovieReviewsViewModel>> GetReviews(int id);
  }
}
