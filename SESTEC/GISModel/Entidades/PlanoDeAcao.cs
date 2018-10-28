﻿using GISModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GISModel.Entidades
{
    [Table("tbPlanoDeAcao")]
    public class PlanoDeAcao: EntidadeBase
    {
        [Key]
        public string IDPlanoDeAcao { get; set; }

        [Display(Name ="Tipo do Plano de Ação")]
        public ETipoPlanoAcao TipoDoPlanoDeAcao { get; set; }

        
        [Required]
        [Display(Name = "Descrição do Plano de Ação")]
        [StringLength(200,MinimumLength =30)]
        public string  DescricaoDoPlanoDeAcao { get; set; }

        [Display(Name ="Responsável")]
        public string Responsavel { get; set; }

        [Display(Name ="Data Prevista")]   
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataPrevista { get; set; }

        [Display(Name ="Entregue")]
        public string Entregue { get; set; }

        [Display(Name ="Responsável pela entrega")]
        public string ResponsavelPelaEntrega { get; set; }

        //[Display(Name = "Nome da Imagem")]
        //public string NomeDaImagem { get; set; }

        //[Display(Name = "Imagem")]
        //public string Imagem { get; set; }

        [Display(Name ="Identificador")]
        public string Identificador { get; set; }

        [Display(Name = "Gerência")]
        public string Gerencia { get; set; }



    }
}
