using SistemaHotel.Exceptions;
using SistemaHotel.Interfaces;

namespace SistemaHotel.Models
{
    public class RH : IRHTerceirizado
    {
        public string Nome {get; set;}

        public Hotel Hotel {get; set;}

        public RH(string nome, Hotel hotel)
        {
            Nome = nome;
            Hotel = hotel;
        }
        
        public void ContratarCamareira(ICamareira camareira)
        {
            Hotel.Camareiras.Add(camareira);
        }

        public void ContratarRecepcionista(IRecepcionista recepcionista)
        {
            Hotel.Recepcionistas.Add(recepcionista);
        }

        public void PromoverParaGerente(Camareira camareira)
        {
            if (camareira.CPF == null)
            {
                throw new Exception("Regularize o CPF.");
            }

            Hotel.ContratarGerente(new Gerente()
            {
                Nome = camareira.Nome,
                CPF = camareira.CPF,
                Telefone = camareira.Telefone
            });
        }

        public void PromoverParaGerente(Recepcionista recepcionista)
        {
              if (recepcionista.CPF == null)
            {
                throw new DocumentosInvalidosEx("Regularize o CPF.");
            }

            Hotel.ContratarGerente(new Gerente()
            {
                Nome = recepcionista.Nome,
                CPF = recepcionista.CPF,
                Telefone = recepcionista.Telefone
            });
        }

      

        public void PromoverParaRecepcionista(Recepcionista recepcionista)
        {
            throw new NotImplementedException();
        }
    }
}