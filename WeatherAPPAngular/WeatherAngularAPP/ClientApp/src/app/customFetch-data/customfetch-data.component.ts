import { HttpClient } from "@angular/common/http";
import { error } from "@angular/compiler/src/util";
import { Component, ElementRef, OnInit } from "@angular/core";

@Component({
  selector: 'app-customfetch-data',
  templateUrl: './customfetch-data.component.html'
})

export class CustomFetchDataComponent {

  public forecasts: WeatherForecast;
  public daysOfTheWeek: Day[] = [];
  public iconSrc: string;
  public baseUrlForImg: string;
  public http: HttpClient;

  constructor(http: HttpClient) {
    this.http = http;
    this.iconSrc = 'http://openweathermap.org/img/wn/';
    this.baseUrlForImg = 'http://openweathermap.org/img/wn/';
  }

  public fetchData(cityName: string) {
    this.forecasts.daysOfTheWeek1 = this.daysOfTheWeek;
    return this.http.get<WeatherForecast>(`https://community-open-weather-map.p.rapidapi.com/forecast?q=${cityName}&units=metric`, {
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
    this.getDaysOfTheWeek();
    this.forecasts = {
      list: [],
      daysOfTheWeek1: this.daysOfTheWeek
    }
    console.log(this.forecasts.daysOfTheWeek1);
    this.fetchData(name);
  }

  public getDaysOfTheWeek() {
    let currDay = new Date().getDay();
    let weekday = new Array(7);
    weekday[0] = "Sunday";
    weekday[1] = "Monday";
    weekday[2] = "Tuesday";
    weekday[3] = "Wednesday";
    weekday[4] = "Thursday";
    weekday[5] = "Friday";
    weekday[6] = "Saturday";

    for (var i = 0; i < weekday.length; i++) {
      if (currDay > 6) {
        currDay = 0;
      }
      this.daysOfTheWeek.push(weekday[currDay++]);
    }
  }
}

interface WeatherForecast {
  list: [],
  daysOfTheWeek1: Day[]
}

interface Day {
  name: string;
}
