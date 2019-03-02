using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace GISModel.Entidades
{
    [Table("tbAnaliseRisco")]
    public class AnaliseRisco : EntidadeBase
    {

        [Key]
        public string IDAnaliseRisco { get; set; }

        [Display(Name = "Empregado")]
        public string IDEmpregado { get; set; }

        [Display(Name = "Empresa")]
        public string IDEmpresa { get; set; }

        [Display(Name ="Atividade Alocada")]
        public string IDAtividadeAlocada { get; set; }

        [Display(Name = "Alocação")]
        public string IDAlocacao { get; set; }

        [Display(Name = "Foto do empregado")]
        public string Imagem { get; set; }

        [Display(Name ="Atividade")]
        public string IDAtividadesDoEstabelecimento { get; set; }

        [Display(Name ="Risco")]
        public string IDRisco { get; set; }

        [Display(Name ="Possíveis Danos")]
        public string IDPossiveisDanos { get; set; }

        [Display(Name ="Medidas de Controle")]
        public string IDControle { get; set; }

        public virtual AtividadeAlocada AtividadeAlocada { get; set; }

        public virtual Alocacao Alocacao{ get; set; }




    }
}
