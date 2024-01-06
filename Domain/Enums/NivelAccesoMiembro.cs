using System.ComponentModel;

namespace Domain.Enums
{
    public enum NivelAccesoMiembro
    {
        [Description("Crear & Visualizar todos las asistencia independientemente del departamento.")]
        SUPERVISOR_GENERAL = 1,
        
        [Description("Crear & Visualizar las asistencias de todos los tramos pertenecientes a su departamento.")]
        SUPERVISOR_NACIONAL,

        [Description("Crear & Visualizar todos las asistencias en su region encargada segun su departamento.")]
        SUPERVISOR_REGIONAL,

        [Description("Crear & Visualizar solo las asistencias de su tramo segun su departamento")]
        ENCARGADO_TRAMO,

        [Description("Crear & Visualizar solo las asistencias completadas por el mismo.")]
        PATRULLERO       
    }
}