import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MovieComponent } from '@components/movie/movie.component';
import { UpcomingComponent } from '@components/upcoming/upcoming.component';
import { AppComponent } from './app.component';
import { TopratedComponent } from '@components/toprated/toprated.component';
import { PopularsComponent } from '@components/populars/populars.component';
import { GenresComponent } from '@components/genres/genres.component';

const routes: Routes = [
  { path: '', redirectTo: 'upcoming', pathMatch: 'full' },
  { path: 'movie/:id', component: MovieComponent },
  { path: 'genres/:id/:name', component: GenresComponent },
  { path: 'upcoming', component: UpcomingComponent },
  { path: 'top-rated', component: TopratedComponent },
  { path: 'populars', component: PopularsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
