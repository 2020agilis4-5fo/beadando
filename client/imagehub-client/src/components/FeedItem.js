import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import Card from "@material-ui/core/Card";
import CardHeader from "@material-ui/core/CardHeader";
import CardMedia from "@material-ui/core/CardMedia";
import AccountCircle from "@material-ui/icons/AccountCircle";
const useStyles = makeStyles((theme) => ({
  media: {
    height: 0,
    paddingTop: "56.25%", // 16:9
  }
}));

export default function FeedItem(props) {
  const classes = useStyles();

  return (
    <Card variant="outlined" className={classes.root}>
      <CardHeader
        avatar={
            <AccountCircle />
        }
        title={props.name}
      />
      <CardMedia
        className={classes.media}
        image={props.img}
        title="Feed photo"
      />
    </Card>
  );
}
