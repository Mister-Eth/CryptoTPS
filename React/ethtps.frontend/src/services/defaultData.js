export let allInstantData = JSON.parse('{"tps":{"Ethereum":[{"date":"0001-01-01T00:00:00","value":9.489051094890511}],"Arbitrum One":[{"date":"0001-01-01T00:00:00","value":0.24285714285714285}],"Optimism":[{"date":"0001-01-01T00:00:00","value":0.2}],"Polygon":[{"date":"0001-01-01T00:00:00","value":47.272727272727266}],"XDAI":[{"date":"0001-01-01T00:00:00","value":0.3846153846153846}],"ZKSwap":[{"date":"0001-01-01T00:00:00","value":0.012121212121212121}],"ZKSync":[{"date":"0001-01-01T00:00:00","value":0.09380019274012207}],"AVAX C-chain":[{"date":"0001-01-01T00:00:00","value":5.0}],"Boba Network":[{"date":"0001-01-01T00:00:00","value":0.018867924528301886}],"Loopring":[{"date":"0001-01-01T00:00:00","value":0.06366575478736633}],"Aztec":[{"date":"0001-01-01T00:00:00","value":0.003032530784782209}],"Immutable X":[{"date":"0001-01-01T00:00:00","value":0.9}],"Metis":[{"date":"0001-01-01T00:00:00","value":0.8260869565217391}],"Ronin":[{"date":"0001-01-01T00:00:00","value":0.6666666666666666}],"Starknet":[{"date":"0001-01-01T00:00:00","value":0.003707627118644068}],"Nahmii 2.0":[{"date":"0001-01-01T00:00:00","value":0.00011169440411035407}],"OMG Network":[{"date":"0001-01-01T00:00:00","value":1.1545464306619823E-06}],"zkTube":[{"date":"0001-01-01T00:00:00","value":0.0005291046099248142}],"Fantom":[{"date":"0001-01-01T00:00:00","value":2.0}],"ZKSpace":[{"date":"0001-01-01T00:00:00","value":0.017241379310344827}]},"gps":{"Ethereum":[{"date":"0001-01-01T00:00:00","value":1002325.2554744526}],"Arbitrum One":[{"date":"0001-01-01T00:00:00","value":37806.07142857143}],"Optimism":[{"date":"0001-01-01T00:00:00","value":0.0}],"Polygon":[{"date":"0001-01-01T00:00:00","value":9026186.818181818}],"XDAI":[{"date":"0001-01-01T00:00:00","value":60470.0}],"ZKSwap":[{"date":"0001-01-01T00:00:00","value":0.0}],"ZKSync":[{"date":"0001-01-01T00:00:00","value":0.0}],"AVAX C-chain":[{"date":"0001-01-01T00:00:00","value":582998.0}],"Boba Network":[{"date":"0001-01-01T00:00:00","value":3301.0377358490564}],"Loopring":[{"date":"0001-01-01T00:00:00","value":1592.8873414573488}],"Aztec":[{"date":"0001-01-01T00:00:00","value":0.0}],"Immutable X":[{"date":"0001-01-01T00:00:00","value":31900.0}],"Metis":[{"date":"0001-01-01T00:00:00","value":855095.4782608695}],"Ronin":[{"date":"0001-01-01T00:00:00","value":0.0}],"Starknet":[{"date":"0001-01-01T00:00:00","value":0.0}],"Nahmii 2.0":[{"date":"0001-01-01T00:00:00","value":0.0}],"OMG Network":[{"date":"0001-01-01T00:00:00","value":0.0}],"zkTube":[{"date":"0001-01-01T00:00:00","value":0.0}],"Fantom":[{"date":"0001-01-01T00:00:00","value":285662.0}],"ZKSpace":[{"date":"0001-01-01T00:00:00","value":0.0}]},"gasAdjustedTPS":{"Ethereum":[{"date":"0001-01-01T00:00:00","value":47.72977407021203}],"Arbitrum One":[{"date":"0001-01-01T00:00:00","value":1.8002891156462584}],"Optimism":[{"date":"0001-01-01T00:00:00","value":0.0}],"Polygon":[{"date":"0001-01-01T00:00:00","value":429.8184199134199}],"XDAI":[{"date":"0001-01-01T00:00:00","value":2.8795238095238096}],"ZKSwap":[{"date":"0001-01-01T00:00:00","value":0.0}],"ZKSync":[{"date":"0001-01-01T00:00:00","value":0.0}],"AVAX C-chain":[{"date":"0001-01-01T00:00:00","value":27.761809523809525}],"Boba Network":[{"date":"0001-01-01T00:00:00","value":0.15719227313566936}],"Loopring":[{"date":"0001-01-01T00:00:00","value":0.07585177816463566}],"Aztec":[{"date":"0001-01-01T00:00:00","value":0.0}],"Immutable X":[{"date":"0001-01-01T00:00:00","value":1.519047619047619}],"Metis":[{"date":"0001-01-01T00:00:00","value":40.71883229813665}],"Ronin":[{"date":"0001-01-01T00:00:00","value":0.0}],"Starknet":[{"date":"0001-01-01T00:00:00","value":0.0}],"Nahmii 2.0":[{"date":"0001-01-01T00:00:00","value":0.0}],"OMG Network":[{"date":"0001-01-01T00:00:00","value":0.0}],"zkTube":[{"date":"0001-01-01T00:00:00","value":0.0}],"Fantom":[{"date":"0001-01-01T00:00:00","value":13.602952380952381}],"ZKSpace":[{"date":"0001-01-01T00:00:00","value":0.0}]}}');
//Only use the implemented providers, otherwise Apexcharts goes crazy
export let colorDictionary = JSON.parse('{"zkTube": "#a75ccc","OMG Network": "#4d2000","Ethereum":"#490092","Arbitrum One":"#920000","Optimism":"#006ddb","Polygon":"#004949","XDAI":"#ff6db6","ZKSwap":"#c29a2d","ZKSync":"#db6d00","AVAX C-chain":"#22cf22","Boba Network":"#171723","Loopring":"#4a1173","Aztec":"#5c65cc","Immutable X":"#1c1e33","Metis":"#992699","Ronin":"#5c65cc","Starknet":"#8ae5d6","Nahmii 2.0":"#46004d","Binance Smart Chain": "#cca166","Fantom": "#731911","ZKSpace":"#cc5c9d"}');
export let providerTypeColorDictionary = JSON.parse('{"Mainnet":"#4a1173","Optimistic rollup":" #3a7311","ZK rollup":"#116b73","Application-specific rollup":"#8ae5d6","Sidechain":"#002d4d","Validium":"#8ab0e5","State pools":"#cc5f10"}');
export let maxData = JSON.parse('{"tps":{"Ethereum":{"date":"2021-11-04T10:34:56","value":102.62773722627738},"Arbitrum One":{"date":"2021-11-06T05:18:56","value":48.0},"Optimism":{"date":"2021-11-06T08:38:01.66","value":4.4},"Polygon":{"date":"2021-11-06T05:13:17","value":424.99999999999994},"XDAI":{"date":"2021-11-05T10:38:45","value":193.26923076923077},"ZKSwap":{"date":"2021-11-05T08:24:27","value":5.578947368421052},"ZKSync":{"date":"2021-11-05T08:06:23","value":110.0},"AVAX C-chain":{"date":"2021-11-14T14:50:07","value":192.0},"Boba Network":{"date":"2021-11-05T09:54:11","value":43.0},"Loopring":{"date":"2021-11-05T07:43:34","value":576.0},"Aztec":{"date":"2021-11-14T08:05:37","value":0.10926829268292683},"Immutable X":{"date":"2021-11-14T15:48:00","value":31.683333333333334},"Metis":{"date":"2021-11-26T04:47:18","value":8.6},"Ronin":{"date":"2021-11-30T09:34:13.433","value":187.0},"Starknet":{"date":"2021-12-02T04:24:17","value":0.07272727272727272},"Nahmii 2.0":{"date":"2021-12-03T00:00:00","value":0.07692307692307693},"Binance Smart Chain":{"date":"2021-12-04T09:17:34","value":563.3333333333334},"OMG Network":{"date":"2021-12-06T08:27:00","value":1.5093405540185437E-06},"Gluon":{"date":"0001-01-01T00:00:00","value":0.0},"Habitat":{"date":"0001-01-01T00:00:00","value":0.0},"Fuel":{"date":"0001-01-01T00:00:00","value":0.0},"Layer2.Finance":{"date":"0001-01-01T00:00:00","value":0.0},"dYdX":{"date":"0001-01-01T00:00:00","value":0.0},"Sorare":{"date":"0001-01-01T00:00:00","value":0.0},"DiversiFi":{"date":"0001-01-01T00:00:00","value":0.0},"Gazelle":{"date":"0001-01-01T00:00:00","value":0.0},"LeapDAO":{"date":"0001-01-01T00:00:00","value":0.0},"zkTube":{"date":"2021-12-06T01:10:42.48","value":0.05555483254821887},"Cartesi":{"date":"0001-01-01T00:00:00","value":0.0},"Kchannels":{"date":"0001-01-01T00:00:00","value":0.0},"Perun":{"date":"0001-01-01T00:00:00","value":0.0},"Raiden Network":{"date":"0001-01-01T00:00:00","value":0.0},"Fantom":{"date":"2021-12-27T18:48:25","value":105.0},"ZKSpace":{"date":"2022-01-18T06:35:07","value":0.0182370820668693}},"gps":{"Ethereum":{"date":"2021-11-04T10:34:56","value":30012410.0},"Arbitrum One":{"date":"2021-11-06T05:18:56","value":19200410.0},"Optimism":{"date":"2021-11-06T08:38:01.66","value":0.0},"Polygon":{"date":"2021-11-06T05:13:17","value":16412447.272727272},"XDAI":{"date":"2021-11-05T10:38:45","value":5768554.615384615},"ZKSwap":{"date":"2021-11-05T08:24:27","value":0.0},"ZKSync":{"date":"2021-11-05T08:06:23","value":0.0},"AVAX C-chain":{"date":"2021-11-14T14:50:07","value":15974802.0},"Boba Network":{"date":"2021-11-05T09:54:11","value":12852793.0},"Loopring":{"date":"2021-11-05T07:43:34","value":10000000.0},"Aztec":{"date":"2021-11-14T08:05:37","value":0.0},"Immutable X":{"date":"2021-11-14T15:48:00","value":4746250.0},"Metis":{"date":"2021-11-26T04:47:18","value":10931841.4},"Ronin":{"date":"2021-11-30T09:34:13.433","value":0.0},"Starknet":{"date":"2021-12-02T04:24:17","value":0.0},"Nahmii 2.0":{"date":"2021-12-03T00:00:00","value":146676.84615384616},"Binance Smart Chain":{"date":"2021-12-04T09:17:34","value":33175721.333333332},"OMG Network":{"date":"2021-12-06T08:27:00","value":0.0},"Gluon":{"date":"0001-01-01T00:00:00","value":0.0},"Habitat":{"date":"0001-01-01T00:00:00","value":0.0},"Fuel":{"date":"0001-01-01T00:00:00","value":0.0},"Layer2.Finance":{"date":"0001-01-01T00:00:00","value":0.0},"dYdX":{"date":"0001-01-01T00:00:00","value":0.0},"Sorare":{"date":"0001-01-01T00:00:00","value":0.0},"DiversiFi":{"date":"0001-01-01T00:00:00","value":0.0},"Gazelle":{"date":"0001-01-01T00:00:00","value":0.0},"LeapDAO":{"date":"0001-01-01T00:00:00","value":0.0},"zkTube":{"date":"2021-12-06T01:10:42.48","value":0.0},"Cartesi":{"date":"0001-01-01T00:00:00","value":0.0},"Kchannels":{"date":"0001-01-01T00:00:00","value":0.0},"Perun":{"date":"0001-01-01T00:00:00","value":0.0},"Raiden Network":{"date":"0001-01-01T00:00:00","value":0.0},"Fantom":{"date":"2021-12-27T18:48:25","value":19882498.0},"ZKSpace":{"date":"2022-01-18T06:35:07","value":0.0}},"gasAdjustedTPS":{"Ethereum":{"date":"2021-11-04T10:34:56","value":1429.162380952381},"Arbitrum One":{"date":"2021-11-06T05:18:56","value":914.3052380952381},"Optimism":{"date":"2021-11-06T08:38:01.66","value":0.0},"Polygon":{"date":"2021-11-06T05:13:17","value":781.5451082251082},"XDAI":{"date":"2021-11-05T10:38:45","value":274.6930769230769},"ZKSwap":{"date":"2021-11-05T08:24:27","value":0.0},"ZKSync":{"date":"2021-11-05T08:06:23","value":0.0},"AVAX C-chain":{"date":"2021-11-14T14:50:07","value":760.7048571428571},"Boba Network":{"date":"2021-11-05T09:54:11","value":612.0377619047619},"Loopring":{"date":"2021-11-05T07:43:34","value":476.1904761904762},"Aztec":{"date":"2021-11-14T08:05:37","value":0.0},"Immutable X":{"date":"2021-11-14T15:48:00","value":226.01190476190476},"Metis":{"date":"2021-11-26T04:47:18","value":520.5638761904762},"Ronin":{"date":"2021-11-30T09:34:13.433","value":0.0},"Starknet":{"date":"2021-12-02T04:24:17","value":0.0},"Nahmii 2.0":{"date":"2021-12-03T00:00:00","value":6.984611721611722},"Binance Smart Chain":{"date":"2021-12-04T09:17:34","value":1579.796253968254},"OMG Network":{"date":"2021-12-06T08:27:00","value":0.0},"Gluon":{"date":"0001-01-01T00:00:00","value":0.0},"Habitat":{"date":"0001-01-01T00:00:00","value":0.0},"Fuel":{"date":"0001-01-01T00:00:00","value":0.0},"Layer2.Finance":{"date":"0001-01-01T00:00:00","value":0.0},"dYdX":{"date":"0001-01-01T00:00:00","value":0.0},"Sorare":{"date":"0001-01-01T00:00:00","value":0.0},"DiversiFi":{"date":"0001-01-01T00:00:00","value":0.0},"Gazelle":{"date":"0001-01-01T00:00:00","value":0.0},"LeapDAO":{"date":"0001-01-01T00:00:00","value":0.0},"zkTube":{"date":"2021-12-06T01:10:42.48","value":0.0},"Cartesi":{"date":"0001-01-01T00:00:00","value":0.0},"Kchannels":{"date":"0001-01-01T00:00:00","value":0.0},"Perun":{"date":"0001-01-01T00:00:00","value":0.0},"Raiden Network":{"date":"0001-01-01T00:00:00","value":0.0},"Fantom":{"date":"2021-12-27T18:48:25","value":946.7856190476191},"ZKSpace":{"date":"2022-01-18T06:35:07","value":0.0}}}');
export let providerData = JSON.parse('[{"name":"Ethereum","color":"#490092","theoreticalMaxTPS":1428,"type":"Mainnet","isGeneralPurpose":true},{"name":"Arbitrum One","color":"#920000","theoreticalMaxTPS":40000,"type":"Optimistic rollup","isGeneralPurpose":true},{"name":"Optimism","color":"#006ddb","theoreticalMaxTPS":20000,"type":"Optimistic rollup","isGeneralPurpose":true},{"name":"Polygon","color":"#004949","theoreticalMaxTPS":7200,"type":"Sidechain","isGeneralPurpose":true},{"name":"XDAI","color":"#ff6db6","theoreticalMaxTPS":7000,"type":"Sidechain","isGeneralPurpose":true},{"name":"ZKSwap","color":"#c29a2d","theoreticalMaxTPS":10000,"type":"ZK rollup","isGeneralPurpose":true},{"name":"ZKSync","color":"#db6d00","theoreticalMaxTPS":20000,"type":"ZK rollup","isGeneralPurpose":true},{"name":"AVAX C-chain","color":"#22cf22","theoreticalMaxTPS":380,"type":"Sidechain","isGeneralPurpose":true},{"name":"Boba Network","color":"#171723","theoreticalMaxTPS":20000,"type":"Optimistic rollup","isGeneralPurpose":true},{"name":"Loopring","color":"#4a1173","theoreticalMaxTPS":2050,"type":"ZK rollup","isGeneralPurpose":false},{"name":"Aztec","color":"#c6e58","theoreticalMaxTPS":300,"type":"ZK rollup","isGeneralPurpose":true},{"name":"Immutable X","color":"#1c1e33","theoreticalMaxTPS":9000,"type":"Validium","isGeneralPurpose":false},{"name":"Metis","color":"#992699","theoreticalMaxTPS":20000,"type":"Optimistic rollup","isGeneralPurpose":true},{"name":"Ronin","color":"#5c65cc","theoreticalMaxTPS":220,"type":"Sidechain","isGeneralPurpose":false},{"name":"Starknet","color":"#8ae5d6","theoreticalMaxTPS":0,"type":"ZK rollup","isGeneralPurpose":true},{"name":"Nahmii 2.0","color":"#46004d","theoreticalMaxTPS":0,"type":"State pools","isGeneralPurpose":true},{"name":"OMG Network","color":"#4d2000","theoreticalMaxTPS":0,"type":"Plasma","isGeneralPurpose":false},{"name":"Gluon","color":"#731152","theoreticalMaxTPS":0,"type":"Plasma","isGeneralPurpose":false},{"name":"Habitat","color":"#404d00","theoreticalMaxTPS":0,"type":"Optimistic rollup","isGeneralPurpose":false},{"name":"Fuel","color":"#9f252f","theoreticalMaxTPS":2,"type":"Optimistic rollup","isGeneralPurpose":false},{"name":"Layer2.Finance","color":"#cf4444","theoreticalMaxTPS":0,"type":"Optimistic rollup","isGeneralPurpose":false},{"name":"dYdX","color":"#8c2358","theoreticalMaxTPS":0,"type":"Plasma","isGeneralPurpose":false},{"name":"Sorare","color":"#265f99","theoreticalMaxTPS":0,"type":"ZK rollup","isGeneralPurpose":false},{"name":"DiversiFi","color":"#735445","theoreticalMaxTPS":0,"type":"ZK rollup","isGeneralPurpose":false},{"name":"Gazelle","color":"#8ab0e5","theoreticalMaxTPS":0,"type":"Plasma","isGeneralPurpose":false},{"name":"zkTube","color":"#a75ccc","theoreticalMaxTPS":0,"type":"ZK rollup","isGeneralPurpose":false},{"name":"Cartesi","color":"#ffe561","theoreticalMaxTPS":0,"type":"Optimistic rollup","isGeneralPurpose":true},{"name":"Kchannels","color":"#5ccc8b","theoreticalMaxTPS":0,"type":"State channels","isGeneralPurpose":false},{"name":"Perun","color":"#455473","theoreticalMaxTPS":0,"type":"State channels","isGeneralPurpose":false},{"name":"Raiden Network","color":"#7a8c99","theoreticalMaxTPS":0,"type":"State channels","isGeneralPurpose":false},{"name":"Fantom","color":"#731911","theoreticalMaxTPS":0,"type":"Sidechain","isGeneralPurpose":true},{"name":"ZKSpace","color":"#cc5c9d","theoreticalMaxTPS":0,"type":"ZK rollup","isGeneralPurpose":true}]');

