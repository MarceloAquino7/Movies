import { NgModule } from '@angular/core';

import * as AngularModule from './app.submodule.angular';
import * as ComponentsModule from './app.submodule.components';
import * as ProvidersModule from './app.submodule.providers';
import * as ThirdModule from './app.submodule.thirdpart';

import { AppRoutingModule } from './app-routing.module';
import { IProvider } from '@services/interfaces/iprovider.service';
import { HttpService } from '@services/http/http.service';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { SearchComponent } from './components/search/search.component';


@NgModule({
  declarations: [
    ComponentsModule.AppComponent,
    ComponentsModule.MovieCardComponent,
    ComponentsModule.MovieComponent,
    ComponentsModule.UpcomingComponent,
    ComponentsModule.TopratedComponent,
    ComponentsModule.PopularsComponent,
    ComponentsModule.GenresComponent,
    SearchComponent
  ],
  imports: [
    AngularModule.BrowserModule,
    AngularModule.BrowserAnimationsModule,
    AngularModule.FormsModule,
    AngularModule.ReactiveFormsModule,
    ThirdModule.MatButtonModule,
    ThirdModule.MatCardModule,
    ThirdModule.MatDialogModule,
    ThirdModule.MatIconModule,
    ThirdModule.MatInputModule,
    ThirdModule.MatMenuModule,
    ThirdModule.MatProgressSpinnerModule,
    ThirdModule.MatTableModule,
    ThirdModule.MatToolbarModule,
    ThirdModule.MatDatepickerModule,
    ThirdModule.MatNativeDateModule,
    AngularModule.HttpClientModule,
    AppRoutingModule,
    NoopAnimationsModule
  ],
  providers: [
    { provide: IProvider, useClass: HttpService }
  ],
  bootstrap: [
    ComponentsModule.AppComponent
  ]
})
export class AppModule { }
