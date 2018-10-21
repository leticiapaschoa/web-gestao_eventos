CREATE PROCEDURE CADASTRO_I_EVENTO_SERVICO(     
    @desc_servico VARCHAR(30)
) 
AS 
BEGIN 

DECLARE @cod_servico INT
DECLARE @cod_evento INT

SET @cod_evento = (SELECT MAX(cod_evento) FROM evento)

SET @cod_servico = (SELECT TOP 1 s.cod_serv FROM servico s WHERE s.desc_serv = @desc_servico)

INSERT INTO servico_evento 
VALUES(@cod_servico, @cod_evento) 
END