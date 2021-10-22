import { IForecastCity } from "./IForecastCity";
import { IForecastList } from "./IForecastList";
import { IForecastWeather } from "./IForecastWeather";

export interface IForecast{
  list: IForecastList[];
  city: IForecastCity;
  weather: IForecastWeather[];
}
