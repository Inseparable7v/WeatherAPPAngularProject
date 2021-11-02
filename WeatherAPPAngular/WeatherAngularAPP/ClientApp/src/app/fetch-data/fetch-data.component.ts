import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IWeatherHistory } from './IWeatherHistory';
import { weatherService } from '../customFetch-data/weather.Service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: IWeatherHistory[];

  constructor(private weatherService: weatherService) {
    this.weatherService.weatherApiCallGetAllHistories().subscribe(result => {
      this.forecasts = result, console.log(result);
    }, error => console.error(error));
  }
}


