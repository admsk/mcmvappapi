
using mcmv.api.interfaces;
using mcmvc.api.interfaces;
using mcmvc.api.services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace mcmvc.api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class Participantes : ControllerBase
  {
    private readonly IParticipantesService _participantesService;
    public Participantes(IParticipantesService participantesParticipante)
    {
      _participantesService = participantesParticipante;
    }

    [HttpGet("all", Name = "GetAll")]
    public ActionResult Get()
    {
      var all = _participantesService.GetAll();
      return Ok(all.Result);
    }

    [HttpGet("cota/{cota}", Name = "GetByCota")]
    public ActionResult GetCota(string cota)
    {
      var result = _participantesService.GetByCota(cota);
      return Ok(result.Result);
    }

    [HttpGet("sorteio", Name = "Sorteio")]
    public ActionResult Sorteio()
    {
      var result = _participantesService.Sorteio();
      return Ok(result.Result);
    }

     [HttpGet("habilitados", Name = "Habilitados")]
    public ActionResult Habilitados()
    {
      var result = _participantesService.Habilitados();
      return Ok(result.Result);
    }
  }
}
