import { HttpClient } from "@angular/common/http";
import { IForecast } from "./IForecast";


export class weatherService {

  constructor(private http: HttpClient) {
    
  }

  saveWeather(input: IForecast) {
    return this.http.post<IForecast>("", input);
  }
}
