import React, { useState } from "react";
import ListItem from "@material-ui/core/ListItem";
import ListItemSecondaryAction from "@material-ui/core/ListItemSecondaryAction";
import ListItemText from "@material-ui/core/ListItemText";
import ListItemAvatar from "@material-ui/core/ListItemAvatar";
import Avatar from "@material-ui/core/Avatar";
import IconButton from "@material-ui/core/IconButton";
import BlockIcon from "@material-ui/icons/Block";
import CheckCircleOutlineIcon from "@material-ui/icons/CheckCircleOutline";

export default function FriendRequestItem(props) {
  let [isDisabled, setIsDisabled] = useState(false);

  return (
    <ListItem button>
      <ListItemAvatar>
        <Avatar />
      </ListItemAvatar>
      <ListItemText id={1} primary={props.userName} />
      <ListItemSecondaryAction>
        <IconButton
          disabled={isDisabled}
          edge="end"
          aria-label="comments"
          onClick={() => {
            props.acceptFriendRequest();
            setIsDisabled(true);
          }}
        >
          <CheckCircleOutlineIcon />
        </IconButton>
        <IconButton
          disabled={isDisabled}
          edge="end"
          aria-label="comments"
          onClick={() => {
            props.cancelFriendRequest();
            setIsDisabled(true);
          }}
        >
          <BlockIcon />
        </IconButton>
      </ListItemSecondaryAction>
    </ListItem>
  );
}
