﻿using GISModel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISModel.Entidades
{
    [Table("tbTipoDeRisco")]
    public class TipoDeRisco: EntidadeBase
    {
        [Key]
        public string IDTipoDeRisco { get; set; }

        [Display(Name ="Descrição do evento Perigoso")]
        public string idPerigoPotencial { get; set; }        
        
        [Display(Name ="Possíveis Danos a Saúde")]
        public string idPossiveisDanos { get; set; }

        public string idEventoPerigoso { get; set; }

        [Display(Name = "Atividade do Estabelecimento")]
        public string idAtividadesDoEstabelecimento { get; set; }

        [Display(Name ="Classifique o Risco")]
        public EClasseDoRisco EClasseDoRisco { get; set; }

        [Display(Name = "Fonte Geradora")]
        public string FonteGeradora { get; set; }

        [Display(Name = "Tragetória")]
        public string Tragetoria { get; set; }

        [Display(Name ="Vincular")]
        public bool Vinculado { get; set; }
       
        public virtual EventoPerigoso EventoPerigoso { get; set; }

        public virtual PossiveisDanos PossiveisDanos { get; set; }

        public virtual PerigoPotencial PerigoPotencial { get; set; }

        public virtual AtividadesDoEstabelecimento AtividadesDoEstabelecimento {get; set;}

        //public virtual ICollection<AtividadesDoEstabelecimento> AtividadesDoEstabelecimento { get; set; }



    }
}   
