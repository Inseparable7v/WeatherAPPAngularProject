import { IForecastCity } from "./IForecastCity";
import { IForecastList } from "./IForecastList";
import { IForecatsWeather } from "./IForecastWeather";

export interface IForecats{
  list: IForecastList;
  city: IForecastCity;
  weather: IForecatsWeather;
}
