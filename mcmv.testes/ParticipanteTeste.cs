using mcmvc.api.interfaces;
using mcmvc.api.models;
using mcmvc.api.services;

namespace mcmv.testes
{
  [TestClass]
  public class ParticipanteTeste
  {

    private readonly IParticipantesService _participantesService;
    public ParticipanteTeste()
    {
      _participantesService = new ParticipantesService();
    }

    [TestMethod]
    public void Verificar_Qtde_Particiantes()
    {
      List<Participantes> participantesEsperados = new List<Participantes>
      {
           new Participantes { nome = "Oliver Ricardo Ribeiro", cpf = "925.091.645-03", dataNascimento = new DateTime(1980, 3, 24).ToString(), renda = 2000.00m, cota = "GERAL", cid = "" },
           new Participantes { nome = "Lavínia Mariah Jennifer dos Santos", cpf = "843.831.525-97", dataNascimento = new DateTime(2005, 10, 5).ToString(), renda = 1045.00m, cota = "GERAL", cid = "" },
           new Participantes { nome = "Sabrina Luna Laís Cavalcanti", cpf = "945.553.979-91", dataNascimento = new DateTime(1971, 11, 26).ToString(), renda = 3000.00m, cota = "DEFICIENTE FÍSICO", cid = "H90" },
           new Participantes { nome = "Hugo Manuel Novaes", cpf = "239.964.398-49", dataNascimento = new DateTime(1971, 10, 19).ToString(), renda = 7850.00m, cota = "GERAL", cid = "" },
           new Participantes { nome = "Ana Brenda Esther Ramos", cpf = "840.216.806-56", dataNascimento = new DateTime(1982, 8, 23).ToString(), renda = 1790.99m, cota = "DEFICIENTE FÍSICO", cid = "H90" },
           new Participantes { nome = "Sérgio Vinicius Barros", cpf = "479.893.965-05", dataNascimento = new DateTime(1956, 7, 4).ToString(), renda = 5225.00m, cota = "IDOSO", cid = "" },
           new Participantes { nome = "Bruno Levi Dias", cpf = "053.246.187-80", dataNascimento = new DateTime(1941, 9, 13).ToString(), renda = 2500.00m, cota = "IDOSO", cid = "" },
           new Participantes { nome = "Tomás João Moreira", cpf = "358.414.793-00", dataNascimento = new DateTime(1940, 10, 26).ToString(), renda = 998.00m, cota = "IDOSO", cid = "" },
           new Participantes { nome = "Severino Igor Mário Barros", cpf = "958.617.790-40", dataNascimento = new DateTime(1994, 2, 21).ToString(), renda = 4000.00m, cota = "DEFICIENTE FÍSICO", cid = "H90" },
           new Participantes { nome = "Malu Emilly Pinto", cpf = "071.865.388-27", dataNascimento = new DateTime(2002, 9, 19).ToString(), renda = 39000.00m, cota = "GERAL", cid = "" },
           new Participantes { nome = "Giovanna Gabriela da Mota", cpf = "735.196.00m8-97", dataNascimento = new DateTime(1995, 12, 18).ToString(), renda = 1250.00m, cota = "GERAL", cid = "" },
           new Participantes { nome = "Eduardo Gael Cardoso", cpf = "737.055.718-93", dataNascimento = new DateTime(1977, 3, 11).ToString(), renda = 5225.99m, cota = "DEFICIENTE FÍSICO", cid = "" },
           new Participantes { nome = "Heitor Kauê Martins", cpf = "005.517.108-00", dataNascimento = new DateTime(1986, 6, 22).ToString(), renda = 3000.58m, cota = "GERAL", cid = "" },
           new Participantes { nome = "Rebeca Rita Moura", cpf = "325.541.788-01", dataNascimento = new DateTime(1981, 8, 26).ToString(), renda = 1250.98m, cota = "DEFICIENTE FÍSICO", cid = "" },
           new Participantes { nome = "Rodrigo Sebastião Araújo", cpf = "785.118.978-01", dataNascimento = new DateTime(1958, 5, 20).ToString(), renda = 6000.79m, cota = "DEFICIENTE FÍSICO", cid = "H90" },
           new Participantes { nome = "Leandro Gustavo Viana", cpf = "411.601.448-69", dataNascimento = new DateTime(1945, 4, 26).ToString(), renda = 10999.99m, cota = "GERAL", cid = "" },
           new Participantes { nome = "Letícia Rita Ferreira", cpf = "025.500.928-39", dataNascimento = new DateTime(1956, 3, 13).ToString(), renda = 3675.64m, cota = "IDOSO", cid = "" },
           new Participantes { nome = "Kaique Calebe Almeida", cpf = "128.021.648-48", dataNascimento = new DateTime(1972, 4, 27).ToString(), renda = 4488.48m, cota = "GERAL", cid = "" },
           new Participantes { nome = "Raul Emanuel Araújo", cpf = "531.380.488-03", dataNascimento = new DateTime(1985, 12, 16).ToString(), renda = 4567.45m, cota = "IDOSO", cid = "" },
           new Participantes { nome = "Allana Marina Mariane Alves", cpf = "887.969.268-21", dataNascimento = new DateTime(1980, 11, 9).ToString(), renda = 5454.55m, cota = "GERAL", cid = "" }
    };

      Task<List<Participantes>> qtdeEsperada = _participantesService.GetAll();

      Assert.AreEqual(qtdeEsperada.Result.Count, participantesEsperados.Count);
    }

