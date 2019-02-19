﻿using GISModel.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GISCore.Repository.Configuration
{
    public class SESTECContext : DbContext
    {

        public SESTECContext() : base("SESTECConection")
        {
            Database.SetInitializer<SESTECContext>(null);
        }

        
        public DbSet<AnaliseRisco> AnaliseRisco { get; set; }
        
        public DbSet<Rel_AtivEstabTipoRisco> Rel_AtivEstabTipoRisco { get; set; }

        public DbSet<Empresa> Empresa { get; set; }

        public DbSet<Departamento> Departamento { get; set; }

        public DbSet<Estabelecimento> Estabelecimento { get; set; }

        public DbSet<Contrato> Contrato { get; set; }

        public DbSet<AtividadesDoEstabelecimento> AtividadesDoEstabelecimento { get; set; }

        public DbSet<TipoDeRisco> TipoDeRisco { get; set; }

        public DbSet<MedidasDeControleExistentes> MedidasDeControleExistentes { get; set; }

        public DbSet<PossiveisDanos> PossiveisDanos { get; set; }

        public DbSet<EventoPerigoso> EventoPerigoso { get; set; }

        public DbSet<EstabelecimentoAmbiente> EstabelecimentoAmbiente { get; set; }

        public DbSet<Empregado> Empregado { get; set; }

        public DbSet<Admissao> Admissao { get; set; }

        public DbSet<Cargo> Cargo { get; set; }

        public DbSet<Funcao> Funcao { get; set; }

        public DbSet<Atividade> Atividade { get; set; }

        public DbSet<Alocacao> Alocacao { get; set; }

        public DbSet<Equipe> Equipe { get; set; }

        public DbSet<AtividadeAlocada> AtividadeAlocada { get; set; }

        public DbSet<PlanoDeAcao> PlanoDeAcao { get; set; }

        public DbSet<Exposicao> Exposicao { get; set; }

        public DbSet<PerigoPotencial> PerigoPotencial { get; set; }
       
        
        //public DbSet<Alocar> Alocar { get; set; }


        //public DbSet<AtividadeRiscos> AtividadeRiscos { get; set; }


        //public DbSet<REL_TipoRiscoAmbiente> REL_TipoRiscoAmbiente { get; set; }      


        //public DbSet<CNAE> CNAE { get; set; }



        //public DbSet<AlocacaoAtividades> AlocacaoAtividades { get; set; }

        //public DbSet<MedidasControleRiscoFuncao> MedidasControleRiscoFuncao { get; set; }


    }
}
