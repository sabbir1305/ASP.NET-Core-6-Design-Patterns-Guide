using System.Text.Json.Serialization;

namespace CustomerMinimalAPI
{
    public record class Customer(
    int Id,
    string Name,
    List<Contract> Contracts
);

    public record class Contract(
        int Id,
        string Name,
        string Description,
        ContractWork Work,
        ContactInformation PrimaryContact
    );

    public record class ContractWork(int Total, int Done)
    {
        public WorkState State =>
            Done == 0 ? WorkState.New :
            Done == Total ? WorkState.Completed :
            WorkState.InProgress;
    }

    public record class ContactInformation(
        string Firstname,
        string Lastname,
        string Email
    );

    public enum WorkState
    {
        New,
        InProgress,
        Completed
    }
    public record class ContractDetails(
    int Id,
    string Name,
    string Description,
    int WorkTotal,
    int WorkDone,
    string WorkState,
    string PrimaryContactFirstname,
    string PrimaryContactLastname,
    string PrimaryContactEmail
);
    public record class CustomerDetails(
        int Id,
        string Name,
        IEnumerable<ContractDetails> Contracts
    );
    public record class CustomerSummary(
        int Id,
        string Name,
        int TotalNumberOfContracts,
        int NumberOfOpenContracts
    );
}
