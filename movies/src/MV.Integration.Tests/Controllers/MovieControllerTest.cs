using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using MV.ApplicationService.ViewModels;
using MV.Integration.Tests.Controllers;
using MV.Integration.Tests.Factories;
using Newtonsoft.Json;
using NUnit.Framework;

namespace MV.Integration.Tests.Controllers
{
  public class MovieControllerTest : BaseControllerTest
  {
    private readonly MovieControllerFactory factory;

    public MovieControllerTest()
    {
      factory = new MovieControllerFactory(client);
    }

    [Test]
    public async Task WhenSearchForUpcomingMovies_Then_ICanFindThem()
    {
      // Act
      var viewModelCreate = await factory.GetUpcomingMovies();

      // Assert
      viewModelCreate.Count.Should().NotBe(0);
    }

    [Test]
    public async Task WhenSearchForPopularsMovies_Then_ICanFindThem()
    {
      // Act
      var viewModelCreate = await factory.GetPopularsMovies();

      // Assert
      viewModelCreate.Count.Should().NotBe(0);
    }

    [Test]
    public async Task WhenSearchForTopRatedMovies_Then_ICanFindThem()
    {
      // Act
      var viewModelCreate = await factory.GetTopRatedMovies();

      // Assert
      viewModelCreate.Count.Should().NotBe(0);
    }

    [Test]
    public async Task WhenSearchForInTheaterMovies_Then_ICanFindThem()
    {
      // Act
      var viewModelCreate = await factory.GetInTheaterMovies();

      // Assert
      viewModelCreate.Count.Should().NotBe(0);
    }
  }
}
