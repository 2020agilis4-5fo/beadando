import React from "react";
import "./Profile.css";
import "./Feed.css";
import { TextField } from "@material-ui/core";

export default function Search() {
  return (
    <div>
      <div className="container--profile">
        <h1>Felhasználó keresés</h1>
      </div>
      <div className="container--feed">
        <TextField
          id="outlined-secondary"
          label="Felhasználó neve:"
          variant="outlined"
          color="secondary"
        />
      </div>
    </div>
  );
}
