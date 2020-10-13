import React, { useState, useEffect } from "react";
import FeedItem from "./FeedItem";
import "./Feed.css";
import axios from "axios";
import { CircularProgress } from "@material-ui/core";

function GenerateFeedItems(data) {
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
  return content;
}

export default function Feed() {
  let [data, setData] = useState([]);
  let [isLoaded, setIsLoaded] = useState(false);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const result = await axios("https://localhost:44380/api/image");

        setData(result.data);
        setIsLoaded(true);
      } catch (error) {
        console.log(error);
      }
    };

    fetchData();
  }, []);

  return (
    <div className="container--feed">
      {isLoaded && GenerateFeedItems(data)}
      {!isLoaded && <CircularProgress />}
    </div>
  );
}
