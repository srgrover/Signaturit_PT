using Signaturit_PT.Domain.Entities;
using Signaturit_PT.Domain.Interfaces;

namespace Signaturit_PT.Servicios
{
    public class SignatureService : ISignature
    {
        string ISignature.WinnerByContract(ContractVersus contracts)
        {
            int puntosA = GetPuntosByContract(contracts.contractA.ToUpper());
            int puntosB = GetPuntosByContract(contracts.contractB.ToUpper());

            return (puntosA > puntosB) ? "Contract A Gana" : (puntosA == puntosB) ? "Empate" : "Contract B Gana";
        }

        private int GetPuntosByContract(string contract)
        {
            int puntuacion = 0;

            if (string.IsNullOrEmpty(contract))
            {
                return 0;
            }

            foreach (var i in contract)
            {
                switch (i)
                {
                    case 'K':
                        puntuacion += 5;
                        break;
                    case 'N':
                        puntuacion += 2;
                        break;
                    case 'V':
                        puntuacion += 1;
                        break;
                }
            }

            return puntuacion;
        }
    }
}
