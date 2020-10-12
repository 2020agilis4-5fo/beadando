import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import AppBar from "@material-ui/core/AppBar";
import Toolbar from "@material-ui/core/Toolbar";
import Typography from "@material-ui/core/Typography";
import IconButton from "@material-ui/core/IconButton";
import AccountCircle from "@material-ui/icons/AccountCircle";
import PublishIcon from "@material-ui/icons/Publish";
import SearchIcon from "@material-ui/icons/Search";
import AppsIcon from "@material-ui/icons/Apps";
import { Link } from "react-router-dom";

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
  },
  title: {
    flexGrow: 1,
  },
  link: {
    textDecoration: "none",
    color: "white",
  },
}));

export default function MenuAppBar() {
  const classes = useStyles();

  return (
    <div className={classes.root}>
      <AppBar position="static">
        <Toolbar>
          <Typography variant="h6" className={classes.title}>
            ImageHub
          </Typography>
          <div>
            <IconButton>
              <Link to="/feed" className={classes.link}>
                <AppsIcon />
              </Link>
            </IconButton>
            <IconButton>
              <Link to="/profile" className={classes.link}>
                <AccountCircle />
              </Link>
            </IconButton>
            <IconButton>
              <Link to="/search" className={classes.link}>
                <SearchIcon />
              </Link>
            </IconButton>
            <IconButton>
              <Link to="/upload" className={classes.link}>
                <PublishIcon />
              </Link>
            </IconButton>
          </div>
        </Toolbar>
      </AppBar>
    </div>
  );
}
