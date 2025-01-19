public record SimRequest(
    string ServiceAccount,
    string ServiceNumber,
    string SimCardNumber,
    string Imei1,
    Guid? AssignedTo
    );
