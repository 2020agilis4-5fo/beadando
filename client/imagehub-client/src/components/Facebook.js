import React from 'react'
import FacebookLogin from 'react-facebook-login';
import axios from "axios";


const api = axios.create(
    {
      baseURL: 'https://localhost:44380/api/account'
    }
  )


export default function Facebook(props) {
    let componentClicked = () => console.log('clicked')
    let responseFacebook = response =>{
        if(response.email){
            let username = response.email.split("@")[0]
            let password = "SH27asdh@sdj"
            api.post('/register',{
                Username: username,
                Password: password
            }).catch((error)=>
            {
                api.post('/login',{
                    Username: username,
                    Password: password
                })
            }
            ).then(()=>{
                props.setIsLoggedIn(true)
                props.setUserData(response)
            })
            
        }
    }
    return (
        <FacebookLogin
    appId="2122090571268724"
    autoLoad={false}
    fields="name,email"
    onClick={componentClicked}
    callback={responseFacebook} />
    )
}
