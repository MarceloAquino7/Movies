import { Component, OnInit } from '@angular/core';
import { MovieService } from '@collectors/movie/movie.service';

@Component({
  selector: 'app-upcoming',
  templateUrl: './upcoming.component.html',
  styleUrls: ['./upcoming.component.scss']
})
export class UpcomingComponent implements OnInit {
  movies: Array<Object>;
  pages: number;
  currentPage: number;

  constructor(private _moviesService: MovieService) {
    this._moviesService.getUpcoming(1).subscribe(res => {
      this.movies = res.Results;
      this.pages = res.Total_Pages;
      this.currentPage = 1;
    });
  }

  ngOnInit() {
  }

  movePageFirst() {
    this._moviesService.getUpcoming(1).subscribe(res => {
      this.movies = res.Results;
    });
  }

  movePageLast() {
    this._moviesService.getUpcoming(this.pages).subscribe(res => {
      this.movies = res.Results;
    });
  }

  movePageForward() {
    if (this.currentPage < this.pages) {
      this.currentPage += 1;
      this._moviesService.getUpcoming(this.currentPage).subscribe(res => {
        this.movies = res.Results;
      });
    }
  }

  movePageBackward() {
    if (this.currentPage > 1) {
      this.currentPage -= 1;
      this._moviesService.getUpcoming(this.currentPage).subscribe(res => {
        this.movies = res.Results;
      });
    }
  }
}
