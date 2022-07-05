using Signaturit_PT.Domain.Entities;

namespace Signaturit_PT.Domain.Interfaces
{
    public interface ISignature
    {
        string WinnerByContract(ContractVersus contracts);
    }
}
