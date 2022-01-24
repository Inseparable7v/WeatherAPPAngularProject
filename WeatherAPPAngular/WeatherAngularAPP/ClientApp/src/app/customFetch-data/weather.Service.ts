import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IWeatherHistory } from "../fetch-data/IWeatherHistory";
import { IGeoLocation } from "../weatherByGeoLocation-data/IGeoLocation";
import { IForecast } from "./IForecast";

@Injectable({ providedIn: 'root' })
export class weatherService {
  options = { headers: { 'Content-Type': 'application/json; charset=UTF-8' } };

  constructor(private http: HttpClient) {

  }

  saveWeather(input: string): Observable<string> {
    return this.http.post<string>("api/weather/save-all", JSON.stringify({data:input}), this.options);
  }

  getById(id: number): Observable<number> {
    return this.http.get<number>('api/weather/byid/' + id, this.options);
  }

  weatherApiCall(cityName: string): Observable<IForecast> {
    return this.http.get<IForecast>(`https://community-open-weather-map.p.rapidapi.com/forecast?q=${cityName}&units=metric`, {
      headers: {
        "x-rapidapi-host": "community-open-weather-map.p.rapidapi.com",
        "x-rapidapi-key": "bb6a7cadeamsh5025cc4c9b84502p197544jsnd35d63e6ea07"
      }
    });
  }

  weatherApiCallGeoLocation(): Observable<IGeoLocation> {
    return this.http.get<IGeoLocation>(`https://ip-geo-location.p.rapidapi.com/ip/check?format=json&filter=city`,
      {
        headers: {
          "x-rapidapi-host": "ip-geo-location.p.rapidapi.com",
          "x-rapidapi-key": "bb6a7cadeamsh5025cc4c9b84502p197544jsnd35d63e6ea07"
        }
      });
  }

  weatherApiCallGetAllHistories(): Observable<IWeatherHistory[]> {
    return this.http.get<IWeatherHistory[]>('api/weather/all');
  }
}
