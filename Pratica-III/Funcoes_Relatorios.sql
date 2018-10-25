--relat1
SELECT count(*) as quantidade, RIGHT(CONVERT(CHAR(10),horario,103),7) as data 
	FROM CONSULTA WHERE id_medico = 2 group by RIGHT(CONVERT(CHAR(10),horario,103),7)
--                      ^ ^ ^ ^ ^ ^ ^

--relat2
select count(*) as quantidade, e.nome as especialidade from CONSULTA c, MEDICO m, ESPECIALIDADE_MEDICO e 
	where c.id_medico = m.id and m.id_especialidade_medico = e.id 
	and CONVERT(CHAR(10),C.horario,103) = '04/10/2018' group by e.nome
--                                         ^ ^ ^ ^ ^ 
 
--relat3
select count(distinct c.id_paciente) as quantidade, m.nome as medico	from CONSULTA c, MEDICO m where c.id_medico = m.id group by c.id_paciente, m.nome 

--relat4
select count(*) as quantidade, RIGHT(CONVERT(CHAR(10),horario,103),7) as mes from CONSULTA	where concluida = -1 and id_medico = 2	group by id_medico, RIGHT(CONVERT(CHAR(10),horario,103),7) --    ^ ^ ^ ^ ^ ^ ^


select * from CONSULTA
select * from MEDICO
select * from ESPECIALIDADE_MEDICO

insert CONSULTA values (GETDATE(),3,8,1,null,1)
