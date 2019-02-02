﻿using GISCore.Business.Abstract;
using GISModel.DTO.Shared;
using GISModel.Entidades;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GISWeb.Controllers
{
    public class AlocacaoController : Controller
    {

        #region


        

        [Inject]
        public ITipoDeRiscoBusiness TipoDeRiscoBusiness { get; set; }

        [Inject]
        public IAtividadeBusiness AtividadeBusiness { get; set; }

        //[Inject]
        //public IExposicaoBusiness ExposicaoBusiness { get; set; }

        [Inject]
        public IEquipeBusiness EquipeBusiness { get; set; }

        [Inject]
        public IFuncaoBusiness FuncaoBusiness { get; set; }
        [Inject]
        public ICargoBusiness CargoBusiness { get; set; }
        [Inject]
        public IContratoBusiness ContratoBusiness { get; set; }

        [Inject]
        public IAlocacaoBusiness AlocacaoBusiness { get; set; }
        [Inject]
        public IAdmissaoBusiness AdmissaoBusiness { get; set; }

        [Inject]
        public IDepartamentoBusiness DepartamentoBusiness { get; set; }


        [Inject]
        public IEmpresaBusiness EmpresaBusiness { get; set; }

        [Inject]
        public IEmpregadoBusiness EmpregadoBusiness { get; set; }

        [Inject]
        public IEstabelecimentoBusiness EstabelecimentoBusiness { get; set; }

        [Inject]
        public IAtividadesDoEstabelecimentoBusiness AtividadesDoEstabelecimentoBusiness { get; set; }

        [Inject]
        public IMedidasDeControleBusiness MedidasDeControleBusiness { get; set; }

        [Inject]
        public IEstabelecimentoAmbienteBusiness EstabelecimentoAmbienteBusiness { get; set; }

        //[Inject]
        //public IAlocacaoAtividadesBusiness AlocacaoAtividadesBusiness { get; set; }

        //[Inject]
        //public IAtividadeRiscosBusiness AtividadeRiscosBusiness { get; set; }

        #endregion



        // GET: Alocacao
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Novo(string IDAdmissao,string IDEmpregado,string IDEmpresa)
        {

            ViewBag.Equipe = new SelectList(EquipeBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList(), "IDEquipe", "NomeDaEquipe");
            ViewBag.pAdmissao = IDAdmissao;
            ViewBag.pEmpregado = IDEmpregado;
            ViewBag.Admissao = AdmissaoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)&& p.IDAdmissao.Equals(IDAdmissao) ).ToList();
            ViewBag.Contrato = new SelectList(ContratoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList(), "IDContrato", "NumeroContrato");
            ViewBag.Departamento = new SelectList(DepartamentoBusiness.Consulta.ToList(), "IDDepartamento", "Sigla");
            ViewBag.Cargo = new SelectList(CargoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList(), "IDCargo", "NomeDoCargo");
            ViewBag.Funcao = new SelectList(FuncaoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList(), "IDFuncao", "NomeDaFuncao");
            ViewBag.Estabelecimento = new SelectList(EstabelecimentoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList(), "IDEstabelecimento", "NomeCompleto");


            try
            {
                Admissao oAdmissao = AdmissaoBusiness.Consulta.FirstOrDefault(p => p.IDEmpregado.Equals(IDAdmissao));
                if (ViewBag.Admissao == null)
                {
                    return Json(new { resultado = new RetornoJSON() { Alerta = "Imagens não encontrada." } });
                }
                else
                {
                    return Json(new { data = RenderRazorViewToString("_Novo", oAdmissao) });
                }
            }
            catch (Exception ex)
            {
                if (ex.GetBaseException() == null)
                {
                    return Json(new { resultado = new RetornoJSON() { Erro = ex.Message } });
                }
                else
                {
                    return Json(new { resultado = new RetornoJSON() { Erro = ex.GetBaseException().Message } });
                }
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Alocacao oAlocacao, string IDAdmissao, string IDEmpregado)
        {

            //id da Admissão recebido por parametro
            oAlocacao.IdAdmissao = IDAdmissao;
           
            if (ModelState.IsValid)
            {
                try
                {

                    AlocacaoBusiness.Inserir(oAlocacao);

                    TempData["MensagemSucesso"] = "O empregado foi Alocado com sucesso.";

                    
                    //precisa passa o id do Empregado
                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("PerfilEmpregado", "Admissao", new { id = IDEmpregado }) } });


                }
                catch (Exception ex)
                {
                    if (ex.GetBaseException() == null)
                    {
                        return Json(new { resultado = new RetornoJSON() { Erro = ex.Message } });
                    }
                    else
                    {
                        return Json(new { resultado = new RetornoJSON() { Erro = ex.GetBaseException().Message } });
                    }
                }

            }
            else
            {
                return Json(new { resultado = TratarRetornoValidacaoToJSON() });
            }
        }




        [HttpPost]
        public ActionResult TerminarComRedirect(string idAlocacao,string idEmpregado)
        {

            try
            {
                Alocacao oAlocacao = AlocacaoBusiness.Consulta.FirstOrDefault(p => p.IDAlocacao.Equals(idAlocacao));
                if (oAlocacao == null)
                {
                    return Json(new { resultado = new RetornoJSON() { Erro = "Não foi possível Desalocar este empregado!" } });
                }
                else
                {
                    oAlocacao.DataExclusao = DateTime.Now;
                    oAlocacao.UsuarioExclusao = "LoginTeste";
                    oAlocacao.Ativado = "false";
                    AlocacaoBusiness.Alterar(oAlocacao);

                    TempData["MensagemSucesso"] = "O Empregado '" + oAlocacao.Admissao.Empregado.Nome + "' foi desalocado com sucesso.";

                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("PerfilEmpregado", "Admissao", new { id = idEmpregado }) } });
                }
            }
            catch (Exception ex)
            {
                if (ex.GetBaseException() == null)
                {
                    return Json(new { resultado = new RetornoJSON() { Erro = ex.Message } });
                }
                else
                {
                    return Json(new { resultado = new RetornoJSON() { Erro = ex.GetBaseException().Message } });
                }
            }


        }






        private string RenderRazorViewToString(string viewName, object model = null)
        {
            ViewData.Model = model;
            using (var sw = new System.IO.StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext,
                                                                         viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View,
                                             ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }

        public RetornoJSON TratarRetornoValidacaoToJSON()
        {


            string msgAlerta = string.Empty;
            foreach (ModelState item in ModelState.Values)
            {
                if (item.Errors.Count > 0)
                {
                    foreach (System.Web.Mvc.ModelError i in item.Errors)
                    {
                        msgAlerta += i.ErrorMessage;
                    }
                }
            }

            return new RetornoJSON()
            {
                Alerta = msgAlerta,
                Erro = string.Empty,
                Sucesso = string.Empty
            };

        }

    }




}
