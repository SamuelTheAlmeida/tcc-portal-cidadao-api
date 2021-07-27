-- SQLINES LICENSE FOR EVALUATION USE ONLY

CREATE DATABASE PortalCidadao;
USE PortalCidadao;

CREATE TABLE Orgao
(
	Id int primary key auto_increment,
	Nome varchar(60) not null
);

-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE Categoria 
(
	Id int primary key auto_increment,
	Nome varchar(50) not null,
	Descricao varchar(200) not null,
	OrgaoId int not null,
	FOREIGN KEY (OrgaoId) REFERENCES Orgao (Id)
);

-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE Usuario
(
	Id int primary key auto_increment,
	CPF varchar(11) not null,
	Nome varchar(200) not null,
	Email varchar(320) not null,
	Senha varchar(32) not null,
	Perfil tinyint unsigned not null,
	EmailConfirmado tinyint not null,
	DataCadastro DATETIME not null
);

-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE Postagem
(
	Id int primary key auto_increment,
	CategoriaId int not null,
	Subcategoria tinyint unsigned not null,
	Titulo varchar(60) not null,
	Descricao varchar(500) not  null,
	ImagemUrl varchar(500) not null,
	Latitude double not null,
	Longitude double not null,
	Bairro varchar(60) not null,
	UsuarioId int not null,
	DataCadastro DATETIME not null,
	Resolvido tinyint not null,
	FOREIGN KEY (UsuarioId) REFERENCES Usuario (Id),
	FOREIGN KEY (CategoriaId) REFERENCES Categoria (Id)
);

-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE Curtida
(
	Id int primary key auto_increment,
	PostagemId int not null,
	UsuarioId int not null,
	Acao tinyint not null,
	Pontos double not null,
	FOREIGN KEY (PostagemId) REFERENCES Postagem (Id),
	FOREIGN KEY (UsuarioId) REFERENCES Usuario (Id)
);

-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE Comentario
(
	Id int primary key auto_increment,
	UsuarioId int not null,
	PostagemId int not null,
	Descricao varchar(250) not null,
	DataCadastro DATETIME not null,
	FOREIGN KEY (PostagemId) REFERENCES Postagem (Id),
	FOREIGN KEY (UsuarioId) REFERENCES Usuario (Id)
);