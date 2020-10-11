import React from "react";
import FeedItem from "./FeedItem";
import "./Feed.css";

export default function Feed() {
  let content = [];

  for (let i = 0; i < 10; i++) {
    content.push(
      <div key={i} className="box">
        {
          <FeedItem
            name={"User" + i}
            img={require("../assets/img_placeholder.svg")}
          />
        }
      </div>
    );
  }

  return <div className="container">{content}</div>;
}
