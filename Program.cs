using System;
using CoreEscuela.Entidades;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria,
                        ciudad:"Bogotá", pais:"Colombia" //Se pueden meter parametros opcionales, sin importar el orden, simplemente haciendo referencia a la variable argumento que recibe el constructor
                        );


            Console.WriteLine(escuela); //Imprime el valor que retorna el metodo ToString();
        }
    }
}
