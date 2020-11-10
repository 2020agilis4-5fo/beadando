import React from "react";
import FacebookLogin from "react-facebook-login";
import axios from "axios";

/*function login(username, password, props) {
  api
    .post("/login", {
      Username: username,
      Password: password,
    })
    .then((response) => {
      props.setIsLoggedIn(true);
      props.setUserData({
        Username: username,
        Id: response.data,
      });
    });
}*/

export default function Facebook(props) {
  let responseFacebook = (response) => {
    if (response.email) {
      let username = response.email.split("@")[0];
      let password = "SH27asdh@sdj";
      axios("/account/login", {
        method: "post",
        data: { Username: "bolcskey.tamas", Password: password },
        withCredentials: true,
      })
        .then((response) => {
          props.setUserData({
            Username: username,
            Id: response.data,
          });
          props.setIsLoggedIn(true);
        });
    }
  };
  return (
    <FacebookLogin
      appId="2122090571268724"
      autoLoad={false}
      fields="name,email"
      callback={responseFacebook}
    />
  );
}
