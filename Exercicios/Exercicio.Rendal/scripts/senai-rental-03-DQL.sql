USE T_Rental ;
GO

SELECT * FROM EMPRESA
SELECT * FROM MARCA
SELECT * FROM CLIENTE
SELECT * FROM MODELO
SELECT * FROM VEICULO
SELECT * FROM ALUGUEL


--listar todos os alugueis mostrando as datas de início e fim, 
--o nome do cliente que alugou e nome do modelo do carro

SELECT  cod_aluguel,dataRetirada,dataDev,nomeCliente,nomemod FROM ALUGUEL
INNER JOIN CLIENTE
ON CLIENTE.cod_cliente = ALUGUEL.cod_cliente
INNER JOIN MODELO
ON MODELO.cod_mod = ALUGUEL.cod_veic;

-- listar os alugueis de um determinado cliente mostrando seu nome, 
-- as datas de início e fim e o nome do modelo do carro

SELECT  cod_aluguel,nomeCliente,dataRetirada,dataDev,nomemod FROM ALUGUEL
INNER JOIN CLIENTE
ON CLIENTE.cod_cliente = ALUGUEL.cod_cliente
INNER JOIN MODELO
ON MODELO.cod_mod = ALUGUEL.cod_veic
WHERE nomeCliente= 'João';