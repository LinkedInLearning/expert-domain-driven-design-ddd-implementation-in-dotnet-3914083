using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Wpm.Clinic.Api.Commands;
using Wpm.Clinic.Api.Infrastructure;
using Wpm.Clinic.Domain.Entities;
using Wpm.Clinic.Domain.ValueObjects;
using Wpm.SharedKernel;

namespace Wpm.Clinic.Api.Application;

public class ClinicApplicationService(ClinicDbContext dbContext)
{
    public async Task<Guid> Handle(StartConsultationCommand command)
    {
        var newConsultation = new Consultation(command.PatientId);
        await SaveAsync(newConsultation);
        return newConsultation.Id;
    }

    public async Task Handle(EndConsultationCommand command)
    {
        var consultation = await dbContext.Consultations.FindAsync(command.ConsultationId);
        /*consultation.End();*/
        await dbContext.SaveChangesAsync();
    }

    public async Task Handle(SetDiagnosisCommand command)
    {
        var consultation = await LoadAsync(command.ConsultationId);
        consultation.SetDiagnosis(command.Diagnosis);
        await SaveAsync(consultation);
    }

    public async Task Handle(SetTreatmentCommand command)
    {
        var consultation = await dbContext.Consultations.FindAsync(command.ConsultationId);
        /*consultation.SetTreatment(command.Treatment);*/
        await dbContext.SaveChangesAsync();
    }

    public async Task Handle(SetWeightCommand command)
    {
        var consultation = await dbContext.Consultations.FindAsync(command.ConsultationId);
        /*consultation.SetWeight(command.Weight);*/
        await dbContext.SaveChangesAsync();
    }

    public async Task Handle(AdministerDrugCommand command)
    {
        var consultation = await dbContext.Consultations.FindAsync(command.ConsultationId);
        /*consultation.AdministerDrug(command.DrugId,
                        new Dose(command.Quantity, command.UnitOfMeasure));*/
        await dbContext.SaveChangesAsync();
    }

    public async Task Handle(RegisterVitalSignsCommand command)
    {
        var consultation = await dbContext.Consultations.FindAsync(command.ConsultationId);
      /*  consultation.RegisterVitalSigns(command.VitalSignReadings
                                               .Select(v => new VitalSigns(v.ReadingDateTime,
                                                                           v.Temperature,
                                                                           v.HeartRate,
                                                                           v.RespiratoryRate)));
*/        
        await dbContext.SaveChangesAsync();
    }

    public async Task SaveAsync(Consultation consultation)
    {
        var aggregateId = $"Consultation-{consultation.Id}";
        var changes = consultation.GetChanges()
            .Select(e => new ConsultationEventData(Guid.NewGuid(),
            aggregateId,
            e.GetType().Name,
            JsonConvert.SerializeObject(e),
            e.GetType().AssemblyQualifiedName));

        if (!changes.Any())
        {
            return;
        }

        foreach (var change in changes)
        {
            await dbContext.Consultations.AddAsync(change);
        }

        await dbContext.SaveChangesAsync();

        consultation.ClearChanges();
    }

    public async Task<Consultation> LoadAsync(Guid id)
    {
        var aggregateId = $"Consultation-{id}";
        var result = await dbContext.Consultations
            .Where(a => a.AggregateId == aggregateId)
            .ToListAsync();

        var domainEvents = result.Select(e =>
        {
            var assemblyQualifiedName = e.AssemblyQualifiedName;
            var eventType = Type.GetType(assemblyQualifiedName);
            var data = JsonConvert.DeserializeObject(e.Data, eventType!);
            return data as IDomainEvent;
        });

        var aggregate = new Consultation(domainEvents!);

        return aggregate;
    }
}