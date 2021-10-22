import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IForecast } from "./IForecast";

@Injectable({ providedIn: 'root' })
export class weatherService {
  options = { headers: { 'Content-Type': 'application/json' } };
  
  constructor(private http: HttpClient) {
    
  }

  saveWeather(input: string): Observable<string> {
    return this.http.post<string>("api/weather/SaveAll", { save: 'Test' }, this.options);
  }

  weatherApiCall(cityName: string): Observable<IForecast> {
    return this.http.get<IForecast>(`https://community-open-weather-map.p.rapidapi.com/forecast?q=${cityName}&units=metric`, {
      headers: {
        "x-rapidapi-host": "community-open-weather-map.p.rapidapi.com",
        "x-rapidapi-key": "bb6a7cadeamsh5025cc4c9b84502p197544jsnd35d63e6ea07"
      }
    });
  }
}
