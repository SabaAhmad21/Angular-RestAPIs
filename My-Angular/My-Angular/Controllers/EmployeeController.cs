using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_Angular.Infrastructure.Infrastructure;
using My_Angular.Models.Domain;
using My_Angular.Models.DTO;

namespace My_Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper) 
        {
        
        _employeeRepository = employeeRepository;
        _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto request)
        {
            var employee = _mapper.Map<Employee>(request);
            await _employeeRepository.CreateAsync(employee);

            var response = _mapper.Map<EmployeeDto>(employee);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<EmployeeDto>(employee);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllAsync();
            var response = employees.Select(employee => _mapper.Map<EmployeeDto>(employee));

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, UpdateEmployeeDto request)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _mapper.Map(request, employee);
            await _employeeRepository.UpdateAsync(employee);

            var response = _mapper.Map<EmployeeDto>(employee);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            await _employeeRepository.DeleteAsync(id);

            return NoContent();
        }
    }
    }
