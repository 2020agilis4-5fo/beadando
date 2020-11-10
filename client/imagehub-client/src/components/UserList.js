import { List } from '@material-ui/core';
import React from 'react'
import UserItem from './UserItem';
import { makeStyles } from '@material-ui/core/styles';
import axios from 'axios';

const useStyles = makeStyles((theme) => ({
    root: {
      width: '100%',
      maxWidth: 360,
      backgroundColor: theme.palette.background.paper,
    },
  }));

function SendFriendRequest(from){
    return (to)=>{
        console.log("from: "+from+" to: " +to)
        try{
            axios("/friend/req",{
                method: "post",
                data: {FromId: from, ToId: to},
                withCredentials: true
            })
            .then((response)=>{
                console.log(response)
            })
            .catch((error)=>console.log(error));
        }catch(error){
            console.log(error);
        }
    }
}

export default function UserList(props) {
    let sendFriendRequest = SendFriendRequest(props.userData.Id);
    const classes = useStyles();
    let data = props.data
    let content=[];
    for (let i = 0; i < data.length; i++) {
        content.push(<UserItem key={i} id={data[i].id} userName={data[i].username} sendFriendRequest={() => sendFriendRequest(data[i].id)}/>)
    }
    return (
        <List className={classes.root}>
        {content}
      </List>
    )
}
