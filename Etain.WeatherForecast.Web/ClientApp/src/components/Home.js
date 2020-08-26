import React, { Component } from 'react';
import { NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import { LoginMenu } from './api-authorization/LoginMenu';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Hello, there!</h1>
        <p>Welcome to Etain Weather Forecast App</p>
        <ul>
            <NavItem>
                <NavLink tag={Link} to="/fetch-data">Weather Forecast</NavLink>
            </NavItem>
            <LoginMenu></LoginMenu>
        </ul>
      </div>
    );
  }
}
