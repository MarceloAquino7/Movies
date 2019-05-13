import { Component, OnInit } from '@angular/core';
import { MovieService } from '@collectors/movie/movie.service';

@Component({
  selector: 'app-upcoming',
  templateUrl: './upcoming.component.html',
  styleUrls: ['./upcoming.component.scss']
})
export class UpcomingComponent implements OnInit {
  movies: Array<Object>;
  searchRes: Array<Object>;
  searchStr: string;

  constructor(private _moviesService: MovieService) {
    this._moviesService.getUpcoming(1).subscribe(res => {
      this.movies = res;
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
