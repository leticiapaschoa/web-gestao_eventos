CREATE PROCEDURE LOGIN_S_FUNCIONARIO(
	@usuario varchar(15),
    @senha varchar(20)
)
AS
BEGIN

	SELECT 1
    FROM funcionario f
    WHERE f.usu_func = @usuario
    AND f.senha_func = @senha;

END