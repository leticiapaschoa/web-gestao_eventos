CREATE PROCEDURE CADASTRO_S_CLIENTE(
	@cpf varchar(14)    
)
AS
BEGIN

    SELECT *
    FROM cliente
    WHERE cpf = @cpf    
END