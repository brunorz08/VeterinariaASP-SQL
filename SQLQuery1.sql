select * from animales
select * from medicos
select * From Especialidades

select a.nombre,m.nombre,e.nombre from animales a inner join medicos m on a.MedicoId = m.id
inner join Especialidades e on m.EspecialidadId = e.Id