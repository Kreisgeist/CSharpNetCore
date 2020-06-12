using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.App;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;

            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");
            
            var reporteador = new Reporteador(engine.GetDiccionarioObjetos());
            var evalList = reporteador.GetListaEvaluaciones();
            var listaAsig = reporteador.GetListaAsignaturas();
            var listaEvalXAsig = reporteador.GetDicEvaluacionesXAsig();
            var promAlumXAsig = reporteador.GetPromAlumXAsig();
            var promTopXAsig = reporteador.GetTopPromXAsign(5);

            Printer.WriteTitle("Captura de una Evaluación por Consola");
            var newEval = new Evaluación();
            string nombre, notastring;
            float nota;

            WriteLine("Ingrese el nombre de la evaluación");
            Printer.PresioneENTER();
            nombre = ReadLine();

            if(string.IsNullOrWhiteSpace(nombre))
            {
                Printer.WriteTitle("El valor del nombre no puede ser vacío");
                WriteLine("Saliendo del programa");
            }
            else
            {
                newEval.Nombre = nombre.ToLower();
                WriteLine("El nombre de la evaluación ha sido ingresado correctamente");
            }

            WriteLine("Ingrese la nota de la evaluación");
            Printer.PresioneENTER();
            notastring = ReadLine();

            if(string.IsNullOrWhiteSpace(notastring))
            {
                Printer.WriteTitle("El valor de la nota no puede ser vacío");
                WriteLine("Saliendo del programa");
            }
            else
            {
                try
                {
                    newEval.Nota = float.Parse(notastring);
                    if(newEval.Nota < 0 || newEval.Nota > 10)
                    {
                        throw new ArgumentOutOfRangeException("La nota debe estár entre 0 y 5");
                    }
                    WriteLine("La nota de la evaluación ha sido ingresado correctamente");
                }
                catch(ArgumentOutOfRangeException arge)
                {
                    WriteLine(arge.Message);
                    WriteLine("Saliendo del programa");
                } 
                catch (Exception)
                {
                    Printer.WriteTitle("El valor de la nota no es un número valido");
                    WriteLine("Saliendo del programa");
                }
                finally
                {
                    Printer.WriteTitle("FINALLY");
                    Printer.Beep(2500, 500, 3);
                }
            }
        }

        private static void AccionDelEvento(object sender, EventArgs e)
        {
            Printer.WriteTitle("SALIÓ");
        }

        private static void ImpimirCursosEscuela(Escuela escuela)
        {

            Printer.WriteTitle("Cursos de la Escuela");


            if (escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre {curso.Nombre  }, Id  {curso.UniqueId}");
                }
            }
        }
    }
}
