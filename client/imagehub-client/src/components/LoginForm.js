import React, { useState } from "react";
import { makeStyles } from "@material-ui/core/styles";
import TextField from "@material-ui/core/TextField";
import { Button } from "@material-ui/core";
import axios from "axios";

const useStyles = makeStyles((theme) => ({
  root: {
    "& > *": {
      margin: theme.spacing(1),
      width: "25ch",
    },
  },
}));

export default function LoginForm(props) {
  let [username, setUsername] = useState("");
  let [password, setPassword] = useState("SH27asdh@sdj");

  const classes = useStyles();
  const handleClick = async (action) => {
    try {
      axios("/account/"+action, {
        method: "post",
        data: { Username: username, Password: password },
        withCredentials: true,
      })
        .then((response) => {
          props.setUserData({
            Username: username,
            Id: response.data,
          });
          if(action==="login")props.setIsLoggedIn(true);
        })
        .catch((error) => console.log(error));
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <form className={classes.root}>
      <TextField
        onChange={(event) => setUsername(event.target.value)}
        label="Felhasználó"
      />
      <TextField
        onChange={(event) => setPassword(event.target.value)}
        type="password"
        label="Jelszó"
        defaultValue="SH27asdh@sdj"
      />
      <Button onClick={() => handleClick("login")} variant="contained" color="primary">
        Login
      </Button>
      <Button onClick={() => handleClick("register")} variant="contained" color="primary">
        Register
      </Button>
    </form>
  );
}
