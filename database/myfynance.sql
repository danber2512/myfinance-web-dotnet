CREATE DATABASE myfinance

use myfinance

create table planoconta(
	id int identity(1,1) not null,
	descricao varchar (50) not null,
	tipo char(1) not null,
	primary key (id)
);

create table transacao(
	id int identity (1,1) not null,
	data datetime not null,
	valor decimal (9,2),
	historico text,
	planocontaid int not null,
	primary key (id),
	foreign key (planocontaid) references planoconta(id)
);

CREATE TABLE logexclusao(
	id int identity(1,1) not null,
	data datetime not null,
	operacao char(1) not null,
	historico text,
	tabela text not null,
	idregistro int not null
)

INSERT INTO planoconta(descricao, tipo) VALUES('Gasolina', 'D')
INSERT INTO planoconta(descricao, tipo) VALUES('Supermercado', 'D')
INSERT INTO planoconta(descricao, tipo) VALUES('Contas Casa', 'D')
INSERT INTO planoconta(descricao, tipo) VALUES('Aluguel', 'D')
INSERT INTO planoconta(descricao, tipo) VALUES('Salário', 'R')
INSERT INTO planoconta(descricao, tipo) VALUES('Renda Investimentos', 'R')

INSERT INTO transacao(data, valor, historico, planocontaid) VALUES('20230301', 1500, 'Compras do mes', 22)
INSERT INTO transacao(data, valor, historico, planocontaid) VALUES('20230325', 200, 'CEMIG', 23)
INSERT INTO transacao(data, valor, historico, planocontaid) VALUES('20230310', 3000, 'Aluguel Apto', 24)
INSERT INTO transacao(data, valor, historico, planocontaid) VALUES('20230305', 10000, 'Salário Mensal', 25)
INSERT INTO transacao(data, valor, historico, planocontaid) VALUES('20230301', 500, 'CDB', 26)
INSERT INTO transacao(data, valor, historico, planocontaid) VALUES('20230307', 500, 'Condomínio', 23)
INSERT INTO transacao(data, valor, historico, planocontaid) VALUES('20230314', 100, 'Celta', 21)
INSERT INTO transacao(data, valor, historico, planocontaid) VALUES('20230313', 150, 'Fit', 21)