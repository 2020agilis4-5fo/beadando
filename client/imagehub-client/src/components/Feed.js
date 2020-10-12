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
            img={"https://picsum.photos/id/"+(i+Math.floor(Math.random() * 30))+"/355/200"}
          />
        }
      </div>
    );
  }

  return <div className="container--feed">{content}</div>;
}
