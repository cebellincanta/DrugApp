CREATE TABLE IF NOT EXISTS grupo (
  id uuid not NULL PRIMARY KEY,
  date_create TIMESTAMP NOT NULL,
  is_active INT NOT NULL,
  nome VARCHAR(150) UNIQUE NOT NULL
);
CREATE TABLE IF NOT EXISTS  usuario (
  id uuid not NULL PRIMARY KEY,
  date_create TIMESTAMP NOT NULL,
  is_active INT NOT NULL,
  nome_usuario VARCHAR(50) UNIQUE NOT NULL,
  senha VARCHAR(50) UNIQUE NOT NULL
);

INSERT INTO Usuario(id, date_create, is_active, nome_usuario, senha) values ('53b7a6f5-a2c8-434b-a7a3-054971322e65', '2022-01-01', 1, 'justino@drugovich.com.br', 'j123');
INSERT INTO Usuario(id, date_create, is_active, nome_usuario, senha) values ('a5816f1d-d8ee-4fe2-b6ac-2d7d28d42752', '2022-01-02', 1, 'asdrubino@drugovich.com.br', 'a123');

CREATE TABLE IF NOT EXISTS  gerente (
  id uuid not NULL PRIMARY KEY,
  date_create TIMESTAMP NOT NULL,
  is_active INT NOT NULL,
  nome VARCHAR(200) UNIQUE NOT NULL,
  email VARCHAR(200) UNIQUE NOT NULL,
  nivel VARCHAR(10) NOT NULL,
  usuario_id uuid not NULL,
  constraint gerente_fk
  FOREIGN KEY (usuario_id) REFERENCES usuario (id)
);

INSERT INTO Gerente(id, date_create, is_active, nome, email, nivel, usuario_id) values ('0352c415-5266-42c5-8289-2bf655875b7b', '2022-01-01', 1, 'Jutisno Santos', 'justino@drugovich.com.br', 'UM', '53b7a6f5-a2c8-434b-a7a3-054971322e65');
INSERT INTO Gerente(id, date_create, is_active, nome, email, nivel, usuario_id) values ('56cce9c3-aaae-497d-b1d5-16e3687561ac', '2022-01-02', 1, 'Asdrubino Realison', 'asdrubino@drugovich.com.br', 'DOIS', 'a5816f1d-d8ee-4fe2-b6ac-2d7d28d42752');


CREATE TABLE IF NOT EXISTS  cliente (
  id uuid not NULL PRIMARY KEY,
  date_create TIMESTAMP NOT NULL,
  is_active INT NOT NULL,
  nome VARCHAR(200) UNIQUE NOT NULL,
  cnpj VARCHAR(15) UNIQUE NOT NULL,
  data_fundacao TIMESTAMP NOT NULL,
  grupo_id uuid NOT NULL,
  FOREIGN KEY (grupo_id) REFERENCES grupo (id)
);



    