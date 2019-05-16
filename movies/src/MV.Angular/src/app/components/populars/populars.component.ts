import { Component, OnInit } from '@angular/core';
import { MovieService } from '@collectors/movie/movie.service';

@Component({
  selector: 'app-populars',
  templateUrl: './populars.component.html',
  styleUrls: ['./populars.component.scss']
})
export class PopularsComponent implements OnInit {
  popularList: Array<Object>;
  current_page_popular: number;
  last_page_popular: number;

  constructor(private _moviesService: MovieService) { }

  ngOnInit() {
    this._moviesService.getPopular(1).subscribe(res => {
      this.popularList = res.Results;
      this.current_page_popular = 1;
      this.last_page_popular = res.Total_Pages;
    });
  }

  movePageFirstPopular() {
    this._moviesService.getPopular(1).subscribe(res => {
      this.popularList = res.Results;
    });
  }

  movePageLastPopular() {
    this._moviesService.getPopular(this.last_page_popular).subscribe(res => {
      this.popularList = res.Results;
    });
  }

  movePageForwardPopular() {
    if (this.current_page_popular < this.last_page_popular) {
      this.current_page_popular += 1;
      this._moviesService.getPopular(this.current_page_popular).subscribe(res => {
        this.popularList = res.Results;
      });
    }
  }

  movePageBackwardPopular() {
    if (this.current_page_popular > 1) {
      this.current_page_popular -= 1;
      this._moviesService.getPopular(this.current_page_popular).subscribe(res => {
        this.popularList = res.Results;
      });
    }
  }

}
