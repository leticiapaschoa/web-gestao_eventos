CREATE PROCEDURE CADASTRO_I_CLIENTE(
	@cpf varchar(14),
    @nome varchar(50),
    @email varchar(30) = NULL,
    @telefone varchar(11) = NULL
)
AS
BEGIN

    INSERT INTO CLIENTE
    VALUES(@cpf, @nome, @email, @telefone)
    
END