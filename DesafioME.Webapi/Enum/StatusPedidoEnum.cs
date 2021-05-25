using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioME.Webapi.Enum
{
    public enum StatusPedidoEnum
    {

        [Description("APROVADO")]
        Aprovado,
        [Description("APROVADO_VALOR_A_MENOR")]
        AprovadoValorAMenor,
        [Description("APROVADO_VALOR_A_MAIOR")]
        AprovadoValorAMaior,
        [Description("APROVADO_QTD_A_MAIOR")]
        AprovadoQtdAMaior,
        [Description("APROVADO_QTD_A_MENOR")]
        AprovadoQtdAMenor,
        [Description("REPROVADO")]
        Reprovado,
        [Description("CODIGO_PEDIDO_INVALIDO")]
        CodigoPedidoInvalido

    }
}
