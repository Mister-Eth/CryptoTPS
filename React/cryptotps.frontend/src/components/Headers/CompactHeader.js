import React from 'react';
import githubIcon from '../../assets/600px-Octicons-mark-github.svg - inv.png';
import twitterIcon from '../../assets/1486053611-twitter_79195.png';
import discordIcon from '../../assets/discord-mascot.png';
import blackDiscordIcon from '../../assets/discord-black-icon-703937.jpg';
import { Link } from "react-router-dom";

export default class CompactHeader extends React.Component{
    constructor(props){
        super(props);
    }

    elementSize = 30;

    render(){
        let imageSize = {width: this.elementSize * 0.9, height: this.elementSize * 0.9};
        return <>
        <Link to="/">
            <br/>
        <div className={"jumpy unselectable"} style={{fontSize: this.elementSize, display:'inline'}}>CRYPTOTPS.info</div>
        </Link>
        <div style={{display:'inline', float: 'right'}}>
            <a href="https://github.com/Mister-Eth/CRYPTOTPS">
                <img style={imageSize} className={"small-img"} src={githubIcon}>
                </img>
                </a>
                <a href="https://twitter.com/cryptotps">
                <img style={imageSize} className={"small-img"} src={twitterIcon}>
                </img>
                </a>
                <a href="https://discord.gg/fg5Qc9DMJK">
                <img style={imageSize} className={"small-img"} src={discordIcon}>
                </img>
            </a>
        </div>
        <hr/>
        </>;
    }
}