import '../../..//App.css';
import { globalGeneralApi, formatModeName, globalInstantDataService } from '../../../services/common';
import { allInstantData, colorDictionary, providerTypeColorDictionary, maxData, providerData } from '../../../services/defaultData';
import React, { ReactDOM, useState, useEffect } from "react";
import Timeline from '../../Timeline';
import HorizontalBarChart from '../../HorizontalBarChart';
import ProviderTable from './components/ProviderTable';
import DataStatByType from './components/instant-stats/DataStatByType';
import ModeSelector from './ModeSelector';
import * as qs from 'query-string';
import HistoricalChart from '../../charts/HistoricalChart';
import { Helmet } from 'react-helmet';

class MainPage extends React.Component {

  constructor(props){
    super(props);

    let queryStringMode =  qs.parse(window.location.search).mode;
    let mode = 'tps';
    if (queryStringMode !== undefined){
      if (queryStringMode === "gps" || queryStringMode === "tps" || queryStringMode === "gasAdjustedTPS"){
        mode = queryStringMode;
      }
    }
    let allinstantData = allInstantData;
    this.state = {
      homePageModel: {
        selectedInstantData: allinstantData[mode],
        allInstantData: allinstantData,
        colorDictionary: colorDictionary,
        providerTypeColorDictionary: providerTypeColorDictionary,
        maxData: maxData,
        providerData: providerData
      },
      network: "Mainnet",
      excludeSidechains: false,
      modifiedInstantTPS: {},
      mode: mode,
      offline: false
    }
  }

  intervalRef = -1;
  componentDidMount(){

    try{
      /*
      globalGeneralApi.aPIV2ProvidersGet((err, data, res) => {
        if (data !== null){
          let homePageModel = this.state.homePageModel;
          homePageModel.providerData = data;
          this.setState({homePageModel: homePageModel});
        }
      });
  
      globalGeneralApi.aPIV2ColorDictionaryGet((err, data, res) => {
        if (data !== null){
          let homePageModel = this.state.homePageModel;
          homePageModel.colorDictionary = data;
          this.setState({homePageModel: homePageModel});
        }
      });
  
      globalGeneralApi.aPIV2ProviderTypesColorDictionaryGet((err, data, res) => {
        if (data !== null){
          let homePageModel = this.state.homePageModel;
          homePageModel.providerTypeColorDictionary = data;
          this.setState({homePageModel: homePageModel});
        }
      });
  */
      globalGeneralApi.aPIV2MaxGet({provider: 'All', network: this.state.network}, (err, data, res) => {
        if (data !== null){
          let homePageModel = this.state.homePageModel;
          homePageModel.maxData = data;
          this.setState({homePageModel: homePageModel});
        }
      });
    }
    catch{
      window.location.reload();
    }

    globalInstantDataService.periodicallyGetInstantDataForPage('MainPage', this.updateInstantTPS.bind(this));
  }
  
  handleInputChange(event){
    const target = event.target;
    const value = target.type === 'checkbox' ? target.checked : target.value;
    this.setState({excludeSidechains : value});
  }

  getFilteredInstantData(state){
    if (state.excludeSidechains){
      let filteredInstantTPSData = {};
      for(let p of state.homePageModel.providerData){
        if (state.homePageModel.providerData.filter(x => x.name == p.name && x.type !== 'Sidechain')){
          filteredInstantTPSData[p.name] = state.homePageModel.selectedInstantData[p.name];
        }
      }
      return filteredInstantTPSData;
    }
    else {
      return state.homePageModel.selectedInstantData;
    }
  }

  updateInstantTPS(data){
    try{
      let homePageModel = this.state.homePageModel;
      homePageModel.selectedInstantData = data[this.state.mode];
      homePageModel.allInstantData = data;
      this.setState({homePageModel: homePageModel});
      if (this.state.offline){
        this.setState({offline: false});
      }
    }
    catch{
      if (!this.state.offline){
        this.setState({offline: true});
      }
    }
  }

  getProviderData(state){
    return (state.excludeSidechains)?state.homePageModel.providerData.filter(x=>x.type !== "Sidechain"):state.homePageModel.providerData
  }

  modeChanged(mode){
    this.setState({mode: mode});
    globalInstantDataService.getAndCallbackInstantData();
  }
 render(){
  let optionalGasAdjustedText = "";
  if (this.state.mode === "gasAdjustedTPS"){
    optionalGasAdjustedText = "The gas-adjusted TPS value of a network is calculated by dividing the total gas used by the network at any time by 21,000 gas (the gas cost of a simple ETH transfer). In other words, this value represents the theoretical number of transactions per second a network were to do if all transactions were simple ETH transfers.";
  }
  let offlineCircle =   <div style={{marginLeft: '10px'}} className={'dot tooltip'}>
  <span className={'tooltiptext'}>
    Live updates are currently unavailable
  </span>
  </div>;
  return (
    <>
       <Helmet>
          <title>
            Live Ethereum TPS data
        </title>
      </Helmet>
      <ModeSelector defaultMode={this.state.mode} onChange={this.modeChanged.bind(this)}/>
      <div style={{display:'inline-block'}}>
        <h3 style={{display:'inline'}}>
          Current {formatModeName(this.state.mode)} overview
        </h3>
        {(this.state.offline?offlineCircle:<></>)}
      </div>
      <p>
      {optionalGasAdjustedText}
      </p>
        <DataStatByType 
            excludeSidechains={this.state.excludeSidechains}
            colorDictionary={this.state.homePageModel.colorDictionary}
            data={this.state.homePageModel.selectedInstantData}
            allData={this.state.homePageModel.allInstantData}
            providerData={this.getProviderData(this.state)}
            providerTypeColorDictionary={this.state.homePageModel.providerTypeColorDictionary}
            mode={this.state.mode}
            split="network"/>
      <label className={"small"}>
      <input
            ref={ref=>this.excludeSidechainsCheckBox = ref}
            name="excludeSidechains" type="checkbox"
            checked={this.state.excludeSidechains}
            onChange={this.handleInputChange.bind(this)}/>
            Exclude sidechains?
      </label>
      <p>
        Should sidechains be excluded by default? <a style={{textDecoration: 'underline'}} href="https://twitter.com/ethtps/status/1465211997809745927?s=20">Answer the poll here</a>
      </p>
      <hr/>

    <h3>
      Networks
    </h3>
    <ProviderTable
      data={this.state.homePageModel.selectedInstantData} 
      allData={this.state.homePageModel.allInstantData}
      colorDictionary={this.state.homePageModel.colorDictionary} 
      allMaxData={this.state.homePageModel.maxData}
      mode={this.state.mode}
      providerData={this.getProviderData(this.state)}/>
      <hr/>
      <h3>
        Historical {formatModeName(this.state.mode)} distribution
      </h3>
      <p>
        This is a stacked line chart of all networks' historical throughput.
      </p>
      <Timeline/>
      <HistoricalChart 
        height={200}
        interval="1m"
        mode={this.state.mode}
        colorDictionary={this.state.homePageModel.colorDictionary} 
        provider="All"
        scale="lin"
        network={this.state.network} />
      {/*
      <HorizontalBarChart 
        data={this.state.homePageModel.selectedInstantData} 
        colorDictionary={this.state.homePageModel.colorDictionary} 
        mode={this.state.mode}
        providerData={this.getProviderData(this.state)}/>
      */}
    </>
  );
}
}
export default MainPage;
