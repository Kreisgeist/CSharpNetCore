using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    class Escuela
    {
        string nombre;
        public string Nombre
        {
            get { return nombre.ToUpper(); }
            set { nombre = "Copia: " + value; }
        }

        public int AñoDeCreación { get;set; } //hace exactamente lo mismo que declarar la variable y luego su getter y setter

        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public TiposEscuela TipoEscuela { get; set; }
        public Curso[] Cursos { get; set; } //Se asocia el arreglo de cursos con la clase escuela
        public Escuela(string nombre, int año) => (Nombre, AñoDeCreación) = (nombre,año); //Asignación por tuplas

        public Escuela(string nombre, int año, TiposEscuela tipo, string pais ="", string ciudad="") //al asignarle a parametros del constructor, valores por defecto, quiere decir que son prescindibles u opcionales
        {
            (Nombre, AñoDeCreación) = (nombre,año); //Dentro de un constructor "tradicional" tambien se puede hacer la asignación por tuplas
            Pais = pais;
            //this.ciudad = ciudad; No se puede utilizar this en este caso para referirse a una variable de la clase, ya que se definio como una propiedad
            Ciudad = ciudad;
        }
        
        public override string ToString() //Sobreescribe el metodo ToString(); Al ser en C# TODO un objeto, todo hereda de la clase Object, por lo cual todos los objetos tienen el metodo ToString()
        {
            return $"Nombre: \"{Nombre}\", Tipo: {TipoEscuela} \nPais: {Pais}, Ciudad: {Ciudad}"; //Usar el "$" Permite retornar valores de variables
                                                                                                  //dentro de una cadena cada vez que hay "{}"
                                                                                                  //Se pueden usar \ previos a un caracter especial, para regresarlos dentro de la cadena de texto Ej. \" imprime las comillas sin cerrar la cadena.
        }
    }
}