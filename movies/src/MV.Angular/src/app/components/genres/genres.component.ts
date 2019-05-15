import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MovieService } from '@collectors/movie/movie.service';

@Component({
  selector: 'app-genres',
  templateUrl: './genres.component.html',
  styleUrls: ['./genres.component.scss']
})
export class GenresComponent implements OnInit {
  Title: string;
  movies: Array<Object>;

  constructor(
    private _moviesServices: MovieService,
    private router: ActivatedRoute ) {

  }

  ngOnInit() {
    this.router.params.subscribe((params) => {
      const id = params['id'];
      this.Title = params['name'];
      this._moviesServices.getMoviesByGenre(id).subscribe(res => {
        this.movies = res;
      });
    })
  }

}
