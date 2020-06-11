using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Escuela
    {
        public string UniqueId { get; set; } = Guid.NewGuid().ToString();
        string nombre;
        public string Nombre
        {
            get { return nombre.ToUpper(); }
            set { nombre = "Copia: " + value; }
        }

        public int AñoDeCreación { get;set; } 

        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public TiposEscuela TipoEscuela { get; set; }
        public List<Curso> Cursos { get; set; } 
        public Escuela(string nombre, int año) => (Nombre, AñoDeCreación) = (nombre,año); 

        public Escuela(string nombre, int año, TiposEscuela tipo, string pais ="", string ciudad="")  
        {
            (Nombre, AñoDeCreación) = (nombre,año); 
            Pais = pais;
            Ciudad = ciudad;
        }
        
        public override string ToString() 
        {
            return $"Nombre: \"{Nombre}\", Tipo: {TipoEscuela} \nPais: {Pais}, Ciudad: {Ciudad}"; 
        }
    }
}