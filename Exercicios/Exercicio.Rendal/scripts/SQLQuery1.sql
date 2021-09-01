SELECT * FROM VEICULO

SELECT A.cod_aluguel,C.nomeCliente,V.placa,M.nomemod,MA.nomeMar,A.dataRetirada,A.dataDev FROM ALUGUEL A 
INNER JOIN VEICULO V ON A.cod_veic = v.cod_veic
INNER JOIN CLIENTE C ON A.cod_cliente = C.cod_cliente
INNER JOIN MODELO M ON V.cod_mod = M.cod_mod
INNER JOIN MARCA MA ON M.cod_mar = MA.cod_mar
WHERE cod_aluguel = @cod_aluguel

INSERT INTO ALUGUEL(cod_cliente,cod_veic,dataRetirada,dataDev) VALUES (@cod_cliente,@cod_veic,@dataRetirada,@dataDev)

UPDATE ALUGUEL SET cod_cliente = 1, cod_veic = 2,dataRetirada = '03-09-2021 00:00:00.000',dataDev = '04-09-2021 00:00:00.000'	WHERE cod_aluguel = 1

UPDATE ALUGUEL SET cod_cliente = 2, cod_veic = 3,dataRetirada = '04-09-2021 ',dataDev = '24-09-2021'	WHERE cod_aluguel = 1