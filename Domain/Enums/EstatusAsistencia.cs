using System.ComponentModel;

namespace Domain.Enums
{
    public enum EstatusAsistencia
    {
        [Description("Solo aplica si la asistencia es creada por los operadores en R-5")]
        PENDIENTE = 1,

        [Description("Aplica para los soldados, creara una asistencia en espera de ser completada.")]
        EN_CURSO,

        [Description("Aplica cuando la asistencia ya ha sido completada.")]
        COMPLETADA
    }
}