using GISCore.Business.Abstract;
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
    
    public class TipoDeRiscoController : Controller
    {
        
        #region Inject

        [Inject]
        public ITipoDeRiscoBusiness TipoDeRiscoBusiness { get; set; }

        [Inject]
        public IEventoPerigosoBusiness EventoPerigosoBusiness { get; set; }


        [Inject]
        public IPossiveisDanosBusiness PossiveisDanosBusiness { get; set; }

        //[Inject]
        //public IAtividadeRiscosBusiness AtividadeRiscosBusiness { get; set; }

        //[Inject]
        //public IMedidaControleRiscoFuncaoBusiness MedidaControleRiscoFuncaoBusiness { get; set; }

        #endregion
        // GET: TipoDeRisco
        public ActionResult Index()
        {
            ViewBag.Riscos = TipoDeRiscoBusiness.Consulta.Where(d=>string.IsNullOrEmpty(d.UsuarioExclusao)).ToList();

            return View();
        }


        //public ActionResult BuscarDetalhesDaAtividadeRisco(string idTipoDeRisco)
        //{

        //    List<MedidasControleRiscoFuncao> MedidaControle = (from a in MedidaControleRiscoFuncaoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
        //                          join b in AtividadeRiscosBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
        //                          on a.IDAtividadeRiscos equals b.IDAtividadeRiscos
        //                          join c in TipoDeRiscoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
        //                          on b.IdTipoDeRisco equals c.IDTipoDeRisco
        //                          join d in EventoPerigosoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
        //                          on c.idEventoPerigoso equals d.IDEventoPerigoso
        //                          join e in PossiveisDanosBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
        //                          on c.idPossiveisDanos equals e.IDPossiveisDanos
        //                          join f in EventoPerigosoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
        //                          on c.idEventoPerigoso equals f.IDEventoPerigoso
        //                          where c.IDTipoDeRisco.Equals(idTipoDeRisco)
        //                          //group c by c.IDTipoDeRisco into g
        //                          select new MedidasControleRiscoFuncao()
        //                          {
        //                              IDMedidasDeControleRiscoFuncao = a.IDMedidasDeControleRiscoFuncao,
        //                              ControleExistentes = a.ControleExistentes,
        //                              EClassificacaoDaMedida = a.EClassificacaoDaMedida,
        //                              NomeDaImagem = a.NomeDaImagem,
        //                              Imagem = a.Imagem,

        //                              AtividadeRiscos = new AtividadeRiscos()
        //                              {
        //                                  IdTipoDeRisco =b.IdTipoDeRisco,
                                          

        //                                  TipoDeRisco = new TipoDeRisco()
        //                                  {
        //                                      IDTipoDeRisco = c.IDTipoDeRisco,
        //                                      DescricaoDoRisco = c.DescricaoDoRisco,

        //                                      EventoPerigoso = new EventoPerigoso()
        //                                      {
        //                                          IDEventoPerigoso =f.IDEventoPerigoso,
        //                                          Descricao = f.Descricao
        //                                      },
        //                                      PossiveisDanos = new PossiveisDanos()
        //                                      {
        //                                          IDPossiveisDanos =e.IDPossiveisDanos,
        //                                          DescricaoDanos = e.DescricaoDanos
        //                                      }

        //                                  }

        //                              }



                                      
        //                          }


        //         ).ToList();

            
        //    ViewBag.TipoDeRisco = MedidaControle;

            

            //try
            //{
            //    TipoDeRisco oIDTipoDeRisco = TipoDeRiscoBusiness.Consulta.FirstOrDefault(p => p.IDTipoDeRisco.Equals(idTipoDeRisco));
            //    if (oIDTipoDeRisco == null)
            //    {
            //        return Json(new { resultado = new RetornoJSON() { Alerta = "Imagens não encontrada." } });
            //    }
            //    else
            //    {
            //        return Json(new { data = RenderRazorViewToString("_Detalhes", oIDTipoDeRisco) });
            //    }
            //}
            //catch (Exception ex)
            //{
            //    if (ex.GetBaseException() == null)
            //    {
            //        return Json(new { resultado = new RetornoJSON() { Erro = ex.Message } });
            //    }
            //    else
            //    {
            //        return Json(new { resultado = new RetornoJSON() { Erro = ex.GetBaseException().Message } });
            //    }
            //}





       // }
        



        public ActionResult Novo()
        {
            ViewBag.EventoPerigoso = new SelectList(EventoPerigosoBusiness.Consulta.ToList(), "IDEventoPerigoso", "Descricao");
            ViewBag.PossiveisDanos = new SelectList(PossiveisDanosBusiness.Consulta.ToList(), "IDPossiveisDanos", "DescricaoDanos");
            
            return View();
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(TipoDeRisco oTipoDeRisco)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    TipoDeRiscoBusiness.Inserir(oTipoDeRisco);

                    TempData["MensagemSucesso"] = "O Risco '" + oTipoDeRisco.DescricaoDoRisco + "' foi cadastrado com sucesso!";

                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("Index", "TipoDeRisco") } });

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

            return View(TipoDeRiscoBusiness.Consulta.FirstOrDefault(p => p.IDTipoDeRisco.Equals(id)));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Atualizar(TipoDeRisco oTipoDeRisco)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TipoDeRiscoBusiness.Alterar(oTipoDeRisco);

                    TempData["MensagemSucesso"] = "O Tipo de Risco '"+ oTipoDeRisco.DescricaoDoRisco +"' foi atualizado com sucesso.";

                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("Index", "TipoDeRisco") } });
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



        public ActionResult Excluir(string id)
        {
            ViewBag.Riscos = new SelectList(TipoDeRiscoBusiness.Consulta.ToList(), "IDTipoDeRisco", "DescricaoDoRisco");
            return View(TipoDeRiscoBusiness.Consulta.FirstOrDefault(p => p.IDTipoDeRisco.Equals(id)));

        }



        [HttpPost]
        public ActionResult Terminar(string IDTipodeRisco)
        {

            try
            {
                TipoDeRisco oTipoDeRisco = TipoDeRiscoBusiness.Consulta.FirstOrDefault(p => p.IDTipoDeRisco.Equals(IDTipodeRisco));
                if (oTipoDeRisco == null)
                {
                    return Json(new { resultado = new RetornoJSON() { Erro = "Não foi possível excluir o Risco, pois o mesmo não foi localizado." } });
                }
                else
                {

                    oTipoDeRisco.DataExclusao = DateTime.Now;
                    oTipoDeRisco.UsuarioExclusao = "LoginTeste";
                    TipoDeRiscoBusiness.Alterar(oTipoDeRisco);

                    return Json(new { resultado = new RetornoJSON() { Sucesso = "O risco '" + oTipoDeRisco.DescricaoDoRisco + "' foi excluído com sucesso." } });
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
