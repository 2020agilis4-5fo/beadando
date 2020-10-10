import React from "react";
import Card from "@material-ui/core/Card";
import CardActions from "@material-ui/core/CardActions";
import CardContent from "@material-ui/core/CardContent";
import Button from "@material-ui/core/Button";
import "./Login.css";

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
          </CardContent>
          <CardActions>
            <Button
              className="button--login"
              variant="contained"
              onClick={() => props.setIsLoggedIn(true)}
              color="primary"
            >
              Belépés
            </Button>
          </CardActions>
        </div>
      </Card>
    </div>
  );
}
