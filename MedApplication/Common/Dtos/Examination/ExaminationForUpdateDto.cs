using AutoMapper.Execution;

namespace MedApplication.Common.Dtos;

public class ExaminationForUpdateDto
{
    public int Id { get; set; }

    public string ShortName { get; set; }

    public string FullName { get; set; }
    public string Details { get; set; }
    public int Number {  get; set; }
}
