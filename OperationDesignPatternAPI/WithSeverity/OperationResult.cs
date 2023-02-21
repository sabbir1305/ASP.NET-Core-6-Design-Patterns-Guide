using System.Collections.Immutable;

namespace OperationDesignPatternAPI.WithSeverity
{
    public record class OperationResult
    {
        public ImmutableList<OperationResultMessage> Messages { get; init; }
        public int? Value { get; init; }
        public OperationResult()
        {
            Messages = ImmutableList<OperationResultMessage>.Empty;
        }
        public OperationResult(params OperationResultMessage[] messages)
        {
            Messages = messages.ToImmutableList();
        }

        public bool Succeeded => !HasErrors();

        public bool HasErrors()
        {
            return FindErrors().Any();
        }

        private ImmutableList<OperationResultMessage> FindErrors() => Messages.Where(x => x.Severity == OperationResultSeverity.Error).ToImmutableList();
    }
}
