import { Route } from "@angular/compiler/src/core";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { IForecast } from "../customFetch-data/IForecast";
import { weatherService } from "../customFetch-data/weather.Service";

@Component({
  selector: 'pm-weather-detail',
  templateUrl: './weather-detail.component.html'
})

export class WeatherDetailComponent implements OnInit {
  constructor(private routeActive: ActivatedRoute, private route: Router, private weatherService: weatherService) { }

  pageTittle: string = "Weather Detail";
  cityName: string = '';
  forecastDetail: IForecast | undefined;

  fillterWeatherDetail() {
    this.weatherService.weatherApiCall(this.cityName).subscribe(result => this.forecastDetail = result);
  }

  ngOnInit(): void {
    this.cityName = this.routeActive.snapshot.paramMap.get('id');
    console.log(this.routeActive.snapshot.paramMap.get('id'));
    this.pageTittle += `: ${this.cityName}`;
  }
  onBack(): void {
    this.route.navigate(['/customfetch-data']);
  }
}
