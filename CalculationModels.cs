using System.Text.Json.Serialization;

namespace AerospaceCalc;

// C# 13 Record types for JSON parsing/sending
public record CalculationRequest(
    [property: JsonPropertyName("action")] string Action,
    [property: JsonPropertyName("xActual")] decimal XActual,
    [property: JsonPropertyName("xTarget")] decimal XTarget,
    [property: JsonPropertyName("yActual")] decimal YActual,
    [property: JsonPropertyName("yTarget")] decimal YTarget
);

public record CalculationResponse(
    [property: JsonPropertyName("success")] bool Success,
    [property: JsonPropertyName("truePosition")] string? TruePosition = null,
    [property: JsonPropertyName("errorMessage")] string? ErrorMessage = null
);
