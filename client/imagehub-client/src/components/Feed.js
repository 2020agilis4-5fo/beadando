import React, { useState, useEffect } from "react";
import "./Feed.css";
import axios from "axios";
import { CircularProgress } from "@material-ui/core";
import ImageFeed from "./ImageFeed";


export default function Feed(props) {
  let [data, setData] = useState([]);
  let [isLoaded, setIsLoaded] = useState(false);
  useEffect(() => {
    const fetchData = async () => {
      try {
        axios("/image/friends/" + props.userData.Id, {
          method: "get",
          withCredentials: true,
        })
          .then((response) => {
            setData(response.data);
            console.log("Loading completed.");
            setIsLoaded(true);
          })
          .catch((error) => console.log(error));
      } catch (error) {
        console.log(error);
      }
    };
    console.log("Loading friend's images...");
    fetchData();
  }, [props]);

  return (
    <div>
      {isLoaded && <ImageFeed data={data.friendImages} />}
      {!isLoaded && <CircularProgress />}
    </div>
  );
}
