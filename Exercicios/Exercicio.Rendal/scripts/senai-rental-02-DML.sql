USE T_Rental ;
GO

INSERT INTO EMPRESA(nomeEmpresa)
VALUES ('FOITARDE'), ('FOICEDO');
GO

INSERT INTO EMPRESA(nomeEmpresa)
VALUES ('FOIQUEFOI');



INSERT INTO MARCA (nomeMar)
VALUES ('VW'), ('chevrolet');
GO



INSERT INTO CLIENTE (nomeCliente,sobreNome,dataNascimento)
VALUES ('João','Ribeiro','20/01/2004'), ('Murillo','Andrade','23/09/2005');
GO

DROP TABLE CLIENTE
TRUNCATE TABLE CLIENTE





INSERT INTO MODELO(nomeMod, cod_mar)
VALUES ('golf', 1), ('virtus', 1), ('cruze',2), ('prisma', 2);
GO



INSERT INTO VEICULO (cod_mod, cod_empresa, placa)
VALUES (1,1,'WWW'), (2,3,'EEE'), (3,2,'VVV'), (4,1,'BBB');
GO



INSERT INTO ALUGUEL (cod_cliente, cod_veic, dataRetirada, dataDev)
VALUES (1,2,'03-09-2021', '04-09-2021'), (2,2,'08-09-2021','09-09-2021'),(2,3,'06-08-2021','07-08-2021'),
(1,4,'10-10-2021','11-10-2021');
GO
DROP TABLE ALUGUEL;
GO

INSERT INTO ALUGUEL (cod_cliente, cod_veic, dataRetirada, dataDev)
VALUES (1,2,'03-09-2021 10:29', '04-09-2021 11:29'), (2,2,'08-09-2021 12:30','09-09-2021 12:30'),(2,3,'06-08-2021 13:50','07-08-2021 15:10'),
(1,4,'10-10-2021 17:48','11-10-2021 20:10');
GO
