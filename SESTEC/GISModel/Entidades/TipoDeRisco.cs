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

        [Display(Name ="Descrição do Risco")]
        public string DescricaoDoRisco { get; set; }        
        
        [Display(Name ="Possíveis Danos a Saúde")]
        public string idPossiveisDanos { get; set; }

        public string idEventoPerigoso { get; set; }

        [Display(Name ="Vincular")]
        public bool Vinculado { get; set; }
       
        public virtual EventoPerigoso EventoPerigoso { get; set; }

        public virtual PossiveisDanos PossiveisDanos { get; set; }

        public virtual ICollection<AtividadesDoEstabelecimento> AtividadesDoEstabelecimento { get; set; }



    }
}   
