using System.ComponentModel;

namespace Domain.Enums
{
    public enum ReportadoPor
    {
        [Description("Solo para operadores de R-5")]
        CALL_CENTER = 1,

        [Description("Solo para los soldados y agentes en la via")]
        AGENTE_CAMPO,

        [Description("En caso de la asistencia ser reportada por el 911.")]
        AGENTE_911
    }
}