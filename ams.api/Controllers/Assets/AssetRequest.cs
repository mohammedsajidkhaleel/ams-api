using ams.application.Abstractions.Data;

namespace ams.api.Controllers.Assets;
public record AssetRequest(
    string Code,
    string Name,
    string SerialNumber,
    Guid? AssignedTo,
    Guid? ProjectId,
    string? Description,
    Guid? ItemId,
    string? PONumber
    );
