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

  public fetchData(): any {
    return this.http.get<IForecast>(`https://community-open-weather-map.p.rapidapi.com/forecast?q=${this.cityName}&units=metric`, {
      headers: {
        "x-rapidapi-host": "community-open-weather-map.p.rapidapi.com",
        "x-rapidapi-key": "bb6a7cadeamsh5025cc4c9b84502p197544jsnd35d63e6ea07"
      }
    }).subscribe(result => {
      this.forecasts = result,
        console.log(result)
    }), error => { throw Error("Incorrect data") }
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
