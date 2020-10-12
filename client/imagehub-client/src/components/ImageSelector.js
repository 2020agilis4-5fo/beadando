import React from "react";
import "./Upload.css";
import Button from "@material-ui/core/Button";
import { makeStyles } from "@material-ui/core/styles";

const useStyles = makeStyles((theme) => ({
  input: {
    display: "none",
  },
}));

export default function ImageSelector(props) {
  const classes = useStyles();
  let imageHandler = (e) => {
    const reader = new FileReader();
    reader.onload = () => {
      if (reader.readyState === 2) {
        props.setImage(reader.result);
        props.setSelected(true);
      }
    };
    reader.readAsDataURL(e.target.files[0]);
  };

  return (
    <div>
      <div className="image-placeholder">
        <input
          className={classes.input}
          id="imgSelect"
          type="file"
          onChange={imageHandler}
        />
        <img src={props.image} alt="" id="img" className="img" />
        <label htmlFor="imgSelect">
          <Button variant="contained" color="primary" component="span">
            Tallózás
          </Button>
        </label>
      </div>
    </div>
  );
}
