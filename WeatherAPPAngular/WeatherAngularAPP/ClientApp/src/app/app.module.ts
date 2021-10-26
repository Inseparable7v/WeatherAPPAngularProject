import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { CustomFetchDataComponent } from './customFetch-data/customfetch-data.component';
import { WeatherDetailComponent } from './detailedWeather-data/weather-detail.component';
import { weatherGeoLocationDataComponent } from './weatherByGeoLocation-data/weatherGeoLocation-data';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    CustomFetchDataComponent,
    WeatherDetailComponent,
    weatherGeoLocationDataComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'customfetch-data', component: CustomFetchDataComponent },
      { path: 'weather-detail/:id', component: WeatherDetailComponent },
      { path: 'weathergeolocation-data', component: weatherGeoLocationDataComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
