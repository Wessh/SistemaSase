using SistemaSase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaSase.Controllers
{
    public class FiscalizarController : Controller
    {
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
        public ActionResult fiscalizar(
            bool RampaInterna, bool RampaExterna, bool BanheiroPdePnc,  //Tabela acessibilidade
            bool Bares, bool CasaFesta, bool Drogas, string Outros,     //Tabela Arredores da Ueb
            String NomeCat, int FkEquipamentos,        //Tabela CatSeg
            bool Fardamento, bool Apito, bool CapaChuva, bool Colete, bool Tonfa, bool Lanterna, bool Cracha, bool Quepe, bool Revolver, bool Radio,  //EquipamentosSeg
            bool Estacionamento, bool ControleVeiculos, bool PortaoEletronico, bool EstaRetrito, bool ParaRaios,     //EstFisica
            bool Parede, bool Teto, bool Calcada, bool Quadra, bool Capina, bool Portas, bool Piso,      //EstReparo
            string NomeExt, DateTime Validade,       //Extintor
            string NomeGas, bool Funcionando,        //GasCozinha
            string NomeGestor, string Documento,     //Gestor
            string Nome,        //Iluminacao
            bool Fiacao, bool CaixaForca, bool Interruptores, bool Tomadas, bool ArCon, bool Ventilador, bool Geladeira, bool Frezzer, bool Bebedouro,        //IluReparo
            bool Policia, bool Ronda, bool Guarda, bool Bombeiro, bool Conselho, bool Samu, bool SaseSemed,     //ListaTel
            bool LivroOcorrecia, bool RegistroDiarios,      //LivroRegistro
            bool Professores, bool Alunos, bool Gestores, string OutrosCoInternas,       //OcoInternas
            bool EstFunc,       //OpGas
            bool Treinamento, bool Sinalizacao,        //PanicoIncendio
            bool Escola, bool Parceria,        //ProjViolencia
            bool Banheiros, bool Fossa, bool Cisterna, bool CaixaAgua,       //SisHidraSaniRep
            bool Certificacao, bool Extintor,      //SisIncendio
            bool FaixaPedestre, bool Semaforo, bool Agente,     //Transito
            string NomeUeb, string EnderecoUeb, string NucleoUeb, int FKGestor, string Contato, string Contato2, DateTime DataHora, int FkRegistro,       //UEB
            bool Vigilante, bool Porteiro, bool VigiFeirista, bool PortFeirista, bool VigSemedPort, bool VigSemed,        //TipoSeg
            int PostVigilante, int PostPorteiro, int PostVigia,     //QntPosto
            /* - Relacionamentos - */
            int IdGas, int IdOpGas,     //ReGas_Op
            int IdIluminacao, int IdIluReparo,      //ReIluminacao_IluReparo
            int IdIncendio, int IdExtintor      //ReIncendio_Extintor
            )
        {
            //Importar as tabelas
            return View();
        }
    }
}