--INSERTs generated by GenerateInsert (Build 6)
--Project page: http://github.com/drumsta/sql-generate-insert
SET NOCOUNT ON
INSERT INTO dbo.ProviderTypes
([Name])
VALUES
 (N'Mainnet')
,(N'Optimistic rollup')
,(N'ZK rollup')
,(N'Application-specific rollup')
,(N'Sidechain')

--INSERTs generated by GenerateInsert (Build 6)
--Project page: http://github.com/drumsta/sql-generate-insert
SET NOCOUNT ON
INSERT INTO dbo.Providers
([Name],[Type])
VALUES
 (N'Ethereum',1)
,(N'Arbitrum One',2)
,(N'Optimism',2)
,(N'Polygon',5)
,(N'XDAI',5)
,(N'ZKSwap',3)
,(N'ZKSync',3)
,(N'AVAX C-chain',5)
,(N'Boba Network',2)
,(N'Loopring',3)

--INSERTs generated by GenerateInsert (Build 6)
--Project page: http://github.com/drumsta/sql-generate-insert
SET NOCOUNT ON
INSERT INTO dbo.ProviderProperties
([Provider],[Name],[Value])
VALUES
 (1,N'Color',N'#490092')
,(2,N'Color',N'#920000')
,(3,N'Color',N'#006ddb')
,(4,N'Color',N'#004949')
,(5,N'Color',N'#ff6db6')
,(6,N'Color',N'#c29a2d')
,(7,N'Color',N'#db6d00')
,(8,N'Color',N'#22cf22')
,(10,N'Color',N'#171723')
,(11,N'Color',N'#4a1173')

--INSERTs generated by GenerateInsert (Build 6)
--Project page: http://github.com/drumsta/sql-generate-insert
SET NOCOUNT ON
INSERT INTO dbo.Networks
([Name])
VALUES
 (N'Mainnet')
,(N'Ropsten')
,(N'Kovan')
,(N'Rinkeby')
,(N'Goerli')
