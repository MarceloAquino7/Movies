import { Component, OnInit } from '@angular/core';
import { MovieService } from '@collectors/movie/movie.service';
@Component({
  selector: 'movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.scss']
})
export class MoviesComponent implements OnInit {
  popularList: Array<Object>;
  theatersList: Array<Object>;
  topRatedList: Array<Object>;
  searchRes: Array<Object>;
  searchStr: string;
  constructor(private _moviesService: MovieService) {
    this._moviesService.getPopular().subscribe(res => {
      this.popularList = res;
    });
    this._moviesService.getInTheaters().subscribe(res => {
      this.theatersList = res;
    });
    this._moviesService.getTopRatedMovies().subscribe(res => {
      this.topRatedList = res;
    });
  }

  ngOnInit() {
  }

  searchMovies() {
    this._moviesService.searchMovies(this.searchStr).subscribe(res => {
      this.searchRes = res;
    })
  }

}
