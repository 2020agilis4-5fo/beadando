import React, {useState,useEffect} from "react";
import "./Profile.css";
import axios from "axios";
import ImageFeed from "./ImageFeed";


export default function Profile(props) {
  let [isLoaded, setIsLoaded] = useState(false);
  let [data, setData] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
    try {
      axios("/image", {
        method: "post",
        data: { Id: props.userData.Id, Username: props.userData.Username },
        withCredentials: true,
      })
        .then((response) => {
          console.log("Download completed")
          setData(response.data);
          setIsLoaded(true);
        })
        .catch((error) => console.log(error));
    } catch (error) {
      console.log(error);
    }
  };
  console.log("Fetching own photos...")
  fetchData();
  }, [props]);

  return (
    <div>
      <div className="container--profile">
        <h1>{props.userData.Username}</h1>
      </div>
      {isLoaded && <ImageFeed data={data} />}
    </div>
  )
}