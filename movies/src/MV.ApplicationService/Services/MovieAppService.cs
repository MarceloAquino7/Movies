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

    private string URL = "https://api.themoviedb.org/3";
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

    public async Task<MovieViewModel> Get(int id)
    {
      var response = await this.client.GetAsync($"{URL}/movie/{id}?api_key={API_KEY}&language={DEFAULT_LANGUAGE}");
      var responseModel = JsonConvert.DeserializeObject<MovieViewModel>(await response.Content.ReadAsStringAsync());
      return responseModel;
    }

    public async Task<TMDBViewModel<MovieViewModel>> GetUpcoming(int page)
    {
      var response = await this.client.GetAsync($"{URL}/movie/upcoming?api_key={API_KEY}&language={DEFAULT_LANGUAGE}&page={page}");
      var responseModel = JsonConvert.DeserializeObject<TMDBViewModel<MovieViewModel>>(await response.Content.ReadAsStringAsync());
      return responseModel;
    }

    public async Task<IEnumerable<MovieGenreViewModel>> GetGenres()
    {
      var response = await this.client.GetAsync($"{URL}/genre/movie/list?api_key={API_KEY}&language={DEFAULT_LANGUAGE}");
      var responseModel = JsonConvert.DeserializeObject<MovieGenre>(await response.Content.ReadAsStringAsync());
      return responseModel.Genres;
    }

    public async Task<IEnumerable<MovieViewModel>> GetMovieByGenreId(int id)
    {
      var response = await this.client.GetAsync($"{URL}/genre/{id}/movies?api_key={API_KEY}&language={DEFAULT_LANGUAGE}");
      var responseModel = JsonConvert.DeserializeObject<TMDBViewModel<MovieViewModel>>(await response.Content.ReadAsStringAsync());
      return responseModel.Results;
    }

    public async Task<TMDBViewModel<MovieViewModel>> GetPopulars(int page)
    {
      var response = await this.client.GetAsync($"{URL}/movie/popular?api_key={API_KEY}&language={DEFAULT_LANGUAGE}&page={page}");
      var responseModel = JsonConvert.DeserializeObject<TMDBViewModel<MovieViewModel>>(await response.Content.ReadAsStringAsync());
      return responseModel;
    }

    public async Task<TMDBViewModel<MovieViewModel>> SearchMovie(string id, int page)
    {
      var response = await this.client.GetAsync($"{URL}/search/movie?query={id}&api_key={API_KEY}&language={DEFAULT_LANGUAGE}&page={page}");
      var responseModel = JsonConvert.DeserializeObject<TMDBViewModel<MovieViewModel>>(await response.Content.ReadAsStringAsync());
      return responseModel;
    }

    public async Task<TMDBViewModel<MovieViewModel>> GetTopRatedMovies(int page)
    {
      var response = await this.client.GetAsync($"{URL}/movie/top_rated?api_key={API_KEY}&language={DEFAULT_LANGUAGE}&page={page}");
      var responseModel = JsonConvert.DeserializeObject<TMDBViewModel<MovieViewModel>>(await response.Content.ReadAsStringAsync());
      return responseModel;
    }

    public async Task<TMDBViewModel<MovieViewModel>> GetInTheaterMovies(int page)
    {
      var response = await this.client.GetAsync($"{URL}/movie/now_playing?api_key={API_KEY}&language={DEFAULT_LANGUAGE}&page={page}");
      var responseModel = JsonConvert.DeserializeObject<TMDBViewModel<MovieViewModel>>(await response.Content.ReadAsStringAsync());
      return responseModel;
    }

    public async Task<TMDBViewModel<MovieViewModel>> GetSimilar(int id)
    {
      var response = await this.client.GetAsync($"{URL}/movie/{id}/similar?api_key={API_KEY}&language={DEFAULT_LANGUAGE}");
      var responseModel = JsonConvert.DeserializeObject<TMDBViewModel<MovieViewModel>>(await response.Content.ReadAsStringAsync());
      return responseModel;
    }

    public async Task<IEnumerable<MovieVideosViewModel>> GetVideos(int id)
    {
      var response = await this.client.GetAsync($"{URL}/movie/{id}/videos?api_key={API_KEY}&language={DEFAULT_LANGUAGE}");
      var responseModel = JsonConvert.DeserializeObject<TMDBViewModel<MovieVideosViewModel>>(await response.Content.ReadAsStringAsync());
      return responseModel.Results;
    }

    public async Task<MovieCreditsViewModel> GetCredits(int id)
    {
      var response = await this.client.GetAsync($"{URL}/movie/{id}/credits?api_key={API_KEY}&language={DEFAULT_LANGUAGE}");
      var responseModel = JsonConvert.DeserializeObject<MovieCreditsViewModel>(await response.Content.ReadAsStringAsync());
      return responseModel;
    }

    public async Task<IEnumerable<MovieReviewsViewModel>> GetReviews(int id)
    {
      var response = await this.client.GetAsync($"{URL}/movie/{id}/reviews?api_key={API_KEY}&language={DEFAULT_LANGUAGE}");
      var responseModel = JsonConvert.DeserializeObject<TMDBViewModel<MovieReviewsViewModel>>(await response.Content.ReadAsStringAsync());
      return responseModel.Results;
    }
  }
}
