using Wpm.Clinic.Api.Commands;
using Wpm.Clinic.Api.Infrastructure;
using Wpm.Clinic.Domain.Entities;
using Wpm.Clinic.Domain.ValueObjects;

namespace Wpm.Clinic.Api.Application;

public class ClinicApplicationService(ClinicDbContext dbContext)
{
    public async Task<Guid> Handle(StartConsultationCommand command)
    {
        var newConsultation = new Consultation(command.PatientId);
        await dbContext.Consultations.AddAsync(newConsultation);
        await dbContext.SaveChangesAsync();
        return newConsultation.Id;
    }

    public async Task Handle(EndConsultationCommand command)
    {
        var consultation = await dbContext.Consultations.FindAsync(command.ConsultationId);
        consultation.End();
        await dbContext.SaveChangesAsync();
    }

    public async Task Handle(SetDiagnosisCommand command)
    {
        var consultation = await dbContext.Consultations.FindAsync(command.ConsultationId);
        consultation.SetDiagnosis(command.Diagnosis);
        await dbContext.SaveChangesAsync();
    }

    public async Task Handle(SetTreatmentCommand command)
    {
        var consultation = await dbContext.Consultations.FindAsync(command.ConsultationId);
        consultation.SetTreatment(command.Treatment);
        await dbContext.SaveChangesAsync();
    }

    public async Task Handle(SetWeightCommand command)
    {
        var consultation = await dbContext.Consultations.FindAsync(command.ConsultationId);
        consultation.SetWeight(command.Weight);
        await dbContext.SaveChangesAsync();
    }

    public async Task Handle(AdministerDrugCommand command)
    {
        var consultation = await dbContext.Consultations.FindAsync(command.ConsultationId);
        consultation.AdministerDrug(command.DrugId, 
                        new Dose(command.Quantity, command.UnitOfMeasure));
        await dbContext.SaveChangesAsync();
    }

    public async Task Handle(RegisterVitalSignsCommand command)
    {
        var consultation = await dbContext.Consultations.FindAsync(command.ConsultationId);
        consultation.RegisterVitalSigns(command.VitalSignReadings
                                               .Select(v => new VitalSigns(v.ReadingDateTime,
                                                                           v.Temperature,
                                                                           v.HeartRate,
                                                                           v.RespiratoryRate)));
        await dbContext.SaveChangesAsync();
    }
}