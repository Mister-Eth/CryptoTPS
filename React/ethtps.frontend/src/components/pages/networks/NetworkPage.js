import PageWithQueryString from '../../pages/PageWithQueryString';
import HistoricalLineChart from '../../charts/HistoricalLineChart';
import './NetworkPage.css';
import '../../../App.css';
import React, {setState} from 'react';
import EthereumDetails from './details/EthereumDetails';
import ArbitrumDetails from './details/ArbitrumDetails';
import AVAXCChainDetails from './details/AVAXCChainDetails';
import BobaNetworkDetails from './details/BobaNetworkDetails';
import LoopringDetails from './details/LoopringDetails';
import OptimismDetails from './details/OptimismDetails';
import PolygonDetails from './details/PolygonDetails';
import XDAIDetails from './details/XDAIDetails';
import ZKSwapDetails from './details/ZKSwapDetails';
import ZKSyncDetails from './details/ZKSyncDetails';
import ImmutableXDetails from './details/ImmutableXDetails';
import AztecDetails from './details/AztecDetails';
import HistoricalCandleChart from '../../charts/HistoricalCandleChart';
import { globalGeneralApi, globalOCLHApi, globalInstantDataService, to2DecimalPlaces } from '../../../services/common';
import * as qs from 'query-string';

export default class NetworkPage extends PageWithQueryString {
    constructor(props){
        super(props);

        let state = this.state;
        state.instantTPS = 0;
        state.interval = '1d';
        state.mode = 'tps';
        let q = qs.parse(window.location.search);
        if (q.interval !== undefined){
            state.interval = q.interval; 
        }
        if (q.mode !== undefined){
            state.mode = q.mode;

        }
        this.state = state;
    }

    components = {
        'Ethereum': <EthereumDetails name={this.state.name}/>,
        'Arbitrum One': <ArbitrumDetails name={this.state.name}/>,
        'AVAX C-chain': <AVAXCChainDetails name={this.state.name}/>,
        'Boba Network': <BobaNetworkDetails name={this.state.name}/>,
        'Loopring': <LoopringDetails name={this.state.name}/>,
        'Optimism': <OptimismDetails name={this.state.name}/>,
        'Polygon': <PolygonDetails name={this.state.name}/>,
        'XDAI': <XDAIDetails name={this.state.name}/>,
        'ZKSwap': <ZKSwapDetails name={this.state.name}/>,
        'ZKSync': <ZKSyncDetails name={this.state.name}/>,
        'Immutable X': <ImmutableXDetails name={this.state.name}/>,
        'Aztec': <AztecDetails name={this.state.name}/>,
    }

    updateInstantTPS(data){
        this.setState({instantTPS: data['tps'][this.state.name][0].value});
    }

    componentDidMount(){
        globalGeneralApi.aPIV2ColorDictionaryGet((err,data,res) => {
            this.setState({colorDictionary:data});
        });
        globalInstantDataService.periodicallyGetInstantDataForPage(this.state.name, this.updateInstantTPS.bind(this));
        globalInstantDataService.getAndCallbackInstantData();
    }
    
    render(){
        let candleChart = 
        <HistoricalCandleChart 
            height={150}
            provider={this.state.name} 
            colorDictionary={this.state.colorDictionary}
            interval={this.state.interval} 
            mode={this.state.mode} 
            scale={'lin'} 
            network={'Mainnet'}/>;
        if (this.state !== null && this.state.colorDictionary !== undefined)
        return <>
        <a href={`https://github.com/WhoEvenAmI/ETHTPS/edit/dev/React/ethtps.frontend/src/components/pages/networks/details/${this.state.name}Details.js`} style={{float:'right', display:'inline'}}>
            [Edit]
        </a>
            <div>
                <h1  style={{display: 'inline'}} className={'box'}>
                    <img className={'large'} src={`/provider-icons/${this.state.name}.png`} />
                    {this.state.name}
                </h1>
            </div>
                <h4 style={{display: 'inline', color: "darkgray", verticalAlign:"middle", top: '-100%'}}>
                    {this.state.instantTPS !== undefined? `${to2DecimalPlaces(this.state.instantTPS)} TPS`:<></>} 
                </h4>
            <HistoricalLineChart 
                height={150}
                provider={this.state.name} 
                colorDictionary={this.state.colorDictionary}
                interval={this.state.interval} 
                mode={this.state.mode} 
                scale={'lin'} 
                network={'Mainnet'}/>
            <hr/>
            {this.components[this.state.name]}
        </>
        else return <></>
    }
}