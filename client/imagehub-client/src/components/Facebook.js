import React from 'react';
import FacebookLogin from 'react-facebook-login';
import axios from 'axios';
import { Contacts } from '@material-ui/icons';

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
  const responseFacebook = (response) => {
    if (response.email) {
      console.log(response);
      axios('https://localhost:44380/api/account/callback', {
        method: 'post',
        data: {
          email: response.email,
          accessToken: response.accessToken,
          userId: response.id
        },
        withCredentials: true
      })
        .then((response) => {
          console.log(response);
          props.setIsLoggedIn(true);
        })
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
