using System;
using System.Linq;
using System.Collections.Generic;
using CoreEscuela.Entidades;

namespace CoreEscuela.App
{
    public class Reporteador
    {
        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;
        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dicObjEsc)
        {
            if (dicObjEsc == null)
                throw new ArgumentNullException(nameof(dicObjEsc));
            _diccionario = dicObjEsc;
        }

        public IEnumerable<Evaluación> GetListaEvaluaciones()
        {
            if (_diccionario.TryGetValue(LlaveDiccionario.Evaluacion, out IEnumerable<ObjetoEscuelaBase> lista))
            {
                return lista.Cast<Evaluación>();
            }
            else
            {
                return new List<Evaluación>();
                //Escribir en el log de auditoria
            }
        }
        public IEnumerable<string> GetListaAsignaturas()
        {
            return GetListaAsignaturas(out var dummy);
        }
        public IEnumerable<string> GetListaAsignaturas(out IEnumerable<Evaluación> listaEvaluaciones)
        {
            listaEvaluaciones = GetListaEvaluaciones();

            return (from Evaluación ev in listaEvaluaciones
                    select ev.Asignatura.Nombre).Distinct();
        }
        public Dictionary<string, IEnumerable<Evaluación>> GetDicEvaluacionesXAsig()
        {
            var dicRta = new Dictionary<string, IEnumerable<Evaluación>>();

            var listaAsignaturas = GetListaAsignaturas(out var listaEvaluaciones);

            foreach (var asignatura in listaAsignaturas)
            {
                var evalsAsig = from eval in listaEvaluaciones
                                where eval.Asignatura.Nombre == asignatura
                                select eval;

                dicRta.Add(asignatura, evalsAsig);
            }

            return dicRta;
        }
        public Dictionary<string, IEnumerable<object>> GetPromAlumXAsig()
        {
            var rta = new Dictionary<string, IEnumerable<object>>();
            var dicEvalXAsig = GetDicEvaluacionesXAsig();

            foreach (var asigConEval in dicEvalXAsig)
            {
                var promsAlumn = from eval in asigConEval.Value                 
                            group  eval by new {eval.Alumno.UniqueId, eval.Alumno.Nombre}
                            into grupoEvalAlumno
                            select new AlumnoPromedio
                            {
                                alumnoId = grupoEvalAlumno.Key.UniqueId,
                                alumnoNombre = grupoEvalAlumno.Key.Nombre,
                                promedio =  grupoEvalAlumno.Average( evaluacion=> evaluacion.Nota )
                            };
                rta.Add(asigConEval.Key, promsAlumn);
            }

            return rta;
        }
    }
}