import {
  Avatar,
    Box,
  List,
  ListItem,
  ListItemAvatar,
  ListItemText,
  makeStyles,
} from "@material-ui/core";
import axios from "axios";
import React, { useState, useEffect } from "react";

function CreateFriendItems(data) {
  let friends = [];
  for (let i = 0; i < data.length; i++) {
    friends.push(
      <ListItem alignItems="felx-start" key={i} button>
        <ListItemAvatar>
          <Avatar />
        </ListItemAvatar>
        <ListItemText id={data[i].id} primary={data[i].username} />
      </ListItem>
    );
  }
  return friends;
}

const useStyles = makeStyles((theme) => ({
  root: {
    width: "100%",
    maxWidth: 360,
    backgroundColor: theme.palette.background.paper,
  },
}));

export default function Friends(props) {
  let [friends, setFriends] = useState([]);
  const classes = useStyles();
  useEffect(() => {
    const fetchFriendRequests = async () => {
      try {
        axios("/friend/" + props.userData.Id, {
          method: "get",
          withCredentials: true,
        })
          .then((response) => {
            console.log("Friend list loaded.");
            setFriends(CreateFriendItems(response.data.friends));
            console.log(response.data.friends);
          })
          .catch((error) => console.log(error));
      } catch (error) {
        console.log(error);
      }
    };

    console.log("Loading friends..");
    fetchFriendRequests();
  }, [props]);

  return (
    <div>
    <Box display="flex" justifyContent="flex-start" m={1} p={1}>
      <Box p={1}>
        <h1>Barátok</h1>
      </Box>
    </Box>
    <Box display="flex" justifyContent="center">
    <List className={classes.root}>{friends}</List>
    </Box>
  </div>
  );
  
}
