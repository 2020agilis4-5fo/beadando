import React, { useState, useEffect } from "react";
import "./Profile.css";
import "./Feed.css";
import axios from "axios";
import { Box } from "@material-ui/core";
import UserList from "./UserList";

export default function Search(props) {
  let [data, setData] = useState([]);
  let [isLoaded, setIsLoaded] = useState(false);

  useEffect(() => {
    const fetchData = async () => {
      try {
        axios("/account/all", {
          method: "get"
        })
          .then((response) => {
            console.log("Users got.");
            setData(response.data);
            setIsLoaded(true);
          })
          .catch((error) => console.log(error));
      } catch (error) {
        console.log(error);
      }
    };
    console.log("Getting all users..");
    fetchData();
  }, []);

  return (
    <div>
      <Box display="flex" justifyContent="flex-start" m={1} p={1}>
        <Box p={1}>
          <h1>Felhasználó keresés</h1>
        </Box>
      </Box>
      <Box display="flex" justifyContent="center">
        {isLoaded && <UserList userData={props.userData} data={data} />}
      </Box>
    </div>
  );
}
