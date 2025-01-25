using ams.domain.Abstractions;
using ams.domain.Sims.Events;

namespace ams.domain.Sims;

public sealed class Sim : Entity
{
    public ServiceAccount ServiceAccount { get; set; }
    public ServiceNumber ServiceNumber { get; set; }
    public SimCardNumber SimCardNumber { get; set; }
    public Imei1 Imei1 { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTimeOffset CreationDateTime { get; set; }
    public Guid? UpdatedBy { get; set; }
    public DateTimeOffset? LastUpdateDateTime { get; set; }
    public Guid? AssignedTo { get; set; }
    public Guid? AssignedPlan { get; set; }
    public SimStatus Status { get; set; }
    private Sim() { }

    private Sim(Guid id,
        ServiceAccount serviceAccount,
        ServiceNumber serviceNumber,
        SimCardNumber simCardNumber,
        Imei1 imei1,
        Guid? createdBy,
        Guid? assignedTo,
        Guid? assignedPlan
        )
    {
        Id = id;
        ServiceAccount = serviceAccount;
        ServiceNumber = serviceNumber;
        SimCardNumber = simCardNumber;
        Imei1 = imei1;
        CreatedBy = createdBy;
        CreationDateTime = DateTimeOffset.UtcNow;
        AssignedTo = assignedTo;
        if (assignedTo.HasValue)
            Status = SimStatus.Assigned;
        else
            Status = SimStatus.NotAssigned;
        AssignedPlan = assignedPlan;
    }

    public static Sim CreateSim(
        ServiceAccount serviceAccount,
        ServiceNumber serviceNumber,
        SimCardNumber simCardNumber,
        Imei1 imei1,
        Guid? createdBy,
        Guid? assignedTo,
        Guid? assignedPlan)
    {
        var sim = new Sim(Guid.NewGuid(),
            serviceAccount,
            serviceNumber,
            simCardNumber,
            imei1,
            createdBy,
            assignedTo,
            assignedPlan);
        sim.RaiseDomainEvent(new SimCreatedDomainEvent(sim.Id));
        return sim;
    }

    public static Sim EditSim(Sim sim,
        ServiceAccount serviceAccount,
        ServiceNumber serviceNumber,
        SimCardNumber simCardNumber,
        Imei1 imei1,
        Guid? updatedBy,
        Guid? assignedTo,
        Guid? assignedPlan)
    {
        sim.ServiceAccount = serviceAccount;
        sim.ServiceNumber = serviceNumber;
        sim.SimCardNumber = simCardNumber;
        sim.Imei1 = imei1;
        sim.UpdatedBy = updatedBy;
        sim.LastUpdateDateTime = DateTimeOffset.UtcNow;
        sim.AssignedTo = assignedTo;
        sim.AssignedPlan = assignedPlan;
        sim.RaiseDomainEvent(new SimUpdatedDomainEvent(sim.Id));
        return sim;
    }

    public static Sim DeleteSim(Sim sim)
    {
        sim.IsDeleted = true;
        return sim;
    }
}
