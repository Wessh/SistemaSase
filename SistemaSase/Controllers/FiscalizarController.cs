using Microsoft.Ajax.Utilities;
using SistemaSase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace SistemaSase.Controllers
{
    public class FiscalizarController : Controller
    {
        private readonly SistemaSaseEntities db = new SistemaSaseEntities();
        // GET: Fiscalizar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult fiscalizar()
        {
            CatSeg ct = new CatSeg();
            ViewBag.catseg = ct;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult fiscalizar(
            //bool RampaInterna, bool RampaExterna, bool BanheiroPdePnc,  //Tabela acessibilidade
            //bool Bares, bool CasaFesta, bool Drogas, string Outros,     //Tabela Arredores da Ueb
            //string CatVig, string CatPor, int FkEquipamentos,        //Tabela CatSeg
            //bool Fardamento, bool Apito, bool CapaChuva, bool Colete, bool Tonfa, bool Lanterna, bool Cracha, bool Quepe, bool Revolver, bool Radio,  //EquipamentosSeg
            //bool Estacionamento, bool ControleVeiculos, bool PortaoEletronico, bool EstaRetrito, bool ParaRaios,     //EstFisica
            //bool Parede, bool Teto, bool Calcada, bool Quadra, bool Capina, bool Portas, bool Piso,      //EstReparo
            //string NomeExt, DateTime Validade,       //Extintor
            //string NomeGas, bool Funcionando,        //GasCozinha
            string NomeGestor, string Documento,     //Gestor
            //string Nome,        //Iluminacao
            //bool Fiacao, bool CaixaForca, bool Interruptores, bool Tomadas, bool ArCon, bool Ventilador, bool Geladeira, bool Frezzer, bool Bebedouro,        //IluReparo
            //bool Policia, bool Ronda, bool Guarda, bool Bombeiro, bool Conselho, bool Samu, bool SaseSemed,     //ListaTel
            //bool LivroOcorrecia, bool RegistroDiarios,      //LivroRegistro
            //bool Professores, bool Alunos, bool Gestores, string OutrosCoInternas,       //OcoInternas
            //bool EstFunc,       //OpGas
            //bool Treinamento, bool Sinalizacao,        //PanicoIncendio
            //bool Escola, bool Parceria,        //ProjViolencia
            //bool Banheiros, bool Fossa, bool Cisterna, bool CaixaAgua,       //SisHidraSaniRep
            //bool Certificacao, bool Extintor,      //SisIncendio
            //bool FaixaPedestre, bool Semaforo, bool Agente,     //Transito
            string NomeUeb, string EnderecoUeb, string NucleoUeb, string ContatoUebF, string ContatoUebS,       //UEB
            bool Vigilante//, bool Porteiro, bool VigiFerista, bool PortFerista, bool VigSemedPort, bool VigSemed,        //TipoSeg
           // int PostVigilante, int PostPorteiro, int PostVigia,     //QntPosto
            )
        {
            //Id do usuario logado
            //var identity = User.Identity as ClaimsIdentity;
            //var matUser = identity.Claims.FirstOrDefault(c => c.Type == "Matricula").Value;
            //var idUser = db.tblRegistro.FirstOrDefault(u => u.Matricula == matUser).Id;
            //Importar as tabelas
            tblAcessibilidade tblacessibilidade = new tblAcessibilidade();
            tblArredoresUeb tblarredoresUeb = new tblArredoresUeb();
            tblCatSeg tblcatSeg = new tblCatSeg();
            tblEquipamentosSeg tblequipamentosSeg = new tblEquipamentosSeg();
            tblEstFisica tblestFisica = new tblEstFisica();
            tblEstReparo tblestReparo = new tblEstReparo();
            tblExtintor tblextintor = new tblExtintor();
            tblGasCozinha tblGasCozinha = new tblGasCozinha();
            tblGestor tblGestor = new tblGestor();
            tblIluminacao tblIluminacao = new tblIluminacao();
            tblIluReparo tblIluReparo = new tblIluReparo();
            tblListaTel tblListaTel = new tblListaTel();
            tblLivroRegistro tblLivroRegistro = new tblLivroRegistro();
            tblOcoInternas tblOcoInternas = new tblOcoInternas();
            tblOpGas tblOpGas = new tblOpGas();
            tblPanicoIncendio tblPanicoIncendio = new tblPanicoIncendio();
            tblProjViolencia tblProjViolencia = new tblProjViolencia();
            tblQntPosto tblQntPosto = new tblQntPosto();
            tblRegistro tblRegistro = new tblRegistro();
            tblSisHidraSaniRep tblSisHidraSaniRep = new tblSisHidraSaniRep();
            tblSisIncendio tblSisIncendio = new tblSisIncendio();
            tblTipoSeg tblTipoSeg = new tblTipoSeg();
            tblTransito tblTransito = new tblTransito();
            tblUeb tblUeb = new tblUeb();
            /* - Relacionamentos - 
            Iluminacao_IluReparo Reiluminacao_IluReparo = new Iluminacao_IluReparo();
            Gas_OpcaoGas Regas_OpcaoGas = new Gas_OpcaoGas();
            Incendio_Extintor Reincendio_Extintor = new Incendio_Extintor();*/

            /* - - */

            /**UEB*
            tblUeb.Nome = NomeUeb;
            tblUeb.Endereco = EnderecoUeb;
            tblUeb.Nucleo = NucleoUeb;
            tblGestor.Nome = NomeGestor;
            tblUeb.Contato = ContatoUebF;
            tblUeb.Contato2 = ContatoUebS;
            tblUeb.DataHora = DateTime.Now;
            tblUeb.FKGestor = tblGestor.Id;
            tblUeb.FkRegistro = idUser;*/
            /*- Registro -
            db.tblGestor.Add(tblGestor);
            db.tblUeb.Add(tblUeb);
            db.SaveChanges();*/

            /**Segurança**/

            if(Vigilante)
                tblTipoSeg.Vigilante = false;



            return View();
        }
    }
}