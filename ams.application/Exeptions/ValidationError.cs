namespace ams.application.Exeptions;
public sealed record ValidationError(string PropertyName, string ErrorMessage);