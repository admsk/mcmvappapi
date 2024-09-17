using mcmv.api.interfaces;
using mcmvc.api.Common;
using mcmvc.api.interfaces;
using mcmvc.api.models;
using mcmvc.api.repository;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace mcmvc.api.services
{
  public class ParticipantesService : IParticipantesService
  {
    public async Task<List<Participantes>> GetAll()
    {
      var participantes = await new ParticipantesRepository().GetAll();

      return participantes.ToList();
    }

    public async Task<List<Participantes>> GetByCota(string cota)
    {
      var participantes = await new ParticipantesRepository().GetByCota(cota.ToUpper());

      return participantes.ToList();
    }

    public async Task<List<Participantes>> Habilitados()
    {
      var allParticipantes = await new ParticipantesRepository().GetAll();

      IEnumerable<Participantes> participantesValidados = Utils.ParticipantesHabilitados(allParticipantes);

      return participantesValidados.ToList();
    }

    public async Task<List<Participantes>> Sorteio()
    {
      var allParticipantes = await new ParticipantesRepository().GetAll();

      //Validação da renda e cpf válido
      IEnumerable<Participantes> participantesValidados = Utils.ParticipantesHabilitados(allParticipantes);

      //Validação da idade mínima para todos e idade ninima para idoso
      var idosos = participantesValidados.Where(i => i.cota == "IDOSO" && Utils.VerificarIdade(i.dataNascimento, 60, true)).ToList();
      var deficiente = participantesValidados.Where(i => i.cota == "DEFICIENTE FÍSICO" && i.cid != "").ToList();
      var geral = participantesValidados.Where(i => i.cota == "GERAL").ToList();

      //Realização do sorteio
      var ganhadorIdoso = SortearGanhadores(idosos, 1);
      var ganhadorDeficiente = SortearGanhadores(deficiente, 1);
      var ganhadoresGeral = SortearGanhadores(geral, 3);

      //Merge das listas contendo todos os registros
      var todosGanhadores = new List<Participantes>();
      todosGanhadores.AddRange(ganhadorIdoso);
      todosGanhadores.AddRange(ganhadorDeficiente);
      todosGanhadores.AddRange(ganhadoresGeral);

      return todosGanhadores.ToList();
    }

    static List<Participantes> SortearGanhadores(List<Participantes> participantes, int quantidade)
    {
      Random random = new Random();
      return participantes.OrderBy(x => random.Next()).Take(quantidade).ToList();
    }

  }
}

