import React from 'react';
import githubIcon from '../../assets/600px-Octicons-mark-github.svg - inv.png';
import twitterIcon from '../../assets/1486053611-twitter_79195.png';
import discordIcon from '../../assets/discord-mascot.png';
import blackDiscordIcon from '../../assets/discord-black-icon-703937.jpg';
import { Link } from "react-router-dom";

export default class LargeHeader extends React.Component{
    constructor(props){
        super(props);
    }

    render(){
        return <>
        <center>
        <br></br>

        <center>
            <div  style={{backgroundColor: '#7289da', borderRadius:3, marginBottom: '0px'}}>
            <img className={"small-img"} src={blackDiscordIcon}></img>
            <a style={{color:'white', fontWeight: 'bold', fontSize: 15}} href={'https://discord.gg/fg5Qc9DMJK'}>
            Click here to join our Discord channel
            </a>
            <img className={"small-img"} src={blackDiscordIcon}></img>
            </div>
        </center>


        <Link to="/">
        <div className={"jumpy unselectable"}>CRYPTOTPS.info</div>
        </Link>
        <br></br>
        <br></br>
        <a href="https://github.com/Mister-Eth/CryptoTPS">
            <img className={"small-img"} src={githubIcon}>
            </img>
            </a>
            <a href="https://twitter.com/cryptotps">
            <img className={"small-img"} src={twitterIcon}>
            </img>
            </a>
            <a href="https://discord.gg/fg5Qc9DMJK">
            <img className={"small-img"} src={discordIcon}>
            </img>
            </a>
        </center>
    <hr/>
        </>;
    }
}