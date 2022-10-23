CREATE TABLE IF NOT EXISTS Grupo (
  id uuid not NULL PRIMARY KEY,
  date_create TIMESTAMP NOT NULL,
  is_active BIT NOT NULL,
  nome VARCHAR(150) UNIQUE NOT NULL
);

CREATE TABLE IF NOT EXISTS  Gerente (
  id uuid not NULL PRIMARY KEY,
  date_create TIMESTAMP NOT NULL,
  is_active BIT NOT NULL,
  nome VARCHAR(200) UNIQUE NOT NULL,
  email VARCHAR(200) UNIQUE NOT NULL,
  nivel VARCHAR(10) NOT NULL
);

CREATE TABLE IF NOT EXISTS  Usuario (
  id uuid not NULL PRIMARY KEY,
  date_create TIMESTAMP NOT NULL,
  is_active BIT NOT NULL,
  nome_usuario VARCHAR(20) UNIQUE NOT NULL,
  senha VARCHAR(50) UNIQUE NOT NULL,
  gerente_id uuid NOT NULL,
  FOREIGN KEY (gerente_id) REFERENCES "gerente" (id)
);

CREATE TABLE IF NOT EXISTS  Cliente (
  id uuid not NULL PRIMARY KEY,
  date_create TIMESTAMP NOT NULL,
  is_active BIT NOT NULL,
  nome VARCHAR(200) UNIQUE NOT NULL,
  cnpj VARCHAR(15) UNIQUE NOT NULL,
  data_fundacao TIMESTAMP NOT NULL,
  grupo_id uuid NOT NULL,
  FOREIGN KEY (grupo_id) REFERENCES "grupo" (id)
);



    