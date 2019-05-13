import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MovieComponent } from '@components/movie/movie.component';
import { UpcomingComponent } from '@components/upcoming/upcoming.component';
import { AppComponent } from './app.component';
import { GenresComponent } from '@components/genres/genres.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: AppComponent },
  { path: 'movie/:id', component: MovieComponent },
  { path: 'genres/:id/:name', component: GenresComponent },
  { path: 'upcoming', component: UpcomingComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
