using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MV.ApplicationService.ViewModels;
using MV.Common.WebServer.Server;
using Newtonsoft.Json;

namespace MV.Integration.Tests.Factories
{
  public class MovieControllerFactory
  {
    private string URL = "/api/movie";
    private readonly HttpClient client;

    public MovieControllerFactory(HttpClient client)
    {
      this.client = client;
    }

    public async Task<List<MovieViewModel>> GetUpcomingMovies()
    {
      // Act
      var response = await client.GetAsync($"{URL}/upcoming/1");
      var responseModel = JsonConvert.DeserializeObject<TMDBViewModel<MovieViewModel>>(await response.Content.ReadAsStringAsync());

      return responseModel.Results;
    }

    public async Task<List<MovieViewModel>> GetPopularsMovies()
    {
      // Act
      var response = await client.GetAsync($"{URL}/popular/1");
      var responseModel = JsonConvert.DeserializeObject<TMDBViewModel<MovieViewModel>>(await response.Content.ReadAsStringAsync());

      return responseModel.Results;
    }

    public async Task<List<MovieViewModel>> GetTopRatedMovies()
    {
      // Act
      var response = await client.GetAsync($"{URL}/toprated/1");
      var responseModel = JsonConvert.DeserializeObject<TMDBViewModel<MovieViewModel>>(await response.Content.ReadAsStringAsync());

      return responseModel.Results;
    }

    public async Task<List<MovieViewModel>> GetInTheaterMovies()
    {
      // Act
      var response = await client.GetAsync($"{URL}/intheater/1");
      var responseModel = JsonConvert.DeserializeObject<TMDBViewModel<MovieViewModel>>(await response.Content.ReadAsStringAsync());

      return responseModel.Results;
    }
  }
}
