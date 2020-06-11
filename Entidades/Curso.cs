using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Curso
    {
        public string UniqueId { get; private set; } //se encapsula el setter y ahora el id solo se puede modificar desde la clase
        public string Nombre { get; set; }
        public TiposJornada Jornada { get; set; } //Para variables como esta en donde es util tener un set de datos por defecto, es en donde se utilizan las enumeraciones
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }
        public Curso() => UniqueId = Guid.NewGuid().ToString();
    }
}