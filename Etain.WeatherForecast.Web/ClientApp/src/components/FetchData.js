import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService'

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
      this.state = { forecasts: [], title: '', woeid: '', loading: true };
  }

  componentDidMount() {
    this.populateWeatherData();
  }

  static renderForecastsTable(forecasts) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Date</th>
            <th>Temp. (C)</th>
            <th>Temp. (F)</th>
            <th>Summary</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map(forecast =>
            <tr key={forecast.id}>
              <td>{forecast.applicable_date}</td>
              <td>{forecast.the_temp}</td>
              <td>{forecast.temperatureF}</td>
              <td>{forecast.weather_state_name}</td>
              <td><img src={forecast.stateImageUrl} alt={forecast.weather_state_name} /></td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderForecastsTable(this.state.forecasts);

    return (
        <div>
            <h1 id="tabelLabel" >Weather forecast in {this.state.title}</h1>
            <div>
                <p>Weather data from <a href="https://www.metaweather.com/api/">MetaWeather</a></p>
                <button onClick={() => this.refreshWeatherData()}>Refresh</button>
            </div>
        {contents}
      </div>
    );
  }

    refreshWeatherData() {
        window.location.reload();
    }  

  async populateWeatherData() {
    const token = await authService.getAccessToken();
    const response = await fetch('weatherforecast', {
      headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
    });
      const data = await response.json();
      this.setState({ forecasts: data.consolidated_weather, title: data.title, woeid: data.woeid, loading: false });
  }
}
