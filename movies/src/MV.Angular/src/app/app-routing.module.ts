import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MovieComponent } from '@components/movie/movie.component';
import { UpcomingComponent } from '@components/upcoming/upcoming.component';
import { AppComponent } from './app.component';
import { GenresComponent } from '@components/genres/genres.component';
import { MoviesComponent } from '@components/movies/movies.component';

const routes: Routes = [
  { path: '', redirectTo: 'movies', pathMatch: 'full' },
  { path: 'movies', component: MoviesComponent },
  { path: 'movie/:id', component: MovieComponent },
  { path: 'genres/:id/:name', component: GenresComponent },
  { path: 'upcoming', component: UpcomingComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
