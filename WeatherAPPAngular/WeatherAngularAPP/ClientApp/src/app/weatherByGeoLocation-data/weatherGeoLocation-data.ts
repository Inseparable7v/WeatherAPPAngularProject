import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { IForecast } from "../customFetch-data/IForecast";
import { weatherService } from "../customFetch-data/weather.Service";
import { IGeoLocation } from "./IGeoLocation";

@Component({
  selector: "app-weathergeolocation-data",
  templateUrl: "./weatherGeoLocation-data.html"
})
export class weatherGeoLocationDataComponent implements OnInit {
  public geoLocationData: IGeoLocation | undefined;
  public forecasts: IForecast;
  public iconSrc: string;

  constructor(private http: HttpClient, private weatherService: weatherService) {
    this.iconSrc = 'http://openweathermap.org/img/wn/';
  }

  ngOnInit(): void {
    this.weatherApiCallByVisitor();
  }

  weatherApiCallByVisitor(): void {
    this.weatherService.weatherApiCallGeoLocation().subscribe(geoLocationDataApiCall => {
      this.geoLocationData = geoLocationDataApiCall;

      this.submit(geoLocationDataApiCall.city.name);
    });
  }

  submit(cityName: string): void {
    this.weatherService.weatherApiCall(cityName).subscribe(result => {
      this.forecasts = result,
        console.log(result)
    }), error => { throw Error("Incorrect data") };

  }

  ShowIconImg(iconImg: string): string {
    return this.iconSrc + iconImg + "@2x.png";
  }
}
