using System.Globalization;
using System.Text.RegularExpressions;
using mcmvc.api.models;

namespace mcmvc.api.Common
{
  public static class Utils
  {
    public static bool ValidarCPF(string cpf)
    {
      // Remove caracteres não numéricos
      cpf = Regex.Replace(cpf, @"[^\d]", "");

      // Verifica se o CPF tem 11 dígitos
      if (cpf.Length != 11)
      {
        return false;
      }

      // Verifica se todos os dígitos são iguais (caso de CPF inválido como "00000000000")
      if (new string(cpf[0], cpf.Length) == cpf)
      {
        return false;
      }

      // Valida os dígitos verificadores
      return VerificarDigitos(cpf);
    }
    private static bool VerificarDigitos(string cpf)
    {
      int soma;
      int resto;

      soma = 0;
      for (int i = 0; i < 9; i++)
      {
        soma += int.Parse(cpf[i].ToString()) * (10 - i);
      }
      resto = soma % 11;
      if (resto < 2)
      {
        if (int.Parse(cpf[9].ToString()) != 0)
        {
          return false;
        }
      }
      else
      {
        if (int.Parse(cpf[9].ToString()) != 11 - resto)
        {
          return false;
        }
      }

      soma = 0;
      for (int i = 0; i < 10; i++)
      {
        soma += int.Parse(cpf[i].ToString()) * (11 - i);
      }
      resto = soma % 11;
      if (resto < 2)
      {
        if (int.Parse(cpf[10].ToString()) != 0)
        {
          return false;
        }
      }
      else
      {
        if (int.Parse(cpf[10].ToString()) != 11 - resto)
        {
          return false;
        }
      }

      return true;
    }
    private static bool ValidarRenda(string rendaString)
    {
      decimal renda = 0;

      rendaString = rendaString.Replace("R$", "").Replace(" ", "").Replace(".", "").Replace(",", ".");

      if (decimal.TryParse(rendaString, NumberStyles.Number, CultureInfo.InvariantCulture, out renda))
      {
        return renda >= 1045.00m && renda <= 5022.00m;
      }

      return false;
    }
    public static bool VerificarIdade(string dataString, int idade, bool idoso = false)
    {
      DateTime dataAtual = DateTime.Now;

      string[] formatos = { "d/M/yyyy", "M/d/yyyy", "dd/MM/yyyy", "MM/dd/yyyy" };

      DateTime dataInformada = DateTime.ParseExact(dataString, formatos, CultureInfo.InvariantCulture, DateTimeStyles.None);

      int anosDiferenca = dataAtual.Year - dataInformada.Year;

      if (!idoso && anosDiferenca > idade || (anosDiferenca == idade && dataAtual.Date >= dataInformada.AddYears(idade).Date))
        return true;
      else
        if (anosDiferenca > idade) return true;

      return false;
    }

    public static IEnumerable<Participantes> ParticipantesHabilitados(IEnumerable<Participantes> allParticipantes)
    {
      return allParticipantes.Where(p => p.renda >= 1045.00m && p.renda <= 5255.00m && Utils.ValidarCPF(p.cpf));
    }
  }
}
