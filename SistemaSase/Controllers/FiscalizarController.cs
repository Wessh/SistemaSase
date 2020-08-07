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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult fiscalizar(
            bool RampaInterna, bool RampaExterna, bool BanheiroPdePnc,  //Tabela acessibilidade
            bool Bares, bool CasaFesta, bool Drogas, string Outros,     //Tabela Arredores da Ueb
            bool CatVig, bool CatPor,        //Tabela CatSeg
            bool Fardamento, bool Apito, bool CapaChuva, bool Colete, bool Tonfa, bool Lanterna, bool Cracha, bool Quepe, bool Revolver, bool Radio,  //EquipamentosSeg
            bool FardamentoP, bool ApitoP, bool CapaChuvaP, bool ColeteP, bool TonfaP, bool LanternaP, bool CrachaP, bool QuepeP, bool RevolverP, bool RadioP,  //EquipamentosSeg
            bool Estacionamento, bool ControleVeiculos, bool PortaoEletronico, bool EstaRetrito, bool ParaRaios,     //EstFisica
            bool Parede, bool Teto, bool Calcada, bool Quadra, bool Capina, bool Portas, bool Piso,      //EstReparo
            bool Certificacao, bool Extintor, bool PQS, bool CO2, bool Agua, DateTime ValPqs, DateTime ValCo2, DateTime ValAgua,      //SisIncendio
            bool domestico, bool industrial, bool FuncionandoI, bool FuncionandoD,       //GasCozinha
            string NomeGestor, string Documento,     //Gestor
            bool IntLu, bool ExtLu,        //Iluminacao
            bool Fiacao, bool CaixaForca, bool Interruptores, bool Tomadas, bool ArCon, bool Ventilador, bool Geladeira, bool Frezzer, bool Bebedouro,        //IluReparo
            bool FiacaoE, bool CaixaForcaE, bool InterruptoresE, bool TomadasE, bool ArConE, bool VentiladorE, bool GeladeiraE, bool FrezzerE, bool BebedouroE,        //IluReparoExterna
            bool LivroOcorrecia, bool RegistroDiarios,      //LivroRegistro
            bool Professores, bool Alunos, bool Gestores, string OutrosCoInternas,       //OcoInternas
            bool Treinamento, bool Sinalizacao,        //PanicoIncendio
            bool Escola, bool Parceria,        //ProjViolencia
            bool Banheiros, bool Fossa, bool Cisterna, bool CaixaAgua,       //SisHidraSaniRep
            bool FaixaPedestre, bool Semaforo, bool Agente,     //Transito
            string NomeUeb, string EnderecoUeb, string NucleoUeb, string ContatoUebF, string ContatoUebS,       //UEB
            bool Vigilante, bool Porteiro, bool VigiFerista, bool PortFerista, bool VigSemedPort, bool VigSemed,        //TipoSeg
            bool Policia, bool Ronda, bool Guarda, bool Bombeiro, bool Conselho, bool Samu, bool SaseSemed,         //ListaTele
            int PostVigilante, int PostPorteiro, int PostVigia     //QntPosto
            )
        {
            //Id do usuario logado
            var identity = User.Identity as ClaimsIdentity;
            var matUser = identity.Claims.FirstOrDefault(c => c.Type == "Matricula").Value;
            var idUser = db.tblRegistro.FirstOrDefault(u => u.Matricula == matUser).Id;

            //Importar as tabelas
            tblAcessibilidade tblacessibilidade = new tblAcessibilidade();
            tblArredoresUeb tblarredoresUeb = new tblArredoresUeb();
            tblEquipamentosSeg tblequipamentosSeg = new tblEquipamentosSeg();
            tblEstFisica tblestFisica = new tblEstFisica();
            tblEstReparo tblestReparo = new tblEstReparo();
            tblExtintor tblextintor = new tblExtintor();
            tblGasUeb tblGasUeb = new tblGasUeb();
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
            tblFiscalizacao tblfiscalizacao = new tblFiscalizacao();
            FiscCaEq relfiscCaEq = new FiscCaEq();
            Iluminacao_IluReparo relIluRep = new Iluminacao_IluReparo();

            /* - Relacionamentos - */
            Iluminacao_IluReparo Reiluminacao_IluReparo = new Iluminacao_IluReparo();
            Gas_OpcaoGas Regas_OpcaoGas = new Gas_OpcaoGas();
            Incendio_Extintor Reincendio_Extintor = new Incendio_Extintor();

            /* - - */

            /**UEB**/
            tblUeb.Nome = NomeUeb;
            tblUeb.Endereco = EnderecoUeb;
            tblUeb.Nucleo = NucleoUeb;
            tblGestor.Nome = NomeGestor;
            tblUeb.Contato = ContatoUebF;
            tblUeb.Contato2 = ContatoUebS;
            tblUeb.DataHora = DateTime.Now;
            tblUeb.FKGestor = tblGestor.Id;
            tblUeb.FkRegistro = idUser;
            /*- Registro -*/
            db.tblGestor.Add(tblGestor);
            db.tblUeb.Add(tblUeb);
            db.SaveChanges();

            /**Segurança**/
            tblTipoSeg.Vigilante = Vigilante;
            tblTipoSeg.Porteiro = Porteiro;
            tblTipoSeg.VigiFeirista = VigiFerista;
            tblTipoSeg.PortFeirista = PortFerista;
            tblTipoSeg.VigSemedPort = VigSemedPort;
            tblTipoSeg.VigSemed = VigSemed;
            //Salvar
            db.tblTipoSeg.Add(tblTipoSeg);
            db.SaveChanges();

            /** QNT Postos na UEB **/
            tblQntPosto.PostVigilante = PostVigilante;
            tblQntPosto.PostPorteiro = PostPorteiro;
            tblQntPosto.PostVigia = PostVigia;
            db.tblQntPosto.Add(tblQntPosto);
            db.SaveChanges();

            /** Livro de registro **/
            tblLivroRegistro.LivroOcorrecia = LivroOcorrecia;
            tblLivroRegistro.RegistroDiarios = RegistroDiarios;
            db.tblLivroRegistro.Add(tblLivroRegistro);
            db.SaveChanges();


            /** Cadastro tabela Estrutura fisica **/
            tblestFisica.Estacionamento = Estacionamento;
            tblestFisica.ControleVeiculos = ControleVeiculos;
            tblestFisica.PortaoEletronico = PortaoEletronico;
            tblestFisica.EstaRetrito = EstaRetrito;
            tblestFisica.ParaRaios = ParaRaios;
            db.tblEstFisica.Add(tblestFisica);
            db.SaveChanges();

            /** Cadastro Reparo Estrutura fisica **/
            tblestReparo.Parede = Parede;
            tblestReparo.Teto = Teto;
            tblestReparo.Calcada = Calcada;
            tblestReparo.Quadra = Quadra;
            tblestReparo.Capina = Capina;
            tblestReparo.Portas = Portas;
            tblestReparo.Piso = Piso;
            db.tblEstReparo.Add(tblestReparo);
            db.SaveChanges();

            /** Iluminação **/
            if (IntLu)
            {
                tblIluReparo.Fiacao = Fiacao;
                tblIluReparo.CaixaForca = CaixaForca;
                tblIluReparo.Interruptores = Interruptores;
                tblIluReparo.Tomadas = Tomadas;
                tblIluReparo.ArCon = ArCon;
                tblIluReparo.Ventilador = Ventilador;
                tblIluReparo.Geladeira = Geladeira;
                tblIluReparo.Frezzer = Frezzer;
                tblIluReparo.Bebedouro = Bebedouro;
                tblIluReparo.Nome = "interna";
                db.tblIluReparo.Add(tblIluReparo);
                db.SaveChanges();
            }
            if (ExtLu)
            {
                tblIluReparo.Fiacao = FiacaoE;
                tblIluReparo.CaixaForca = CaixaForcaE;
                tblIluReparo.Interruptores = InterruptoresE;
                tblIluReparo.Tomadas = TomadasE;
                tblIluReparo.ArCon = ArConE;
                tblIluReparo.Ventilador = VentiladorE;
                tblIluReparo.Geladeira = GeladeiraE;
                tblIluReparo.Frezzer = FrezzerE;
                tblIluReparo.Bebedouro = BebedouroE;
                tblIluReparo.Nome = "externa";
                db.tblIluReparo.Add(tblIluReparo);
                db.SaveChanges();
            }

            /** Sistema hidraulico sanitario **/
            tblSisHidraSaniRep.Banheiros = Banheiros;
            tblSisHidraSaniRep.Fossa = Fossa;
            tblSisHidraSaniRep.Cisterna = Cisterna;
            tblSisHidraSaniRep.CaixaAgua = CaixaAgua;
            db.tblSisHidraSaniRep.Add(tblSisHidraSaniRep);
            db.SaveChanges();

            /** Sistema de combate a incendio **/
            tblSisIncendio.Certificacao = Certificacao;
            tblSisIncendio.Extintor = Extintor;
            db.tblSisIncendio.Add(tblSisIncendio);
            db.SaveChanges();

            if (Extintor)
            {
                if (PQS)
                {
                    tblextintor.Nome = "PQS";
                    tblextintor.Validade = ValPqs;
                    db.tblExtintor.Add(tblextintor);
                    db.SaveChanges();
                }
                if (CO2)
                {
                    tblextintor.Nome = "CO2";
                    tblextintor.Validade = ValCo2;
                    db.tblExtintor.Add(tblextintor);
                    db.SaveChanges();
                }
                if (Agua)
                {
                    tblextintor.Nome = "Agua";
                    tblextintor.Validade = ValAgua;
                    db.tblExtintor.Add(tblextintor);
                    db.SaveChanges();
                }
            }


            /** Tipo Gás **/
            if (domestico)
            {
                tblGasUeb.Nome = "Doméstico";
                tblGasUeb.Funcionando = FuncionandoD;
                db.tblGasUeb.Add(tblGasUeb);
                db.SaveChanges();
            }
            if (industrial)
            {
                tblGasUeb.Nome = "Industrial";
                tblGasUeb.Funcionando = FuncionandoI;
                db.tblGasUeb.Add(tblGasUeb);
                db.SaveChanges();
            }


            /** PrevencaoIncendio **/
            tblPanicoIncendio.Treinamento = Treinamento;
            tblPanicoIncendio.Sinalizacao = Sinalizacao;
            db.tblPanicoIncendio.Add(tblPanicoIncendio);
            db.SaveChanges();


            /** Transito **/
            tblTransito.FaixaPedestre = FaixaPedestre;
            tblTransito.Semaforo = Semaforo;
            tblTransito.Agente = Agente;
            db.tblTransito.Add(tblTransito);
            db.SaveChanges();

            /** Acessibilidade **/
            tblacessibilidade.RampaInterna = RampaInterna;
            tblacessibilidade.RampaExterna = RampaExterna;
            tblacessibilidade.BanheiroPdePnc = BanheiroPdePnc;
            db.tblAcessibilidade.Add(tblacessibilidade);
            db.SaveChanges();


            /** ArredoresUEB **/
            tblarredoresUeb.Bares = Bares;
            tblarredoresUeb.CasaFesta = CasaFesta;
            tblarredoresUeb.Drogas = Drogas;
            db.tblArredoresUeb.Add(tblarredoresUeb);
            db.SaveChanges();

            /** Projeto contra violencia **/
            tblProjViolencia.Escola = Escola;
            tblProjViolencia.Parceria = Parceria;
            db.tblProjViolencia.Add(tblProjViolencia);
            db.SaveChanges();

            /** Ocorrencias Internas **/
            tblOcoInternas.Professores = Professores;
            tblOcoInternas.Alunos = Alunos;
            tblOcoInternas.Gestores = Gestores;
            db.tblOcoInternas.Add(tblOcoInternas);
            db.SaveChanges();

            /** Lista telefonica **/
            tblListaTel.Policia = Policia;
            tblListaTel.Ronda = Ronda;
            tblListaTel.Guarda = Guarda;
            tblListaTel.Bombeiro = Bombeiro;
            tblListaTel.Conselho = Conselho;
            tblListaTel.Samu = Samu;
            tblListaTel.SaseSemed = SaseSemed;
            db.tblListaTel.Add(tblListaTel);
            db.SaveChanges();

            /** Fiscalização **/
            tblfiscalizacao.FkAcessibilidade = tblacessibilidade.Id;
            tblfiscalizacao.FkArredoresUeb = tblarredoresUeb.Id;
            tblfiscalizacao.FkEstruturaFisica = tblestFisica.Id;
            tblfiscalizacao.FkEstruturaReparo = tblestReparo.Id;
            tblfiscalizacao.FkGasUeb = tblGasUeb.Id;
            tblfiscalizacao.FkIluminacaoReparo = tblIluReparo.Id;
            tblfiscalizacao.FkListaTelefone = tblListaTel.Id;
            tblfiscalizacao.FkLivroRegistro = tblLivroRegistro.Id;
            tblfiscalizacao.FkOcorrenciaInterna = tblOcoInternas.id;
            tblfiscalizacao.FkPanicoIncendio = tblPanicoIncendio.Id;
            tblfiscalizacao.FkProjetoViolencia = tblProjViolencia.Id;
            tblfiscalizacao.FkQntPosto = tblQntPosto.Id;
            tblfiscalizacao.FkRegistro = idUser;
            tblfiscalizacao.FkSisHidraSaniReparo = tblSisHidraSaniRep.Id;
            tblfiscalizacao.FkSistemaIncendio = tblSisIncendio.Id;
            tblfiscalizacao.FkTipoSeg = tblTipoSeg.Id;
            tblfiscalizacao.FkTransito = tblTransito.Id;
            tblfiscalizacao.FkUeb = tblUeb.Id;
            db.tblFiscalizacao.Add(tblfiscalizacao);
            db.SaveChanges();

            /*
             * Categoria Equipamentos *
             * Colocar o id da fiscalização na tabela CatSeg... Ou seja... adicionar o ele após salvar a tblFiscalização
             * */
            if (CatVig)
            {
                tblequipamentosSeg.Nome = "Vigilante";
                tblequipamentosSeg.Fardamento = Fardamento;
                tblequipamentosSeg.Apito = Apito;
                tblequipamentosSeg.CapaChuva = CapaChuva;
                tblequipamentosSeg.Colete = Colete;
                tblequipamentosSeg.Tonfa = Tonfa;
                tblequipamentosSeg.Lanterna = Lanterna;
                tblequipamentosSeg.Cracha = Cracha;
                tblequipamentosSeg.Quepe = Quepe;
                tblequipamentosSeg.Revolver = Revolver;
                tblequipamentosSeg.Radio = Radio;
                db.tblEquipamentosSeg.Add(tblequipamentosSeg);
                relfiscCaEq.FkCatSeg = tblequipamentosSeg.Id;
                relfiscCaEq.FkFiscalizacao = tblfiscalizacao.Id;
                db.SaveChanges();

            }
            if (CatPor)
            {
                tblequipamentosSeg.Nome = "Porteiro";
                tblequipamentosSeg.Fardamento = FardamentoP;
                tblequipamentosSeg.Apito = ApitoP;
                tblequipamentosSeg.CapaChuva = CapaChuvaP;
                tblequipamentosSeg.Colete = ColeteP;
                tblequipamentosSeg.Tonfa = TonfaP;
                tblequipamentosSeg.Lanterna = LanternaP;
                tblequipamentosSeg.Cracha = CrachaP;
                tblequipamentosSeg.Quepe = QuepeP;
                tblequipamentosSeg.Revolver = RevolverP;
                tblequipamentosSeg.Radio = RadioP;
                db.tblEquipamentosSeg.Add(tblequipamentosSeg);
                relfiscCaEq.FkCatSeg = tblequipamentosSeg.Id;
                relfiscCaEq.FkFiscalizacao = tblfiscalizacao.Id;
                db.SaveChanges();
            }


            return View();
        }
    }
}