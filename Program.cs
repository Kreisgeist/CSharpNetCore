using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using static System.Console;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria,
                        ciudad: "Bogotá", pais: "Colombia" //Se pueden meter parametros opcionales, sin importar el orden, simplemente haciendo referencia a la variable argumento que recibe el constructor
                        );

            /*var arregloCursos = new Curso[3] { //Versiones anteriores de C# no reconocen el tipo de dato var.
                        new Curso(){Nombre = "101"},
                        new Curso(){Nombre = "201"},
                        new Curso{Nombre = "301"}
            };*/

            /*arregloCursos = new Curso[] { //Podemos hacerlo aun más compacto
                        new Curso(){Nombre = "101"},
                        new Curso(){Nombre = "201"},
                        new Curso{Nombre = "301"}
            };*/

            escuela.Cursos = new Curso[]{ //Se realiza la asignación directa de los cursos al atributo Curso[] Cursos de la clase Escuela 
                        new Curso(){Nombre = "101"},
                        new Curso(){Nombre = "201"},
                        new Curso{Nombre = "301"}
            };

            ImprimirCursosEscuela(escuela);

        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            WriteLine("============================================");
            WriteLine("=========== Cursos de la Escuela ===========");
            WriteLine("============================================");

            if (escuela?.Cursos != null) //No revisará el la condición de cursos, a menos que escuela sea diferente de null
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre: {curso.Nombre}, Id: {curso.UniqueId}");
                }
            }
        }

        private static void ImprimirCursosWhile(Curso[] arregloCursos) //presionando F2 o click derecho -> Rename Symbol, puedes cambiar el nombre del metodo y se cambia en cualquier invocacion del programa
        {
            int contador = 0;
            while (contador < arregloCursos.Length)
            {
                WriteLine($"Nombre: {arregloCursos[contador].Nombre}, Id: {arregloCursos[contador].UniqueId}");
                contador++;
            }
        }

        private static void ImprimirCursosDoWhile(Curso[] arregloCursos) //presionando F2 o click derecho -> Rename Symbol, puedes cambiar el nombre del metodo y se cambia en cualquier invocacion del programa
        {
            int contador = 0;
            do
            {
                WriteLine($"Nombre: {arregloCursos[contador].Nombre}, Id: {arregloCursos[contador].UniqueId}");
                contador++;
            } while (contador < arregloCursos.Length);//Realiza el incremento despues de preguntar por la condición. Si se coloca ++Contador, primero realiza el incremento.
        }

        private static void ImprimirCursosFor(Curso[] arregloCursos)
        {
            for (int i = 0; i < arregloCursos.Length; i++)
            {
                WriteLine($"Nombre: {arregloCursos[i].Nombre}, Id: {arregloCursos[i].UniqueId}");
            }
        }

        private static void ImprimirCursosForEach(Curso[] arregloCursos)
        {
            foreach (var curso in arregloCursos)
            {
                WriteLine($"Nombre: {curso.Nombre}, Id: {curso.UniqueId}");
            }
        }
    }
}
