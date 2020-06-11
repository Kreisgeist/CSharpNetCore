using CoreEscuela.Entidades;
using static System.Console;

namespace CoreEscuela.Util
{
    public static class Printer
    {
        public static void DibujarLinea(int tam = 10)
        {
            WriteLine("".PadLeft(tam,'='));
        }

        public static void WriteTitle(string titulo)
        {
            var tamaño = titulo.Length + 4;
            DibujarLinea(tamaño);
            WriteLine($"| {titulo} |");
            DibujarLinea(tamaño);
        }

        public static void ImprimirCursosEscuela(Escuela escuela)
        {
            Printer.WriteTitle("Cursos de la Escuela");

            if (escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre: {curso.Nombre}, Id: {curso.UniqueId}");
                }
            }
        }        
        public static void ImprimirAlumnosCurso(Escuela escuela)
        {
            foreach (var curso in escuela.Cursos)
            {
                WriteTitle($"Curso {curso.Nombre}");
                foreach (var alumno in curso.Alumnos)
                {
                    WriteLine($"Nombre: {alumno.Nombre}, Id: {alumno.UniqueId}, Asignaturas: {alumno.Asignaturas.Count}");   
                }
            }
        }

    }
}