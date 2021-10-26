import { HttpClient } from "@angular/common/http";
import { Component, ElementRef, OnInit } from "@angular/core";
import { IForecast } from "./IForecast";
import { weatherService } from "./weather.Service";

@Component({
  selector: 'app-customfetch-data',
  templateUrl: './customfetch-data.component.html'
})

export class CustomFetchDataComponent {
  cityName: string = '';
  public forecasts: IForecast;
  public iconSrc: string;
  saveAllApiCall: string = 'Test';

  constructor(private http: HttpClient, private weatherService: weatherService) {
    this.iconSrc = 'http://openweathermap.org/img/wn/';
  }

  public ShowIconImg(iconImg: string): string {
    return this.iconSrc + iconImg + "@2x.png";
  }

  submit(): void {
    this.weatherService.weatherApiCall(this.cityName).subscribe(result => {
      this.forecasts = result,
        console.log(result)
    }), error => { throw Error("Incorrect data") };
  }

  saveWeather(): void {
    this.weatherService.saveWeather(this.saveAllApiCall).subscribe();
  }
}
