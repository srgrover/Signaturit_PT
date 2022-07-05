using Signaturit_PT.Entities;
using Signaturit_PT.Interfaces;

namespace Signaturit_PT.Servicios
{
    public class SignatureService : ISignature
    {
        enum valorFirma { V = 1, N = 2, K = 5};

        public string WinnerByContract(ContractVersus contracts)
        {
            int puntosA = GetPuntosByContract((contracts.contractA ?? "").ToUpper());
            int puntosB = GetPuntosByContract((contracts.contractB ?? "").ToUpper());

            return (puntosA > puntosB) ? "Contract A Gana" : (puntosA == puntosB) ? "Empate" : "Contract B Gana";
        }

        public string SignatureToWinByContract(ContractVersus contracts)
        {
            bool contrAIncomplete = IsContractIncomplete(contracts.contractA ?? "");
            bool contrBIncomplete = IsContractIncomplete(contracts.contractB ?? "");

            if (contrAIncomplete && contrBIncomplete || !contrAIncomplete && !contrBIncomplete)
            {
                return "Ingrese almenos un contrato completo";
            } 
            else
            {
                int puntosA = GetPuntosByContract((contracts.contractA ?? "").ToUpper());
                int puntosB = GetPuntosByContract((contracts.contractB ?? "").ToUpper());

                if (contrAIncomplete) return "Contrato A " + GetFirmaGanadoraByContracts(puntosB, puntosA);
                else return "Contrato B " + GetFirmaGanadoraByContracts(puntosA, puntosB);
            }
        }

        private string GetFirmaGanadoraByContracts(int puntosContratoCompleto, int puntosContratoIncompleto)
        {
            foreach (int puntosExtra in Enum.GetValues(typeof(valorFirma)))
            {
                if ((puntosContratoIncompleto + puntosExtra) > puntosContratoCompleto)
                {
                    return "necesita la firma: " + Enum.GetName(typeof(valorFirma), puntosExtra) ?? "";
                }
            }

            return "No hay firma ganadora";
        }

        private int GetPuntosByContract(string contract)
        {
            int puntuacion = 0;

            foreach (var i in contract)
            {
                switch (i)
                {
                    case 'K':
                        puntuacion += (int)valorFirma.K;
                        break;
                    case 'N':
                        puntuacion += (int)valorFirma.N;
                        break;
                    case 'V':
                        if(contract.IndexOf("K") == -1) puntuacion += (int)valorFirma.V;
                        break;
                }
            }

            return puntuacion;
        }

        private bool IsContractIncomplete(string contract){
            return contract.IndexOf("#") != -1;
        }
    }
}
