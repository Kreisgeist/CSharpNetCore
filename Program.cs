using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using static CoreEscuela.Util.Printer;
using static System.Console;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine(); //Toda la logica de la clase Escuela se refactorizó en un Engine para la clase
            engine.Inicializar();
            WriteTitle("Bienvenidos a la Escuela");
            
            ImprimirCursosEscuela(engine.Escuela);
            ImprimirAlumnosCurso(engine.Escuela);

        }
    }
}
