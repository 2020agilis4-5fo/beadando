import React from 'react';
import ListItem from '@material-ui/core/ListItem';
import ListItemSecondaryAction from '@material-ui/core/ListItemSecondaryAction';
import ListItemText from '@material-ui/core/ListItemText';
import ListItemAvatar from '@material-ui/core/ListItemAvatar';
import Avatar from '@material-ui/core/Avatar';
import IconButton from '@material-ui/core/IconButton';
import PersonAddIcon from '@material-ui/icons/PersonAdd';

export default function UserItem(props) {
  return (
          <ListItem  button>
            <ListItemAvatar>
              <Avatar/>
            </ListItemAvatar>
            <ListItemText id={1} primary={props.userName}/>
            <ListItemSecondaryAction>
            <IconButton edge="end" aria-label="comments" onClick={props.sendFriendRequest}>
               <PersonAddIcon/>
              </IconButton >
            </ListItemSecondaryAction>
          </ListItem>
  );
}