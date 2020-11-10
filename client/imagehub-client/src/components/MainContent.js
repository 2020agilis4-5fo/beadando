import React from "react";
import Feed from "./Feed";
import Profile from "./Profile";
import Upload from "./Upload";
import MenuAppBar from "./MenuAppBar.js";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import Search from "./Search";
import Requests from "./Requests";
import Friends from "./Friends";

export default function MainContent(props) {
  let data = props.userData;
  return (
    <Router>
      <div>
        <MenuAppBar />
        <Switch>
          <Route exact path="/" render={(props) => <Feed {...props} userData={data}/>} />
          <Route exact path="/feed" render={(props) => <Feed {...props} userData={data}/>} />
          <Route exact path="/requests" render={(props) => <Requests {...props} userData={data}/>} />
          <Route exact path="/friends" render={(props) => <Friends {...props} userData={data}/>} />
          <Route exact path="/profile" render={(props) => <Profile {...props} userData={data}/>} />
          <Route exact path="/upload" render={(props) => <Upload {...props} userData={data}/>} />
          <Route exact path="/search" render={(props) => <Search {...props} userData={data}/>} />
        </Switch>
      </div>
    </Router>
  );
}