    [TestMethod]

    public void Executar_Sorteio_Deve_Trazer_Apenas5_Registros()
    {
      Task<List<Participantes>> qtdeEsperada = _participantesService.Sorteio();
      Assert.IsTrue(qtdeEsperada.Result.Count == 5);
    }

    [TestMethod]
    public void Realizar_Sorteio_Idoso_Deve_Trazer_Apenas1__Registro()
    {
      Task<List<Participantes>> qtdeEsperada = _participantesService.Sorteio();

      var result = qtdeEsperada.Result.Where(s => s.cota == "IDOSO").Count();
      
      Assert.IsTrue(result == 1);
    }

    [TestMethod]
    public void Realizar_Sorteio_Idoso_Deve_Ser_Maior_60_Anos()
    {
      Task<List<Participantes>> qtdeEsperada = _participantesService.Sorteio();

      var result = qtdeEsperada.Result.Where(s => s.cota == "IDOSO" && mcmvc.api.Common.Utils.VerificarIdade(s.dataNascimento,60,true)).Count();

      Assert.IsTrue(result == 1);
    }

    [TestMethod]
    public void Realizar_Sorteio_DeficienteFisico_Deve_Trazer_Apenas1_Registro()
    {
      Task<List<Participantes>> qtdeEsperada = _participantesService.Sorteio();

      var result = qtdeEsperada.Result.Where(s => s.cota == "DEFICIENTE FÍSICO").Count();

      Assert.IsTrue(result == 1);
    }

    [TestMethod]
    public void Realizar_Sorteio_DeficienteFisico_Deve_Trazer_Apenas_Com_CID()
    {
      Task<List<Participantes>> qtdeEsperada = _participantesService.Sorteio();

      var result = qtdeEsperada.Result.Where(s => s.cota == "DEFICIENTE FÍSICO" && s.cid != "").Count();

      Assert.IsTrue(result == 1);
    }

    [TestMethod]
    public void Realizar_Sorteio_Geral_Deve_Trazer_Apenas3_Registro()
    {
      Task<List<Participantes>> qtdeEsperada = _participantesService.Sorteio();

      var result = qtdeEsperada.Result.Where(s => s.cota == "GERAL").Count();

      Assert.IsTrue(result == 3);
    }

    [TestMethod]
    public void Realizar_Validacao_Participantes_Habilitados_Trazer_QtdeMenor_Que_Total()
    {
      Task<List<Participantes>> qtdeEsperada = _participantesService.Sorteio();

      var result = qtdeEsperada.Result.Where(p => p.renda >= 1045.00m && p.renda <= 5255.00m && mcmvc.api.Common.Utils.ValidarCPF(p.cpf)).Count();

      Assert.IsTrue(result < 20);
    }


  }

}