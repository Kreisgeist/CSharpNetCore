using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;

namespace CoreEscuela
{
    public class EscuelaEngine
    {
        public Escuela Escuela { get; set; } //La propiedad del engine es una variable de tipo Escuela, cuyo nombre es Escuela, y tiene los atributos de su clase

        public EscuelaEngine() //Constructor
        {

        }

        public void Inicializar() //Inicialización de un objeto escuela
        {
            Escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria, //Se crea la instancia
            ciudad: "Bogotá", pais: "Colombia"
            );

            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();
        }
        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                var listaAsignaturas = new List<Asignatura>(){ //Cada curso tendra asignadas asignaturas con diferente Id
                    new Asignatura{Nombre="Matemáticas"},
                    new Asignatura{Nombre="Educación Física"},
                    new Asignatura{Nombre="Castellano"},
                    new Asignatura{Nombre="Ciencias Naturales"}
                };
                curso.Asignaturas = listaAsignaturas;
                foreach (var alumno in curso.Alumnos)
                {
                    alumno.Asignaturas = listaAsignaturas;
                }
            }
        }

        private List<Alumno> GenerarAlumnosAlAzar(int cantidad)
        {

            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };

            return listaAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList();//Se recibe como argumento la "cantidad" de alumnos que se desean obtener. Los ordenamos por Id, tomamos solo la cantidad que necesitamos
                                                                                     //y por ultimo convertimos "listaAlumnos" a un tipo de objeto List.
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                    new Curso(){Nombre = "101", Jornada = TiposJornada.Mañana},
                    new Curso(){Nombre = "201", Jornada = TiposJornada.Mañana},
                    new Curso(){Nombre = "301", Jornada = TiposJornada.Mañana},
                    new Curso(){Nombre = "401", Jornada = TiposJornada.Tarde},
                    new Curso(){Nombre = "501", Jornada = TiposJornada.Tarde}
            };

            foreach (var curso in Escuela.Cursos)
            {
                int cantidadRandom = new Random().Next(5, 20); //Genera un entero entre el rango dado, gracias al Metodo Random();
                curso.Alumnos = GenerarAlumnosAlAzar(cantidadRandom);
            }
        }


        private void CargarEvaluaciones()
        {
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var alumno in curso.Alumnos)
                {
                    foreach (var asignatura in alumno.Asignaturas)
                    {
                        asignatura.Evaluaciones = new List<Evaluaciones>();
                        for (int i = 0; i < 5; i++)
                        {
                            asignatura.Evaluaciones.Add(
                                new Evaluaciones() { Nota = (float)( new Random().NextDouble() * 10  ), Nombre = $"Evaluación numero: {i + 1}" }
                                );
                        }
                    }
                }
            }
        }
    }
}