﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace GISModel.Entidades
{
    [Table("tbAdmissao")]
    public class Admissao : EntidadeBase
    {

        [Key]
        public string  IDAdmissao { get; set; }


        [Display(Name = "Empregado")]
        public string IDEmpregado { get; set; }


        [Display(Name = "Empresa")]
        public string IDEmpresa { get; set; }
        

        [Display(Name = "Admissão")]
        [Required(ErrorMessage = "Informe a data de admissão")]
        public string DataAdmissao { get; set; }

        [Display(Name = "Demissão")]
        public string DataDemissao { get; set; }

        [Display(Name ="Foto")]
        public string Imagem { get; set; }

       
        public string Admitido { get; set; }


        public virtual Empresa Empresa { get; set; }       

        public virtual Empregado Empregado { get; set; }

    }
}
