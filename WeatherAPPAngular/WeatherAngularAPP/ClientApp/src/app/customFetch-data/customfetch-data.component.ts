import { HttpClient } from "@angular/common/http";
import { Component, ElementRef, OnInit } from "@angular/core";
import { IForecats } from "./IForecast";

@Component({
  selector: 'app-customfetch-data',
  templateUrl: './customfetch-data.component.html'
})

export class CustomFetchDataComponent {

  public forecasts: IForecats;
  public iconSrc: string;
  public http: HttpClient;

  constructor(http: HttpClient) {
    this.http = http;
    this.iconSrc = 'http://openweathermap.org/img/wn/';
  }

  public fetchData(cityName: string) {
    return this.http.get<IForecats>(`https://community-open-weather-map.p.rapidapi.com/forecast?q=${cityName}&units=metric`, {
      headers: {
        "x-rapidapi-host": "community-open-weather-map.p.rapidapi.com",
        "x-rapidapi-key": "bb6a7cadeamsh5025cc4c9b84502p197544jsnd35d63e6ea07"
      }
    }).subscribe(result => { this.forecasts = result, console.log(result) }), error => { throw Error("Incorrect data") }
  }

  public ShowIconImg(iconImg: string) {
    return this.iconSrc + iconImg + "@2x.png";
  }

  public submit(name: string) {
    this.fetchData(name);
  }
}
