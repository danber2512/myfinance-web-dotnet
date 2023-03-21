USE myfinance

DELETE FROM transacao
DELETE FROM planoconta
DELETE FROM logexclusao

INSERT INTO planoconta(descricao, tipo) VALUES('Gasolina', 'D')
INSERT INTO transacao(data, valor, historico, planocontaid) VALUES('20230314', 100, 'Celta', IDENT_CURRENT('planoconta'))
INSERT INTO transacao(data, valor, historico, planocontaid) VALUES('20230313', 150, 'Fit', IDENT_CURRENT('planoconta'))

INSERT INTO planoconta(descricao, tipo) VALUES('Supermercado', 'D')
INSERT INTO transacao(data, valor, historico, planocontaid) VALUES('20230301', 1500, 'Compras do mes', IDENT_CURRENT('planoconta'))
INSERT INTO transacao(data, valor, historico, planocontaid) VALUES('20230301', 500, 'Açougue', IDENT_CURRENT('planoconta'))

INSERT INTO planoconta(descricao, tipo) VALUES('Contas Casa', 'D')
INSERT INTO transacao(data, valor, historico, planocontaid) VALUES('20230307', 500, 'Condomínio', IDENT_CURRENT('planoconta'))
INSERT INTO transacao(data, valor, historico, planocontaid) VALUES('20230325', 200, 'CEMIG', IDENT_CURRENT('planoconta'))

INSERT INTO planoconta(descricao, tipo) VALUES('Aluguel', 'D')
INSERT INTO transacao(data, valor, historico, planocontaid) VALUES('20230310', 3000, 'Aluguel Apto', IDENT_CURRENT('planoconta'))
INSERT INTO transacao(data, valor, historico, planocontaid) VALUES('20230310', 300, 'Aluguel Garagem', IDENT_CURRENT('planoconta'))

INSERT INTO planoconta(descricao, tipo) VALUES('Salário', 'R')
INSERT INTO transacao(data, valor, historico, planocontaid) VALUES('20230305', 10000, 'Salário Mensal', IDENT_CURRENT('planoconta'))
INSERT INTO transacao(data, valor, historico, planocontaid) VALUES('20230305', 10000, 'Comissão', IDENT_CURRENT('planoconta'))

INSERT INTO planoconta(descricao, tipo) VALUES('Renda Investimentos', 'R')
INSERT INTO transacao(data, valor, historico, planocontaid) VALUES('20230301', 500, 'CDB', IDENT_CURRENT('planoconta'))
INSERT INTO transacao(data, valor, historico, planocontaid) VALUES('20230301', 500, 'Dividendos Ações', IDENT_CURRENT('planoconta'))