import { Route } from "@angular/compiler/src/core";
import { Component, Input, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { IForecast } from "../customFetch-data/IForecast";
import { weatherService } from "../customFetch-data/weather.Service";
import { storageService } from "../Shared/StorageService";

@Component({
  selector: 'pm-weather-detail',
  templateUrl: './weather-detail.component.html'
})

export class WeatherDetailComponent implements OnInit {
  pageTittle: string = "Weather Detail";
  cityName: string = '';
  index: number = 0;
  forecastDetail: IForecast | undefined;
  iconSrc: string;

  constructor(private routeActive: ActivatedRoute, private route: Router, private weatherService: weatherService, private storageService: storageService) {
    this.iconSrc = 'http://openweathermap.org/img/wn/';
  }
  

  fillterWeatherDetail() {
    this.weatherService.weatherApiCall(this.cityName).subscribe(result => this.forecastDetail = result);
  }

  ngOnInit(): void {
    this.cityName = this.routeActive.snapshot.paramMap.get('cityName');
    this.index = Number(this.routeActive.snapshot.paramMap.get('id'));
    this.forecastDetail = JSON.parse(this.storageService.get(this.cityName));
    //console.log(this.routeActive.snapshot.paramMap.get('cityName'));
    //console.log(this.index);
    this.forecastDetail.list = this.forecastDetail.list.filter(x => x.dt == this.index);
    console.log(this.forecastDetail.list)
    this.pageTittle += `: ${this.cityName}`;
  }

  onBack(): void {
    this.route.navigate(['/customfetch-data']);
  }

  ShowIconImg(iconImg: string): string {
    return this.iconSrc + iconImg + "@2x.png";
  }
}
