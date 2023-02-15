namespace OperationDesignPatternAPI.SingleError
{
    public record class OperationResult
    {
        public bool Succeeded => string.IsNullOrWhiteSpace(ErrorMessage);
        public string? ErrorMessage { get; init; }
    }
}
