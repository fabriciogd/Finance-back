using System;
using System.ComponentModel;

namespace Finance.Enums
{
    public enum Categroria
    {
        [Description("Alimentação")]
        Alimentacao = 1,

        [Description("Aluguel")]
        Aluguel,

        [Description("Vestuario")]
        Vestuario,

        [Description("Transporte")]
        Transporte
    }
}
