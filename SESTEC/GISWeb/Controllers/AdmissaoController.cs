using GISCore.Business.Abstract;
using GISCore.Business.Concrete;
using GISModel.DTO.Shared;
using GISModel.Entidades;
using GISWeb.Infraestrutura.Filters;
using Ninject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GISWeb.Controllers
{
    public class AdmissaoController : Controller
    {

        #region

        [Inject]
        public IAdmissaoBusiness AdmissaoBusiness { get; set; }

        [Inject]
        public IAtividadesDoEstabelecimentoBusiness AtividadesDoEstabelecimentoBusiness { get; set; }

        [Inject]
        public IDepartamentoBusiness DepartamentoBusiness { get; set; }

        [Inject]
        public IEmpresaBusiness EmpresaBusiness { get; set; }

        [Inject]
        public IEmpregadoBusiness EmpregadoBusiness { get; set; }
        [Inject]
        public IEstabelecimentoAmbienteBusiness EstabelecimentoImagensBusiness { get; set; }

        [Inject]
        public IEstabelecimentoBusiness EstabelecimentoBusiness { get; set; }

        [Inject]
        public IAtividadesDoEstabelecimentoBusiness RiscosDoEstabelecimentoBusiness { get; set; }

        [Inject]
        public IAlocacaoBusiness AlocacaoBusiness { get; set; }

        [Inject]
        public IAtividadeAlocadaBusiness AtividadeAlocadaBusiness { get; set; }

        //[Inject]
        //public IAtividadeBusiness AtividadeDeRiscoBusiness { get; set; }

        #endregion



        // GET: EstabelecimentoImagens
        //public ActionResult Index(string id)
        //{

        //    ViewBag.Imagens = EstabelecimentoImagensBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao) && (p.IDEstabelecimentoImagens.Equals(id))).ToList();
        //    return View();
        //}

        public ActionResult Empresas()
        {

            ViewBag.Empresas = EmpresaBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList();



            return View();

        }

        public ActionResult EmpregadosPorEmpresa(string idEmpresa)
        {

            ViewBag.EmpregadoPorEmpresa = AdmissaoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao) && (p.IDEmpresa.Equals(idEmpresa))).ToList();


            return View();

        }

        //passanda IDEmpregado como parametro para montar o perfil
        public ActionResult PerfilEmpregado(string id)
        {
            ViewBag.Perfil = AdmissaoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao) && (p.IDEmpregado.Equals(id))).ToList();
            ViewBag.Admissao = AdmissaoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao) && (p.IDEmpregado.Equals(id))&&(p.Admitido=="Admitido")).ToList();
            ViewBag.Alocacao = AlocacaoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao) && (p.Admissao.IDEmpregado.Equals(id)) && (p.Ativado == "true")).ToList();


            Admissao oAdmissao = AdmissaoBusiness.Consulta.FirstOrDefault(p => p.IDEmpregado.Equals(id));


            List<AtividadeAlocada> ListaAtividades = (from ATL in AtividadeAlocadaBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
                                                      join ATV in AtividadesDoEstabelecimentoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
                                                      on ATL.idAtividadesDoEstabelecimento equals ATV.IDAtividadesDoEstabelecimento
                                                        join Est in EstabelecimentoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
                                                        on ATV.IDEstabelecimento equals Est.IDEstabelecimento
                                                        join ALOC in AlocacaoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
                                                        on Est.IDEstabelecimento equals ALOC.idEstabelecimento
                                                        where ALOC.Admissao.IDEmpregado.Equals(id)
                                                        select new AtividadeAlocada()
                                                        {
                                                            idAlocacao = ATL.idAlocacao,
                                                            idAtividadesDoEstabelecimento = ATL.idAtividadesDoEstabelecimento,
                                                            IDAtividadeAlocada = ATL.IDAtividadeAlocada,
                                                            AtividadesDoEstabelecimento = new AtividadesDoEstabelecimento()
                                                            {
                                                                DescricaoDestaAtividade = ATV.DescricaoDestaAtividade,

                                                                Estabelecimento = new Estabelecimento()
                                                                {
                                                                    IDEstabelecimento = Est.IDEstabelecimento,
                                                                    Descricao = Est.Descricao
                                                                }
                                                            }
                                                                  
                                                                     
                                                        }
                                                        ).ToList();
            ViewBag.ListaAtividade = ListaAtividades;
            

            //ViewBag.Alocaçao = AlocacaoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao) && (p.Admissao.IDEmpregado.Equals(id)) && (p.Ativado == "Ativado")).ToList();


            return View(oAdmissao);
        }

        //Assim que o empregado for demitido, retorne esta visão
        public ActionResult EmpregadoDemitido(string id)
        {
           
            ViewBag.Demitir = AdmissaoBusiness.Consulta.Where((p=>p.IDAdmissao.Equals(id))).ToList();
            

            return View();
        }



        public ActionResult EmpregadoAdmitidoDetalhes(string id)
        {
            ViewBag.empregado = EmpregadoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao) && (p.IDEmpregado.Equals(id))).ToList();
            try
            {
                Admissao oAdmissao = AdmissaoBusiness.Consulta.FirstOrDefault(p => p.IDEmpregado.Equals(id));
                if (oAdmissao == null)
                {
                    return Json(new { resultado = new RetornoJSON() { Alerta = "Empregado com CPF '" +id+ "' não encontrado." } });
                }
                else
                {
                    return Json(new { data = RenderRazorViewToString("_Detalhes", oAdmissao) });
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


        //public ActionResult BuscarDetalhesDosRiscos(string idEstabelecimento)
        //{
        //    ViewBag.Imagens = RiscosDoEstabelecimentoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao) && (p.IDEstabelecimentoImagens.Equals(idEstabelecimento))).ToList();
        //    try
        //    {
        //        AtividadesDoEstabelecimento oRiscosDoEstabelecimento = RiscosDoEstabelecimentoBusiness.Consulta.FirstOrDefault(p => p.IDEstabelecimentoImagens.Equals(idEstabelecimento));
        //        if (oRiscosDoEstabelecimento == null)
        //        {
        //            return Json(new { resultado = new RetornoJSON() { Alerta = "Imagens4 não encontrada." } });
        //        }
        //        else
        //        {
        //            return Json(new { data = RenderRazorViewToString("_Detalhes", oRiscosDoEstabelecimento) });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.GetBaseException() == null)
        //        {
        //            return Json(new { resultado = new RetornoJSON() { Erro = ex.Message } });
        //        }
        //        else
        //        {
        //            return Json(new { resultado = new RetornoJSON() { Erro = ex.GetBaseException().Message } });
        //        }
        //    }

        //}

        //public ActionResult BuscarDetalhesEstabelecimentoImagens(string IDEstabelecimento)
        //{
        //    ViewBag.Imagens = EstabelecimentoImagensBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao) && (p.IDEstabelecimento.Equals(IDEstabelecimento))).ToList();
        //    try
        //    {
        //        EstabelecimentoAmbientes oEstabelecimentoImagens = EstabelecimentoImagensBusiness.Consulta.FirstOrDefault(p => p.IDEstabelecimento.Equals(IDEstabelecimento));
        //        if (oEstabelecimentoImagens == null)
        //        {
        //            return Json(new { resultado = new RetornoJSON() { Alerta = "Imagens3 não encontrada." } });
        //        }
        //        else
        //        {
        //            return Json(new { data = RenderRazorViewToString("_Detalhes", oEstabelecimentoImagens) });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.GetBaseException() == null)
        //        {
        //            return Json(new { resultado = new RetornoJSON() { Erro = ex.Message } });
        //        }
        //        else
        //        {
        //            return Json(new { resultado = new RetornoJSON() { Erro = ex.GetBaseException().Message } });
        //        }
        //    }

        //}

        public ActionResult Novo(string id)
        {
            //id do Estabelecimento recebido por parametro
            ViewBag.EmpID = id;
            ViewBag.Sigla = new SelectList(DepartamentoBusiness.Consulta.ToList(), "IDDepartamento", "Sigla");
            ViewBag.Empresas = new SelectList(EmpresaBusiness.Consulta.ToList(), "IDEmpresa", "NomeFantasia");
            ViewBag.Admissao = AdmissaoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao) && (p.IDEmpregado.Equals(id))).ToList();
            ViewBag.Empregado = EmpregadoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao) && (p.IDEmpregado.Equals(id))).ToList();
            //ViewBag.RegistroID = new SelectList(EstabelecimentoImagensBusiness.Consulta, "RegistroID", "Diretoria");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Admissao oAdmissao, string EmpID)
        {

            //id do Estabelecimento recebido por parametro
            oAdmissao.IDEmpregado = EmpID;
            

            if (ModelState.IsValid)
            {
                try
                {

                    AdmissaoBusiness.Inserir(oAdmissao);

                    TempData["MensagemSucesso"] = "O empregado foi admitido com sucesso.";

                    //var iAdmin = oAdmissao.IDAdmissao;

                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("PerfilEmpregado", "Admissao", new { id = EmpID }) } });
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
            return View(EstabelecimentoImagensBusiness.Consulta.FirstOrDefault(p => p.IDEstabelecimentoImagens.Equals(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Atualizar(EstabelecimentoAmbiente oEstabelecimentoImagens)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    EstabelecimentoImagensBusiness.Alterar(oEstabelecimentoImagens);

                    TempData["MensagemSucesso"] = "A imagem '" + oEstabelecimentoImagens.NomeDaImagem + "' foi atualizada com sucesso.";

                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("Index", "EstabelecimentoImagens") } });
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
        public ActionResult Terminar(string IDAdmissao)
        {

            try
            {
                Admissao oAdmissao = AdmissaoBusiness.Consulta.FirstOrDefault(p => p.IDAdmissao.Equals(IDAdmissao));
                if (oAdmissao == null)
                {
                    return Json(new { resultado = new RetornoJSON() { Erro = "Não foi possível excluir esta Admissão." } });
                }
                else
                {

                    oAdmissao.DataExclusao = DateTime.Now;
                    oAdmissao.UsuarioExclusao = "LoginTeste";
                    oAdmissao.Admitido = "Demitido";
                    AdmissaoBusiness.Alterar(oAdmissao);

                    return Json(new { resultado = new RetornoJSON() { Sucesso = "O Empregado '" + oAdmissao.Empregado.Nome + "' foi demitido com sucesso." } });
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
        public ActionResult TerminarComRedirect(string IDAdmissao)
        {

            try
            {
                Admissao oAdmissao = AdmissaoBusiness.Consulta.FirstOrDefault(p => p.IDAdmissao.Equals(IDAdmissao));
                if (oAdmissao == null)
                {
                    return Json(new { resultado = new RetornoJSON() { Erro = "Não foi possível excluir esta Admissão." } });
                }
                else
                {
                    oAdmissao.DataExclusao = DateTime.Now;
                    oAdmissao.UsuarioExclusao = "LoginTeste";
                    oAdmissao.Admitido = "Demitido";
                    AdmissaoBusiness.Alterar(oAdmissao);

                    TempData["MensagemSucesso"] = "O Empregado '" + oAdmissao.Empregado.Nome + "' foi demitido com sucesso.";

                    return Json(new { resultado = new RetornoJSON() { URL = Url.Action("EmpregadoDemitido", "Admissao", new { id = IDAdmissao }) } });
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

        [RestritoAAjax]
        public ActionResult _Upload()
        {
            try
            {
                return PartialView("_Upload");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Content(ex.Message, "text/html");
            }
        }




        [HttpPost]
        [RestritoAAjax]
        [ValidateAntiForgeryToken]
        public ActionResult Upload()
        {
            try
            {
                string fName = string.Empty;
                string msgErro = string.Empty;
                foreach (string fileName in Request.Files.AllKeys)
                {
                    HttpPostedFileBase oFile = Request.Files[fileName];
                    fName = oFile.FileName;
                    if (oFile != null)
                    {
                        string sExtensao = oFile.FileName.Substring(oFile.FileName.LastIndexOf("."));
                        if (sExtensao.ToUpper().Contains("PNG") || sExtensao.ToUpper().Contains("JPG") || sExtensao.ToUpper().Contains("JPEG") || sExtensao.ToUpper().Contains("GIF"))
                        {
                            //Após a autenticação está totalmente concluída, mudar para incluir uma pasta com o Login do usuário
                            string sLocalFile = Path.Combine(Path.GetTempPath(), "GIS");
                            sLocalFile = Path.Combine(sLocalFile, DateTime.Now.ToString("yyyyMMdd"));
                            sLocalFile = Path.Combine(sLocalFile, "Estabelecimento");
                            sLocalFile = Path.Combine(sLocalFile, "LoginTeste");

                            if (!System.IO.Directory.Exists(sLocalFile))
                                Directory.CreateDirectory(sLocalFile);
                            else
                            {
                                //Tratamento de limpar arquivos da pasta, pois o usuário pode estar apenas alterando o arquivo.
                                //Limpar para não ficar lixo.
                                //O arquivo que for salvo abaixo será limpado após o cadastro.
                                //Se o usuário cancelar o cadastro, a rotina de limpar diretórios ficará responsável por limpá-lo.
                                foreach (string iFile in System.IO.Directory.GetFiles(sLocalFile))
                                {
                                    System.IO.File.Delete(iFile);
                                }
                            }

                            sLocalFile = Path.Combine(sLocalFile, oFile.FileName);

                            oFile.SaveAs(sLocalFile);

                        }
                        else
                        {
                            throw new Exception("Extensão do arquivo não permitida.");
                        }

                    }
                }
                if (string.IsNullOrEmpty(msgErro))
                    return Json(new { sucesso = "O upload do arquivo '" + fName + "' foi realizado com êxito.", arquivo = fName, erro = msgErro });
                else
                    return Json(new { erro = msgErro });
            }
            catch (Exception ex)
            {
                return Json(new { erro = ex.Message });
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
