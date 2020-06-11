using System;

namespace CoreEscuela.Entidades
{
    public class Curso
    {
        public string UniqueId { get; private set; } //se encapsula el setter y ahora el id solo se puede modificar desde la clase
        public string Nombre { get; set; }
        public TiposJornada Jornada { get; set; } //Para variables como esta en donde es util tener un set de datos por defecto, es en donde se utilizan las enumeraciones

        public Curso() //ctor + Enter para generarlo automaticamente
        {
            UniqueId = Guid.NewGuid().ToString(); //Genera un id automaticamente y lo convierte en string
        }

        
    
    }
}