import React from "react";
import Card from "@material-ui/core/Card";
import CardContent from "@material-ui/core/CardContent";
import "./Login.css";
import Facebook from "./Facebook";

export default function Login(props) {
  return (
    <div className="container--login">
      <div className="blur"></div>
      <Card className="card--login">
        <div className="centered">
          <CardContent>
            <p>
              Üdvözlünk az ImageHub oldalán! A továbblépéshez használd a
              facebookodat!
            </p>
            <Facebook setIsLoggedIn={props.setIsLoggedIn} />
          </CardContent>
        </div>
      </Card>
    </div>
  );
}
