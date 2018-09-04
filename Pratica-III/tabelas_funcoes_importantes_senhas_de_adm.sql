insert into adm values('admin','admin')
SELECT TOP 1 1 FROM adm where nome = 'admin' and senha = 'admin'

create table ADM(  --adm = secretária
	id int primary key identity(1,1),
	nome varchar(50) not null,
	senha varchar(60) not null
)

create table ESPECIALIDADE_MEDICO(
	id int primary key identity(1,1),
	nome varchar(50) not null
)

create table MEDICO(
	id int primary key identity(1,1),
	nome varchar(50) not null,
	aniversario datetime not null,
	email varchar(50) not null,
	celular varchar(50) not null,
	telefone_residencial varchar(50) not null,
	foto image not null,
	id_especialidade_medico int not null,
	senha varchar(60)
	constraint fkMedicoEspecializacao foreign key(id_especialidade_medico)
		references especialidade_medico(id)
)

create table PACIENTE(
	id int primary key identity(1,1),
	nome varchar(50) not null,
	aniversario datetime not null,
	email varchar(50) not null,
	celular varchar(50) not null,
	telefone_residencial varchar(50) not null,
	foto image not null,
	senha varchar(60)
)

create table CONSULTA(
	id int primary key identity(1,1),
	horario datetime not null,
	id_medico int not null,
	id_paciente int not null,
	concluida bit not null,
	anotacoes ntext,
	duracao bit
	constraint fkMedicoConsulta foreign key(id_medico)
		references medico(id),
	constraint fkPacienteConsulta foreign key(id_paciente)
		references paciente(id)
)