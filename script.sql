-- CRIANDO O BANCO DE DADOS 
CREATE DATABASE bdloja2dsa;

-- USANDO O BANCO DE DADOS
USE bdloja2dsa;

-- CRIANDO AS TABELAS DO BANCO DE DADOS
CREATE TABLE Usuario(
id int primary key auto_increment,
nome varchar(40) not null,
email varchar(40) not null,
senha varchar(40) not null
);

CREATE TABLE Produto(
id int primary key auto_increment,
nome varchar(40) not null,
descricao varchar(40) not null,
preco int not null,
quant int not null
);
-- CONSULTANDO AS TABELAS DO BANCO DE DADOS
SELECT * FROM Usuario;
SELECT * FROM Produto;

INSERT INTO Usuario (email, senha) Values ("@email", "@senha");
