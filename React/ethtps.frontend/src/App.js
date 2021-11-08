import './App.css';
import githubIcon from './assets/600px-Octicons-mark-github.svg - inv.png';
import twitterIcon from './assets/1486053611-twitter_79195.png';
import discordIcon from './assets/discord-mascot.png';
import React, { ReactDOM, useState, useEffect } from "react";
import MainPage from './components/pages/MainPage';
import { Link } from "react-router-dom";
import Main from './Main';

class App extends React.Component {

  constructor(props){
    super(props);
  }

 render(){
  return (
    <>
    <center>
    <br></br>
    <Link to="/">
      <div className={"jumpy unselectable"}>ETHTPS.info</div>
    </Link>
    <br></br>
    <br></br>
      <a href="https://github.com/WhoEvenAmI/ETHTPS">
          <img className={"small-img"} src={githubIcon}>
          </img>
        </a>
        <a href="https://twitter.com/ethtps">
          <img className={"small-img"} src={twitterIcon}>
          </img>
        </a>
        <a href="https://discord.gg/jWPcsTzpCT">
          <img className={"small-img"} src={discordIcon}>
          </img>
        </a>
    </center>
    <hr/>
    <div className={"container"}>
      <Main/>
    </div>
    </>
  );
}
}
export default App;
