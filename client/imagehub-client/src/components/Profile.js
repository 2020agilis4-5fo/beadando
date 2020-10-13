import React from "react";
import Feed from "./Feed";
import "./Profile.css";

export default function Profile(props) {
  console.log(props.userData);
  return (
    <div>
      <div className="container--profile">
        <h1>{props.userData.name}</h1>
        <h2>{props.userData.email}</h2>
      </div>
      <Feed />
    </div>
  );
}
