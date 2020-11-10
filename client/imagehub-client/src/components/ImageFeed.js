import React from "react";
import FeedItem from "./FeedItem";
import "./Feed.css";

export default function ImageFeed(props) {
  let data = props.data;
  let content = [];
  for (let i = 0; i < data.length; i++) {
    content.push(
      <div key={i} className="box">
        {
          <FeedItem
            name={data[i].name}
            img={`data:image/png;base64,${data[i].base64EncodedImage}`}
          />
        }
      </div>
    );
  }
  return <div className="container--feed">{content}</div>;
}
