﻿using GISCore.Business.Abstract;
using GISCore.Business.Concrete;
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
    public class DiretoriaController : Controller
    {
        #region Inject
        [Inject]
        public IDiretoriaBusiness DiretoriaBusiness { get; set; }

        [Inject]
        public ITipoDeRiscoBusiness TipoDeRiscoBusiness { get; set; }

        [Inject]
        public ICargoBusiness CargoBusiness { get; set; }

        [Inject]
        public IEmpresaBusiness EmpresaBusiness { get; set; }

        #endregion
        // GET: TipoDeRisco
        public ActionResult Index()
        {
            ViewBag.Diretoria = DiretoriaBusiness.Consulta.Where(d => string.IsNullOrEmpty(d.UsuarioExclusao)).Distinct().ToList();

            return View();
        }


        public ActionResult Novo()
        {

            ViewBag.Empresa = new SelectList(EmpresaBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList(), "IDEmpresa", "NomeFantasia");


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Diretoria oDiretoria)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    DiretoriaBusiness.Inserir(oDiretoria);

                    TempData["MensagemSucesso"] = "A Diretoria'" + oDiretoria.Sigla + "' foi cadastrada com sucesso!";

                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("Index", "Diretoria", new { id = oDiretoria.IDDiretoria })}});

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


        public ActionResult Edicao(string id)
        {
            //ViewBag.Riscos = TipoDeRiscoBusiness.Consulta.Where(p => p.IDTipoDeRisco.Equals(id));

            return View(DiretoriaBusiness.Consulta.FirstOrDefault(p => p.IDDiretoria.Equals(id)));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Atualizar(Diretoria oDiretoria)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DiretoriaBusiness.Alterar(oDiretoria);

                    TempData["MensagemSucesso"] = "A Diretoria '" + oDiretoria.Sigla + "' foi atualizada com sucesso.";

                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("Index", "Diretoria") } });
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
        public ActionResult TerminarComRedirect(string IDDiretoria)
        {

            try
            {
                Diretoria oDiretoria = DiretoriaBusiness.Consulta.FirstOrDefault(p => p.IDDiretoria.Equals(IDDiretoria));
                if (oDiretoria == null)
                {
                    return Json(new { resultado = new RetornoJSON() { Erro = "Não foi possível excluir esta Diretoria." } });
                }
                else
                {
                    oDiretoria.DataExclusao = DateTime.Now;
                    oDiretoria.UsuarioExclusao = "LoginTeste";                    
                    DiretoriaBusiness.Alterar(oDiretoria);

                    TempData["MensagemSucesso"] = "A Diretoria '" + oDiretoria.Sigla + "' foi excluida com sucesso.";

                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("Index", "Diretoria", new { id = IDDiretoria }) } });
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









        public RetornoJSON TratarRetornoValidacaoToJSON()
        {

            string msgAlerta = string.Empty;
            foreach (ModelState item in ModelState.Values)
            {
                if (item.Errors.Count > 0)
                {
                    foreach (System.Web.Mvc.ModelError i in item.Errors)
                    {
                        if (!string.IsNullOrEmpty(i.ErrorMessage))
                            msgAlerta += i.ErrorMessage;
                        else
                            msgAlerta += i.Exception.Message;
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