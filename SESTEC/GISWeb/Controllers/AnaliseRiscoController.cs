using GISCore.Business.Abstract;
using GISModel.DTO.AnaliseRisco;
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
    public class AnaliseRiscoController : Controller
    {
        [Inject]
        public IAtividadesDoEstabelecimentoBusiness AtividadesDoEstabelecimentoBusiness { get; set; }

        [Inject]
        public IAtividadeAlocadaBusiness AtividadeAlocadaBusiness { get; set; }


        [Inject]
        public ITipoDeRiscoBusiness TipoDeRiscoBusiness { get; set; }

        // GET: AtividadeAlocada
        public ActionResult Novo(string id)
        {

            ViewBag.Analise = new SelectList(AtividadesDoEstabelecimentoBusiness.Consulta, "IDAtividadesDoEstabelecimento", "DescricaoDestaAtividade");

            return View();
        }

        //Lista atividade para executar análise de risco.
        //Ao escolher a atividade abrirá outra caixa listando os riscos e o empregado informa se 
        //está apto a executar a atividade.
        public ActionResult PesquisarAtividadesRiscos(string idEstabelecimento, string idAlocacao)
        {
            ViewBag.Imagens = AtividadesDoEstabelecimentoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao) && (p.IDEstabelecimento.Equals(idEstabelecimento))).ToList();
            try
            {


                var ListaAmbientes = from Ambiente in AtividadesDoEstabelecimentoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao) && (p.IDEstabelecimento.Equals(idEstabelecimento))).ToList()
                                     join Aloca in AtividadeAlocadaBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao) && p.idAlocacao.Equals(idAlocacao)).ToList()

                                     on Ambiente.IDAtividadesDoEstabelecimento equals Aloca.idAtividadesDoEstabelecimento
                                     into productGrupo
                                     from item in productGrupo.DefaultIfEmpty()

                                     join TR in TipoDeRiscoBusiness.Consulta.Where(p => string.IsNullOrEmpty(p.UsuarioExclusao)).ToList()
                                     on Ambiente.IDAtividadesDoEstabelecimento equals TR.idAtividadesDoEstabelecimento
                                     into riscoGroup
                                     from iten2 in riscoGroup.DefaultIfEmpty()

                                     select new AnaliseRiscosViewModel
                                     {
                                         DescricaoAtividade = Ambiente.DescricaoDestaAtividade,
                                         //FonteGeradora = Ambiente.FonteGeradora,
                                         NomeDaImagem = Ambiente.NomeDaImagem,
                                         Imagem = Ambiente.Imagem,
                                         AlocaAtividade = (item == null ? false : true),
                                         IDAtividadeEstabelecimento = Ambiente.IDAtividadesDoEstabelecimento,
                                         IDAlocacao = idAlocacao,
                                         idTipoDeRisco = iten2.IDTipoDeRisco

                                     };
            

                List<AnaliseRiscosViewModel> lAtividadesRiscos = ListaAmbientes.ToList();



                AtividadesDoEstabelecimento oIDRiscosDoEstabelecimento = AtividadesDoEstabelecimentoBusiness.Consulta.FirstOrDefault(p => p.IDEstabelecimento.Equals(idEstabelecimento));
                if (oIDRiscosDoEstabelecimento == null)
                {
                    return Json(new { resultado = new RetornoJSON() { Alerta = "Atividades de Riscos não encontrada." } });
                }
                else
                {
                    return Json(new { data = RenderRazorViewToString("_ListaAtividadesDeRiscos", lAtividadesRiscos), Contar = lAtividadesRiscos.Count() });
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
        
        //Esta salvando em AtividadesAlocadas, precisa salvar em analise de riscos
        [HttpPost]
        public ActionResult SalvarAnaliseRisco(bool Acao, string idAtividadeEstabelecimento, string idAlocacao)
        {
            try
            {
                System.Threading.Thread.Sleep(2000);
                if (Acao)
                {
                    //Incluir vinculo entre Atividade do Estabelecimento e Alocação
                    if (idAlocacao.Contains("|"))
                    {
                        foreach (string item in idAlocacao.Split('|'))
                        {
                            if (!string.IsNullOrEmpty(item))
                            {
                                AtividadeAlocadaBusiness.Inserir(new AtividadeAlocada()
                                {
                                    idAlocacao = item,
                                    idAtividadesDoEstabelecimento = idAtividadeEstabelecimento,
                                    //UsuarioInclusao = CustomAuthorizationProvider.UsuarioAutenticado.Usuario.Login
                                });
                            }
                        }
                    }
                    else
                    {
                        AtividadeAlocadaBusiness.Inserir(new AtividadeAlocada()
                        {
                            idAlocacao = idAlocacao,
                            idAtividadesDoEstabelecimento = idAtividadeEstabelecimento,
                            //UsuarioInclusao = CustomAuthorizationProvider.UsuarioAutenticado.Usuario.Login
                        });
                    }
                }
                else
                {
                    //Remover vinculo entre Menu e Perfil
                    if (idAlocacao.Contains("|"))
                    {
                        foreach (string item in idAlocacao.Split('|'))
                        {
                            if (!string.IsNullOrEmpty(item))
                            {
                                AtividadeAlocadaBusiness.Alterar(new AtividadeAlocada()
                                {

                                    idAlocacao = item,
                                    idAtividadesDoEstabelecimento = idAtividadeEstabelecimento,
                                    DataExclusao = DateTime.Now,
                                    //UsuarioExclusao = CustomAuthorizationProvider.UsuarioAutenticado.Usuario.Login
                                });
                            }
                        }
                    }
                    else
                    {

                        AtividadeAlocadaBusiness.Alterar(new AtividadeAlocada()
                        {

                            idAlocacao = idAlocacao,
                            idAtividadesDoEstabelecimento = idAtividadeEstabelecimento,
                            DataExclusao = DateTime.Now,
                            UsuarioExclusao = "LoginTeste"
                            //UsuarioExclusao = CustomAuthorizationProvider.UsuarioAutenticado.Usuario.Login
                        });
                    }
                }

                return Json(new { resultado = new RetornoJSON() { } });
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
