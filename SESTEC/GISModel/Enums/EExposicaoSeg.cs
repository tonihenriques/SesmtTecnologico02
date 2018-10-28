using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISModel.Enums
{
    public enum EExposicaoSeg
    {
        // Diária, com necessidade frequente de horas extras
        [Display(Name = "Muito Alta")]
        Muito_Alta = 1,

        //Diária
        [Display(Name = "Alta")]
        Alta = 2,

        //Semanal
        [Display(Name = "Média")]
        Media = 3,

        // Mensal
        [Display(Name = "Baixa")]
        Baixa = 4,

        // Semestral
        [Display(Name = "Muito Baixa")]
        Muito_Baixa = 5




    }
}

