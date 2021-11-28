#senha Samuel testeeeeee
#senha Gustavo 123456789

USE PortalCidadao;
INSERT INTO Usuario
(CPF, Nome, Email, Senha, Perfil, EmailConfirmado, DataCadastro)
VALUES
('10472210980', 'Samuel', 'samuel@gmail.com', 'a3faae1bbee471f80d7b3fbdcbb34f9c', 1, 0, NOW()),
('09161484911', 'Gustavo', 'gustavo@gmail.com', '25f9e794323b453885f5181f1b624d0b', 1, 0, NOW());

INSERT INTO Orgao 
(Nome) 
VALUES 
('Prefeitura Municipal de Curitiba'),
('Copel'),
('Secretaria Municipal de Defesa Social e Trânsito'),
('URBS'),
('Secretaria Municipal do Meio Ambiente'),
('Secretaria da Segurança Pública'),
('Fundação de Ação Social de Curitiba - FAS'),
('Centro de Controle de Zoonoses e Vetores de Curitiba');

INSERT INTO Categoria 
(Nome, Descricao, Orgaoid) 
VALUES 
('Espaços públicos', 'Espaços públicos', 1),
('Iluminação', '', 2),
('Trânsito/Pavimentação', '', 3),
('Calçadas', '', 4),
('Acessibilidade', '', 4),
('Transporte público', '', 4) ,
('Meio ambiente', '', 5),
('Eventos', '', 1),
('Vandalismo', '', 6) ,
('Segurança', '', 6) ,
('Pessoa em situação de rua', '', 7),
('Zoonoses', '', 8);

