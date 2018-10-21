CREATE TABLE Cliente (
Rua VARCHAR(30),
Bairro VARCHAR(30),
Numero INTEGER,
CPFcliente INTEGER PRIMARY KEY,
Ncliente VARCHAR(50),
Nasccliente DATETIME,
Emailcliente VARCHAR(50),
Residencial VARCHAR(16),
Celular VARCHAR(16),
IDevent INTEGER
);




-- TABELA PERFIL
CREATE TABLE tipoPerfil(
    cod_perfil INT IDENTITY(1,1) PRIMARY KEY,
    desc_perfil VARCHAR (15)
);

-- TABELA FUNCIONARIO
CREATE TABLE funcionario(
    cod_func INT IDENTITY(1,1) PRIMARY KEY,
    nome_func VARCHAR(50),
    cpf_func VARCHAR(14),
    usu_func VARCHAR(15),
    senha_func VARCHAR(20),
    perfil_func INT FOREIGN KEY REFERENCES tipoPerfil(cod_perfil)
);

-- TABELA FUNCIONARIO
CREATE TABLE servico(
    cod_serv INT IDENTITY(1,1) PRIMARY KEY,
    desc_serv VARCHAR(50)
);

CREATE TABLE servico_evento(
	cod_serv INT FOREIGN KEY REFERENCES servico(cod_serv), 
	cod_evento INT FOREIGN KEY REFERENCES evento(cod_evento)
);