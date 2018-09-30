CREATE DEFINER=`leticiaps`@`%` PROCEDURE `LOGIN_S_FUNCIONARIO`(
	IN usuario varchar(30),
    IN senha varchar(30)
)
BEGIN

	SELECT f.IDfunc
    FROM FUNCIONARIO F
    WHERE F.Usuariofun = usuario
    AND F.Senhafun = senha;

END