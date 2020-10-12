import React from 'react'
import FacebookLogin from 'react-facebook-login';



export default function Facebook(props) {
    let componentClicked = () => console.log('clicked')
    let responseFacebook = response =>{
        // console.log(response);
        if(response.email){
            props.setIsLoggedIn(true)
        }
    }
    return (
        <FacebookLogin
    appId="2122090571268724"
    autoLoad={true}
    fields="name,email,picture"
    onClick={componentClicked}
    callback={responseFacebook} />
    )
}
