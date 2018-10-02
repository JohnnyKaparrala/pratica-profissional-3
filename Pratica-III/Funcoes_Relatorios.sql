CREATE FUNCTION consultaMensalMed (@mes int, @ano int)
RETURNS TABLE
AS
RETURN (
	SELECT M.nome as nome, count(c.id_medico) as Consultas FROM CONSULTA AS C
	JOIN MEDICO AS M ON C.id_medico = M.id
	WHERE
	YEAR(C.horario) = @ano AND
	MONTH(C.horario) = @mes
	GROUP BY M.nome
);

SELECT id,nome FROM MEDICO

--1
SELECT M.nome, count(c.id_medico) FROM CONSULTA AS C JOIN MEDICO AS M ON C.id_medico = M.id WHERE YEAR(C.horario) = 2018 AND MONTH(C.horario) = 9 GROUP BY M.nome

select  count(*), DATENAME(month,horario) from CONSULTA group by year(horario),month(horario)
insert consulta values(GETDATE(),2,8,1,NULL,1)

SELECT count(*) as qtd, RIGHT(CONVERT(CHAR(10),horario,103),7) as data FROM CONSULTA WHERE id_medico = 2 group by year(horario),month(horario)
