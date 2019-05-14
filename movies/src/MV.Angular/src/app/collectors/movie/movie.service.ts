import { Injectable } from '@angular/core';
import { IProvider } from '@services/interfaces/iprovider.service';
import { Movie } from '@classes/movie';
import { JsonConvert } from 'json2typescript';
import { Observable, Subscription, Subscribable } from 'rxjs';
import { Genre } from '@classes/genre';
import { Credits } from '@classes/credits';
import { MovieVideo } from '@classes/movie_video';
import { MovieReviews } from '@classes/movie_reviews';
import { TMDBObj } from '@classes/tmdb_object';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private provider: IProvider) { }

  getUpcoming(page: number): Observable<TMDBObj> {
    return Observable.create(observer => {
      this.provider.get(`/movie/upcoming/${page}`).subscribe(
        response => {
          const jsonConvert: JsonConvert = new JsonConvert();
          observer.next(jsonConvert.deserialize(response, TMDBObj));
        }
      );
    });
  }

  getGenres(): Observable<Genre[]> {
    return Observable.create(observer => {
      this.provider.get(`/movie/genre`).subscribe(
        response => {
          const jsonConvert: JsonConvert = new JsonConvert();
          observer.next(jsonConvert.deserialize(response, Genre));
        }
      );
    });
  }

  getMoviesByGenre(id: number) {
    return Observable.create(observer => {
      this.provider.getByFilter(`/movie/genre`, { id: id }).subscribe(
        response => {
          const jsonConvert: JsonConvert = new JsonConvert();
          observer.next(jsonConvert.deserialize(response, Movie));
        }
      );
    });
  }

  getPopular(page: number): Observable<TMDBObj> {
    return Observable.create(observer => {
      this.provider.getByFilter(`/movie/popular`, { page: page}).subscribe(
        response => {
          const jsonConvert: JsonConvert = new JsonConvert();
          observer.next(jsonConvert.deserialize(response, TMDBObj));
        }
      );
    });
  }

  searchMovies(searchStr: string, page: number): Observable<TMDBObj> {
    return Observable.create(observer => {
      this.provider.getByFilter(`/movie/search`, { id: searchStr, page: page }).subscribe(
        response => {
          const jsonConvert: JsonConvert = new JsonConvert();
          observer.next(jsonConvert.deserialize(response, TMDBObj));
        }
      );
    });
  }

  getTopRatedMovies(page: number): Observable<TMDBObj> {
    return Observable.create(observer => {
      this.provider.getByFilter(`/movie/toprated`, { page: page}).subscribe(
        response => {
          const jsonConvert: JsonConvert = new JsonConvert();
          observer.next(jsonConvert.deserialize(response, TMDBObj));
        }
      );
    });
  }

  getInTheaters(page: number): Observable<TMDBObj> {
    return Observable.create(observer => {
      this.provider.getByFilter(`/movie/intheater`, { page: page}).subscribe(
        response => {
          const jsonConvert: JsonConvert = new JsonConvert();
          observer.next(jsonConvert.deserialize(response, TMDBObj));
        }
      );
    });
  }

  getSimilarMovies(id: number): Observable<TMDBObj> {
    return Observable.create(observer => {
      this.provider.getByFilter(`/movie/similar`, { id: id }).subscribe(
        response => {
          const jsonConvert: JsonConvert = new JsonConvert();
          observer.next(jsonConvert.deserialize(response, TMDBObj));
        }
      );
    });
  }

  getMovieVideos(id: number): Observable<MovieVideo[]> {
    return Observable.create(observer => {
      this.provider.getByFilter(`/movie/videos`, { id: id }).subscribe(
        response => {
          const jsonConvert: JsonConvert = new JsonConvert();
          observer.next(jsonConvert.deserialize(response, MovieVideo));
        }
      );
    });
  }

  getMovieCredits(id: number): Observable<Credits> {
    return Observable.create(observer => {
      this.provider.getByFilter(`/movie/credits`, { id: id }).subscribe(
        response => {
          const jsonConvert: JsonConvert = new JsonConvert();
          observer.next(jsonConvert.deserialize(response, Credits));
        }
      );
    });
  }

  getMovieReviews(id: number): Observable<MovieReviews[]> {
    return Observable.create(observer => {
      this.provider.getByFilter(`/movie/reviews`, { id: id }).subscribe(
        response => {
          const jsonConvert: JsonConvert = new JsonConvert();
          observer.next(jsonConvert.deserialize(response, MovieReviews));
        }
      );
    });
  }

  getMovie(id: number): Observable<Movie[]> {
    return Observable.create(observer => {
      this.provider.getByFilter(`/movie`, { id: id }).subscribe(
        response => {
          const jsonConvert: JsonConvert = new JsonConvert();
          observer.next(jsonConvert.deserialize(response, Movie));
        }
      );
    });
  }
}
