using System.Text.Json.Serialization;

namespace OperationDesignPatternAPI.WithSeverity
{
    public record class OperationResultMessage
    {
        public string Message { get; }
        public OperationResultMessage(string message, OperationResultSeverity severity)
        {
            Message = message ?? throw new ArgumentNullException(nameof(message));
            Severity = severity;
        }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OperationResultSeverity Severity { get; }
    }
}
