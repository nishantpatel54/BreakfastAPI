namespace BuberBreakfast.Contracts.Breakfast;

public record BreakfastResponse(
    Guid id,
    string Name,
    string Description,
    DateTime startDateTime,
    DateTime endDateTime,
    DateTime lastModifiedDateTime,
    List<String> Savory,
    List<String> Sweet
);