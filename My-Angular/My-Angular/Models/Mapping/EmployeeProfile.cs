using AutoMapper;
using My_Angular.Models.Domain;
using My_Angular.Models.DTO;

namespace My_Angular.Models.Mapping
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        
        }

    }
}
