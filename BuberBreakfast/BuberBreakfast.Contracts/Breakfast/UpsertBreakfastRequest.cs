namespace BuberBreakfast.Contracts.Breakfast;

public record UpsertBreakfastRequest(
    string Name,
    string Description,
    DateTime startDateTime,
    DateTime endDateTime,
    List<String> Savory,
    List<String> Sweet
);