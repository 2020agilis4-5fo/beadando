import { List, makeStyles } from "@material-ui/core";
import axios from "axios";
import React from "react";
import FriendRequestItem from "./FriendRequestItem";

const useStyles = makeStyles((theme) => ({
  root: {
    width: "100%",
    maxWidth: 360,
    backgroundColor: theme.palette.background.paper,
  },
}));

function FriendRequestAction(from, action) {
  return (to) => {
    console.log("from: " + from + " to: " + to + ", action: " + action);
    try {
      axios("/friend/req/" + action, {
        method: "post",
        data: { FromId: from, ToId: to },
        withCredentials: true,
      })
        .then((response) => {})
        .catch((error) => console.log(error));
    } catch (error) {
      console.log(error);
    }
  };
}

export default function FriendRequestList(props) {
  const classes = useStyles();
  let acceptFriendRequest = FriendRequestAction(props.userData.Id, "accept");
  let cancelFriendRequest = FriendRequestAction(props.userData.Id, "cancel");
  let content = [];
  let recipients = props.data.recipients;
  for (let i = 0; i < recipients.length; i++) {
    content.push(
      <FriendRequestItem
        key={i}
        userName={recipients[i].username}
        acceptFriendRequest={() => acceptFriendRequest(recipients[i].id)}
        cancelFriendRequest={() => cancelFriendRequest(recipients[i].id)}
      />
    );
  }
  return <List className={classes.root}>{content}</List>;
}
