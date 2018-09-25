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


SELECT M.nome, count(c.id_medico) FROM CONSULTA AS C
		JOIN MEDICO AS M ON C.id_medico = M.id
		WHERE
		YEAR(C.horario) = 2018 AND
		MONTH(C.horario) = 9
		GROUP BY M.nome
