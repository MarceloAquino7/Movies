import { Injectable } from '@angular/core';
import { IProvider } from '@services/interfaces/iprovider.service';
import { Movie } from '@classes/movie';
import { JsonConvert } from 'json2typescript';
import { Observable, Subscription, Subscribable } from 'rxjs';
import { Genre } from '@classes/genre';
import { Credits } from '@classes/credits';
import { MovieVideo } from '@classes/movie_video';
import { MovieReviews } from '@classes/movie_reviews';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private provider: IProvider) { }

  getUpcoming(page: number): Observable<Movie[]> {
    return Observable.create(observer => {
      this.provider.get(`/movie/upcoming/${page}`).subscribe(
        response => {
          const jsonConvert: JsonConvert = new JsonConvert();
          observer.next(jsonConvert.deserialize(response, Movie));
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

  getPopular(): Observable<Movie[]> {
    return Observable.create(observer => {
      this.provider.get(`/movie/popular`).subscribe(
        response => {
          const jsonConvert: JsonConvert = new JsonConvert();
          observer.next(jsonConvert.deserialize(response, Movie));
        }
      );
    });
  }

  searchMovies(searchStr: string): Observable<Movie[]> {
    return Observable.create(observer => {
      this.provider.getByFilter(`/movie/search`, { id: searchStr }).subscribe(
        response => {
          const jsonConvert: JsonConvert = new JsonConvert();
          observer.next(jsonConvert.deserialize(response, Movie));
        }
      );
    });
  }

  getTopRatedMovies(): Observable<Movie[]> {
    return Observable.create(observer => {
      this.provider.get(`/movie/toprated`).subscribe(
        response => {
          const jsonConvert: JsonConvert = new JsonConvert();
          observer.next(jsonConvert.deserialize(response, Movie));
        }
      );
    });
  }

  getInTheaters(): Observable<Movie[]> {
    return Observable.create(observer => {
      this.provider.get(`/movie/intheater`).subscribe(
        response => {
          const jsonConvert: JsonConvert = new JsonConvert();
          observer.next(jsonConvert.deserialize(response, Movie));
        }
      );
    });
  }

  getSimilarMovies(id: number): Observable<Movie[]> {
    return Observable.create(observer => {
      this.provider.getByFilter(`/movie/similar`, { id: id }).subscribe(
        response => {
          const jsonConvert: JsonConvert = new JsonConvert();
          observer.next(jsonConvert.deserialize(response, Movie));
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
