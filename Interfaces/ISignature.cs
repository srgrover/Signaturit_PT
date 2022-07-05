using Signaturit_PT.Entities;

namespace Signaturit_PT.Interfaces
{
    public interface ISignature
    {
        string WinnerByContract(ContractVersus contracts);
        string SignatureToWinByContract(ContractVersus contracts);
    }
}
