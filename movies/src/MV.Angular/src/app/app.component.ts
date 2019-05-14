import { Component, OnInit } from '@angular/core';
import { MovieService } from '@collectors/movie/movie.service';
import { Genre } from '@classes/genre';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'movies';

  genres: Genre[] = [];
  clean = false;

  constructor(private movieService: MovieService) { }

  ngOnInit() {
  }

  cleanSearch() {
    this.clean = true;
  }

  resetClean() {
    this.clean = false;
  }

}
