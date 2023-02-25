namespace OperationDesignPatternAPI.StaticFactoryMethod
{
    public record class SuccessfulOperationResult : OperationResult
    {
        public override bool Succeeded { get; } = true;
        public virtual int? Value { get; init; }
    }
}
