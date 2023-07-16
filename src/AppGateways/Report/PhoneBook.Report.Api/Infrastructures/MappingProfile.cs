using AutoMapper;
using PhoneBook.Report.Entities.Dto.Report;

namespace PhoneBook.Report.Api.Infrastructures
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Report.Entities.Concrete.Report, ReportDto>().ReverseMap();
            CreateMap<Report.Entities.Concrete.Report, InsertReportDto>().ReverseMap();
            CreateMap<Report.Entities.Concrete.Report, UpdateReportDto>().ReverseMap();

        }
    }
}
