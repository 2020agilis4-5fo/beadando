import { createMuiTheme } from "@material-ui/core";
import { red } from "@material-ui/core/colors";
import React, { useState } from "react";
import "./App.css";
import Login from "./components/Login";
import MainContent from "./components/MainContent";
import { ThemeProvider } from "@material-ui/core/styles";

function App() {
  let  [isLoggedIn, setIsLoggedIn] = useState(false)
  let  [userData, setUserData] = useState("")

  const theme = createMuiTheme({
    palette: {
      primary: red,
    },
  });

  return (
    <div className="App">
      <ThemeProvider theme={theme}>
        {!isLoggedIn && <Login setIsLoggedIn={setIsLoggedIn} setUserData={setUserData} />}
        {isLoggedIn && <MainContent userData={userData} />}
      </ThemeProvider>
    </div>
  );
}

export default App;
