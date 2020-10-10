import React from "react";
import Feed from "./Feed";
import Profile from "./Profile";
import Upload from "./Upload";
import MenuAppBar from "./MenuAppBar.js";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import Search from "./Search";

export default function MainContent() {
  return (
    <Router>
      <div>
        <MenuAppBar />
        <Switch>
          <Route path="/feed" component={Feed} />
          <Route path="/profile" component={Profile} />
          <Route path="/upload" component={Upload} />
          <Route path="/search" component={Search} />
        </Switch>
      </div>
    </Router>
  );
}
