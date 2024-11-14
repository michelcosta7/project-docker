create database email_sender;

\c email_sender
create table emails(
    id serial not null, 
    data_hora timestamp not null default current_timestamp,
    mensagem varchar(250) not null  
);

create database micheldb;

\c micheldb

create table usuario(
    id serial not null, 
    data_hora timestamp not null default current_timestamp,
    nome varchar(100) not null,  
    usuario varchar(100) not null,  
    senha varchar(100) not null,  
    email varchar(100) not null,  
    cpf varchar(20) not null 
);
