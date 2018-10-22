ALTER PROCEDURE BUSCA_SERVICO(     
    @desc_servico VARCHAR(30)
) 
AS 
BEGIN 

SELECT TOP 1 
    s.in_preco_fixo AS IN_PRECO_FIXO,
    ISNULL(s.preco_fixo, 0) AS PRECO_FIXO,
    ISNULL(s.preco_unit,0) AS PRECO_UNIT
FROM servico s 
WHERE s.desc_serv = @desc_servico

END