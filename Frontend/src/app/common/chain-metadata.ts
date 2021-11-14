import { Chain, ChainType } from './common-classes';

export const chains: Chain[] = [
    {
        name: 'Arbitrum One',
        show: true,
        lineColor: '#920000',
        type: ChainType.OptimisticRollup,
        generalInfoLink: 'https://l2beat.com/projects/arbitrum/',
        attributionToDataSourceText: `Daily transaction data for Optimism retrieved from https://arbiscan.io`,
        attributionToDataSourceLink: 'https://arbiscan.io/chart/tx',
        logo: `https://arbitrum.io/wp-content/uploads/2021/01/cropped-Arbitrum_Horizontal-Logo-Full-color-White-background-scaled-1-2048x562.jpg`,
        icon: `arbitrum.png`
    },
    {
        name: 'Optimism',
        show: true,
        lineColor: ' #490092',
        type: ChainType.OptimisticRollup,
        generalInfoLink: 'https://l2beat.com/projects/optimism/',
        attributionToDataSourceText: `Daily transaction data for Optimism retrieved from https://arbiscan.io`,
        attributionToDataSourceLink: 'https://optimistic.etherscan.io/chart/tx',
        logo: `https://assets-global.website-files.com/611dbb3c82ba72fbc285d4e2/611fd32ef63b79b5f8568d58_OPTIMISM-logo.svg`,
        icon: `optimism.png`
    },
    {
        name: 'Ethereum',
        show: true,
        lineColor: '#006ddb',
        type: ChainType.Mainnet,
        generalInfoLink: 'https://ethereum.org/',
        attributionToDataSourceText: ``,
        attributionToDataSourceLink: '', 
        logo: `https://ethereum.org/static/a110735dade3f354a46fc2446cd52476/0ee04/eth-home-icon.png`,
        icon: `ethereum.png`
    },
    {
        name: 'Polygon',
        show: true,
        lineColor: '#b66dff',
        type: ChainType.Sidechain,
        generalInfoLink: 'https://polygon.technology/',
        attributionToDataSourceText: ``,
        attributionToDataSourceLink: '',
        logo: `https://polygon.technology/wp-content/uploads/2021/07/polygon-logo.svg`,
        icon: `polygon.png`
    },
    {
        name: 'XDAI',
        show: true,
        lineColor: '#ff6db6',
        type: ChainType.Sidechain,
        generalInfoLink: 'https://www.xdaichain.com/',
        attributionToDataSourceText: ``,
        attributionToDataSourceLink: '',
        logo: `https://gblobscdn.gitbook.com/spaces%2F-Lpi9AHj62wscNlQjI-l%2Favatar.png?alt=media`,
        icon: `xdai.png`
    },
    {
        name: 'ZKSwap',
        show: true,
        lineColor: '#ffdf4d',
        type: ChainType.ZKRollup,
        generalInfoLink: 'https://zkswap.info/',
        attributionToDataSourceText: ``,
        attributionToDataSourceLink: '',
        logo: `https://aws1.discourse-cdn.com/business5/uploads/zks/original/1X/c361d0d6fc319deefe3ec1bfadd6a72878f70cc6.png`,
        icon: `zkswap.png`
    },
    {
        name: 'ZKSync',
        show: true,
        lineColor: '#004949',
        type: ChainType.ZKRollup,
        generalInfoLink: 'https://zksync.io/',
        attributionToDataSourceText: ``,
        attributionToDataSourceLink: '',
        logo: `https://aws1.discourse-cdn.com/business5/uploads/zks/original/1X/c361d0d6fc319deefe3ec1bfadd6a72878f70cc6.png`,
        icon: `zkSync.jpg`
    }
]

