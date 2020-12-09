import { Box } from '@material-ui/core';
import axios from 'axios';
import React, {useState, useEffect} from 'react'
import FriendRequestList from './FriendRequestList';


export default function Requests(props) {
    let [friendRequests, setFriendRequests] = useState([]);
    let [friendRequestsLoaded, setFriendRequestsLoaded] = useState(false);


    useEffect(() => {
        const fetchFriendRequests = async () => {
            try {
              axios("/friend/req/to/"+props.userData.Id, {
                method: "get"
              })
                .then((response) => {
                  console.log("Friendrequest loaded.")
                  setFriendRequests(response.data);
                  setFriendRequestsLoaded(true);
                })
                .catch((error) => console.log(error));
            } catch (error) {
              console.log(error);
            }
          };
          
          console.log("Loading friend requests")
          fetchFriendRequests();
      }, [props]);

    return (
        <div>
        <Box display="flex" justifyContent="flex-start" m={1} p={1}>
          <Box p={1}>
            <h1>Barát jelölések</h1>
          </Box>
        </Box>
        <Box display="flex" justifyContent="center">
          {friendRequestsLoaded && <FriendRequestList userData={props.userData} data={friendRequests}/>}
        </Box>
      </div>
    )
}
