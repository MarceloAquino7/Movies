import { Component, OnInit } from '@angular/core';
import { MovieService } from '@collectors/movie/movie.service';

@Component({
  selector: 'app-toprated',
  templateUrl: './toprated.component.html',
  styleUrls: ['./toprated.component.scss']
})
export class TopratedComponent implements OnInit {

  current_page_top: number;
  last_page_top: number;
  topRatedList: Array<Object>;
  constructor(private _moviesService: MovieService) { }

  ngOnInit() {
    this._moviesService.getTopRatedMovies(1).subscribe(res => {
      this.topRatedList = res.Results;
      this.current_page_top = 1;
      this.last_page_top = res.Total_Pages;
    });
  }

  
  movePageFirstTopRated() {
    this._moviesService.getTopRatedMovies(1).subscribe(res => {
      this.topRatedList = res.Results;
    });
  }

  movePageLastTopRated() {
    this._moviesService.getTopRatedMovies(this.last_page_top).subscribe(res => {
      this.topRatedList = res.Results;
    });
  }

  movePageForwardTopRated() {
    if (this.current_page_top < this.last_page_top) {
      this.current_page_top += 1;
      this._moviesService.getTopRatedMovies(this.current_page_top).subscribe(res => {
        this.topRatedList = res.Results;
      });
    }
  }

  movePageBackwardTopRated() {
    if (this.current_page_top > 1) {
      this.current_page_top -= 1;
      this._moviesService.getTopRatedMovies(this.current_page_top).subscribe(res => {
        this.topRatedList = res.Results;
      });
    }
  }

}
