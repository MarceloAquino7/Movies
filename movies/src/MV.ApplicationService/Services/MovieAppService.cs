using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MV.ApplicationService.Interfaces;
using MV.ApplicationService.ViewModels;
using MV.Domain.Models;
using MV.Common.Cqrs.Core.Bus;
using MV.Common.Repository.Contracts.Core.Exceptions;
using MV.Common.Repository.Contracts.Core.Repository;
using MV.Common.Repository.Contracts.Core.Validations;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MV.ApplicationService.Services
{
  public class MovieAppService : BaseAppService, IMovieAppService
  {

    private string URL = "https://api.themoviedb.org/3/movie";
    private string API_KEY = "1f54bd990f1cdfb230adb312546d765d";
    private string DEFAULT_LANGUAGE = "en-US";
    private readonly HttpClient client;
    private readonly IMapper mapper;

    public MovieAppService(
        IHttpContextAccessor contextAccessor,
        IMessageBus bus,
        IMapper mapper) : base(contextAccessor, bus, mapper)
    {
      this.mapper = mapper;
      this.client = new HttpClient();
    }

    public MovieViewModel Get(int id)
    {
      return new MovieViewModel();
    }

    public async Task<IEnumerable<MovieViewModel>> GetUpcoming(int page)
    {
      var response = await this.client.GetAsync($"{URL}/upcoming?api_key={API_KEY}&language={DEFAULT_LANGUAGE}&page={page}");
      var responseModel = JsonConvert.DeserializeObject<TMDBViewModel>(await response.Content.ReadAsStringAsync());
      return responseModel.Results;
    }

    public Task<IEnumerable<MovieGenreViewModel>> GetGenres()
    {
      throw new NotImplementedException();
    }

    public Task<MovieGenreViewModel> GetGenreById(int id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<MovieViewModel>> GetPopulars()
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<MovieViewModel>> SearchMovie(string id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<MovieViewModel>> GetTopRatedMovies()
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<MovieViewModel>> GetInTheaterMovies()
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<MovieViewModel>> GetSimilar(int id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<MovieVideosViewModel>> GetVideos(int id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<MovieCreditsViewModel>> GetCredits(int id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<MovieReviewsViewModel>> GetReviews(int id)
    {
      throw new NotImplementedException();
    }
  }
}
