using AutoMapper;
using MedApplication.Common.Dtos.Address;
using MedApplication.Common.Dtos.Department;
using MedApplication.Common.Dtos.Diagnose;
using MedApplication.Common.Dtos.Doctor;
using MedApplication.Common.Dtos.DoctorInfo;
using MedApplication.Common.Dtos.Examination;
using MedApplication.Common.Dtos.Medicine;
using MedApplication.Common.Dtos.Organization;
using MedApplication.Common.Dtos.Patient;
using MedApplication.Common.Dtos.Payment;
using MedApplication.Common.Dtos.PaymentHystory;
using MedApplication.Common.Dtos.PlasticCard;
using MedApplication.Common.Dtos.WeekDay;
using MedApplication.Common.Dtos.WorkingHour;
using MedDomain.Entities;

namespace MedApplication.Common.Mappings;

public class Mapping : Profile
{
    public Mapping()
    {
        //Organization
        CreateMap<Organization, OrganizationForCreationDto>().ReverseMap();
        CreateMap<Organization, OrganizationForUpdateDto>().ReverseMap();
        CreateMap<Organization, OrganizationForResultDto>().ReverseMap();

        //Address
        CreateMap<Address, AddressForCreationDto>().ReverseMap();
        CreateMap<Address, AddressForUpdateDto>().ReverseMap();
        CreateMap<Address, AddressForResultDto>().ReverseMap();

        //Diagnose
        CreateMap<Diagnose, DiagnoseForCreationDto>().ReverseMap();
        CreateMap<Diagnose, DiagnoseForUpdateDto>().ReverseMap();
        CreateMap<Diagnose, DiagnoseForResultDto>().ReverseMap();

        //Department
        CreateMap<Department, DepartmentForCreationDto>().ReverseMap();
        CreateMap<Department, DepartmentForUpdateDto>().ReverseMap();
        CreateMap<Department, DepartmentForResultDto>().ReverseMap();

        //Doctor
        CreateMap<Doctor, DoctorForCreationDto>().ReverseMap();
        CreateMap<Doctor, DoctorForUpdateDto>().ReverseMap();
        CreateMap<Doctor, DoctorForResultDto>().ReverseMap();

        //DoctorInfo
        CreateMap<DoctorInfo, DoctorInfoForCreationDto>().ReverseMap();
        CreateMap<DoctorInfo, DoctorInfoForUpdateDto>().ReverseMap();
        CreateMap<DoctorInfo, DoctorInfoForResultDto>().ReverseMap();

        //Examination
        CreateMap<Examination, ExaminationForCreationDto>().ReverseMap();
        CreateMap<Examination, ExaminationForUpdateDto>().ReverseMap();
        CreateMap<Examination, ExaminationForResultDto>().ReverseMap();

        //Medicine
        CreateMap<Medicine, MedicineForCreationDto>().ReverseMap();
        CreateMap<Medicine, MedicineForUpdateDto>().ReverseMap();
        CreateMap<Medicine, MedicineForResultDto>().ReverseMap();

        //Patient
        CreateMap<Patient, PatientForCreationDto>().ReverseMap();
        CreateMap<Patient, PatientForUpdateDto>().ReverseMap();
        CreateMap<Patient, PatientForResultDto>().ReverseMap();

        //Payment
        CreateMap<Payment, PaymentForCreationDto>().ReverseMap();
        CreateMap<Payment, PaymentForUpdateDto>().ReverseMap();
        CreateMap<Payment, PaymentForResultDto>().ReverseMap();

        //PaymentHystory
        CreateMap<PaymentHystory, PaymentHystoryForCreationDto>().ReverseMap();
        CreateMap<PaymentHystory, PaymentHystoryForUpdateDto>().ReverseMap();
        CreateMap<PaymentHystory, PaymentHystoryForResultDto>().ReverseMap();

        //PlasticCard
        CreateMap<PlasticCard, PlasticCardForCreationDto>().ReverseMap();
        CreateMap<PlasticCard, PlasticCardForUpdateDto>().ReverseMap();
        CreateMap<PlasticCard, PlasticCardForResultDto>().ReverseMap();

        //WeekDay
        CreateMap<WeekDay, WeekDayForCreationDto>().ReverseMap();
        CreateMap<WeekDay, WeekDayForUpdateDto>().ReverseMap();
        CreateMap<WeekDay, WeekDayForResultDto>().ReverseMap();

        //WorkingHour
        CreateMap<WorkingHour, WorkingHourForCreationDto>().ReverseMap();
        CreateMap<WorkingHour, WorkingHourForUpdateDto>().ReverseMap();
        CreateMap<WorkingHour, WorkingHourForResultDto>().ReverseMap();
    }
}