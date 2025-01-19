using ams.domain.Sims;

namespace ams.application.Sims.GetSims;
public sealed class SimsResponse
{
    public Guid Id { get; set; }
    public string? ServiceAccount { get; set; }
    public string? ServiceNumber { get; set; }
    public string? SimCardNumber { get; set; }
    public string? Imei1 { get; set; }
    public Guid? AssignedTo { get; set; }
    public string? AssignedEmployeeName { get; set; }
    public string? AssignedEmployeecode { get; set; }
    public string? SimStatus { get; set; }
}