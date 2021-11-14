import React, { useState, useEffect } from "react";
import ReactApexChart from "react-apexcharts";
import TotalDataSummaryStat from "../bar/TotalDataSummaryStat";

export default class TreemapTypeDataStat extends React.Component {
    constructor(props) {
    super(props);

    this.state = {
            data:props.data,
            providerData:props.providerData,
            colorDictionary:props.colorDictionary,
            series:[],
            mode: props.mode,
            options: {
              legend: {
                show: false
              },
              chart: {
                height: 350,
                type: 'treemap',
                toolbar:{
                    show: false
                }
              },
              colors: this.getColors(props),
              plotOptions: {
                treemap: {
                  distributed: true,
                  enableShades: false
                }
              }
            },
          };
        }

   calculateTotalData(state){
        if (state.data === undefined || state.data.length === 0)
            return 20;
        
        let t = state.providerData.filter(x=>state.data[x.name] !== undefined).map(x=>state.data[x.name][0].value);
        if (t.length === 0){
            return 0;
        }
        return t.reduce((a, b) => a + b);
    }

    to2DecimalPlaces(num){
        return Math.round((num + Number.EPSILON) * 100) / 100
     }
        
    createDataPoint(x, state){
        return {
            x: x.type,
            y: this.to2DecimalPlaces(state.data[x.name][0].value)
        }
    }

    createSeries(state){
        if (state.providerData === undefined || state.data === undefined || state.options.colors.length === 0){
            return [{data:[]}];
        }
        let datasets = [];
        for(let p of state.providerData.filter(x=>state.data[x.name] !== undefined)){
            if (datasets.filter(x => x.x === p.type).length == 0){
                datasets.push({
                    x: p.type,
                    y: 0,
                    fillColor:state.colorDictionary[p.type]
                });
            }
            datasets.filter(x => x.x === p.type)[0].y += state.data[p.name][0].value;
        }
        return [
                {
                    data: datasets
                }
            ];
    }

    componentDidUpdate(previousProps, previousState){
        if (previousProps.data !== this.props.data){      
            this.setState({data: this.props.data})
        }
        if (previousProps.colorDictionary !== this.props.colorDictionary){
            this.setState({colorDictionary: this.props.colorDictionary});
            this.setState({
                options:{
                    colors: this.getColors(this.props)
                }
            })
        }
        if (previousProps.providerData !== this.props.providerData){
            this.setState({providerData: this.props.providerData});
        }

    }
    
    getColors(props){
        let colors = props.providerData.filter(x => props.data[x.name] !== undefined).map(x => props.colorDictionary[x.type]);
        return colors;
    }

    render() {
        return <>
        <div id="chart">
            <ReactApexChart options={this.state.options} series={this.createSeries(this.state)} type="treemap" height={350} />
        </div>
        </>
    }
}
