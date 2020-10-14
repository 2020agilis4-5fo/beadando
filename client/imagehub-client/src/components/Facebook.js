import React from 'react'
import FacebookLogin from 'react-facebook-login';



export default function Facebook(props) {
    let componentClicked = () => console.log('clicked')
    let responseFacebook = response =>{
        if(response.name){
            props.setIsLoggedIn(true)
            props.setUserData(response)
        }
    }
    return (
        <FacebookLogin
    appId="2122090571268724"
    autoLoad={true}
    fields="name,email"
    onClick={componentClicked}
    callback={responseFacebook} />
    )
}
