import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { MovieService } from '@collectors/movie/movie.service';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.scss']
})
export class MovieComponent implements OnInit {
  movie: Object;
  reviews: Array<Object>;
  similarMovies: Array<Object>;
  cast: Array<Object>;
  video: Object;
  constructor(
    private _moviesServices: MovieService,
    private router: ActivatedRoute,
    private sanitizer: DomSanitizer
  ) {

  }

  ngOnInit() {
    this.router.params.subscribe((params) => {
      const id = params['id'];
      this._moviesServices.getMovie(id).subscribe(movie => {
        this.movie = movie;
      });
      this._moviesServices.getMovieReviews(id).subscribe(res => {
        this.reviews = res;
      });
      this._moviesServices.getMovieCredits(id).subscribe(res => {
        res.Cast = res.Cast.filter((item) => { return item.Profile_Path });
        this.cast = res.Cast.slice(0, 4);
      });
      this._moviesServices.getMovieVideos(id).subscribe(res => {
        if (res && res.length) {
          this.video = res[0];
          this.video['url'] = this.sanitizer.bypassSecurityTrustResourceUrl('https://www.youtube.com/embed/' + this.video['key']);
        }
      });
      this._moviesServices.getSimilarMovies(id).subscribe(res => {
        console.log(res);
        this.similarMovies = res.slice(0, 12);
      });
    })
  }

}
