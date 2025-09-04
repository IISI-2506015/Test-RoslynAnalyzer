using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace WebApplication1.Examples
{
    /// <summary>
    /// 命名規範示例類別
    /// 展示各種命名規則的正確實作
    /// </summary>
    public class NamingConventionsExample
    {
        // Private fields 應該以下劃線開頭，使用 camelCase
        private readonly IPatientService _patientService;
        private readonly ILogger<NamingConventionsExample> _logger;
        private string _currentPatientName;
        private int _patientCount;

        // Constructor 使用 PascalCase
        public NamingConventionsExample(IPatientService patientService, ILogger<NamingConventionsExample> logger)
        {
            _patientService = patientService;
            _logger = logger;
            _currentPatientName = string.Empty;
            _patientCount = 0;
        }

        // Public properties 使用 PascalCase
        public string PatientName { get; set; } = string.Empty;
        public int PatientAge { get; set; }
        public bool IsActive { get; set; }

        // Public methods 使用 PascalCase
        public async Task<PatientDto> GetPatientAsync(int patientId)
        {
            var patient = await _patientService.GetPatientByIdAsync(patientId);
            return MapToDto(patient);
        }

        public List<PatientDto> GetPatientsByQuery(PatientQuery query)
        {
            var patients = _patientService.GetPatients(query);
            return patients.Select(MapToDto).ToList();
        }

        // Private methods 使用 PascalCase
        private PatientDto MapToDto(Patient patient)
        {
            return new PatientDto
            {
                Id = patient.Id,
                Name = patient.Name,
                Age = patient.Age,
                Sex = patient.Sex
            };
        }

        // Local variables 使用 camelCase
        public void ProcessPatientData()
        {
            var patientList = new List<Patient>();
            var processedCount = 0;
            var isValidData = true;

            foreach (var patient in patientList)
            {
                if (IsValidPatient(patient))
                {
                    processedCount++;
                }
            }
        }

        // Parameters 使用 camelCase
        private bool IsValidPatient(Patient patient)
        {
            return !string.IsNullOrEmpty(patient.Name) && patient.Age > 0;
        }
    }

    /// <summary>
    /// Controller 類別 - 以 Controller 結尾
    /// </summary>
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PatientDto>>> GetPatients()
        {
            var patients = await _patientService.GetAllPatientsAsync();
            return Ok(patients);
        }
    }

    /// <summary>
    /// Interface 介面 - 以 I 開頭
    /// </summary>
    public interface IPatientService
    {
        Task<Patient> GetPatientByIdAsync(int patientId);
        List<Patient> GetPatients(PatientQuery query);
        Task<List<Patient>> GetAllPatientsAsync();
    }

    /// <summary>
    /// Repository Interface 介面 - 以 I 開頭
    /// </summary>
    public interface IPatientRepository
    {
        Task<Patient> GetByIdAsync(int patientId);
        List<Patient> GetByQuery(PatientQuery query);
        Task<List<Patient>> GetAllAsync();
    }

    /// <summary>
    /// Service 類別 - 以 Service 結尾
    /// </summary>
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<Patient> GetPatientByIdAsync(int patientId)
        {
            return await _patientRepository.GetByIdAsync(patientId);
        }

        public List<Patient> GetPatients(PatientQuery query)
        {
            return _patientRepository.GetByQuery(query);
        }

        public async Task<List<Patient>> GetAllPatientsAsync()
        {
            return await _patientRepository.GetAllAsync();
        }
    }

    /// <summary>
    /// DTO 類別 - 以 Dto 結尾
    /// </summary>
    public class PatientDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public SexEnum Sex { get; set; }
    }

    /// <summary>
    /// Query 類別 - 以 Query 結尾
    /// </summary>
    public class PatientQuery
    {
        public string? NameFilter { get; set; }
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }
        public SexEnum? SexFilter { get; set; }
    }

    /// <summary>
    /// Domain.Entity 類別 - 不用特定結尾
    /// </summary>
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public SexEnum Sex { get; set; }
    }

    /// <summary>
    /// Business.Model 類別 - 不用特定結尾
    /// </summary>
    public class PatientAge
    {
        public int Value { get; set; }
        public DateTime CalculatedDate { get; set; }
    }

    /// <summary>
    /// Enum - 以 Enum 結尾
    /// </summary>
    public enum SexEnum
    {
        Male,
        Female,
        Other
    }

    /// <summary>
    /// 複數命名示例
    /// </summary>
    public class PatientsModule
    {
        private readonly List<Patient> _patients;
        private readonly Dictionary<int, PatientDto> _patientCache;

        public PatientsModule()
        {
            _patients = new List<Patient>();
            _patientCache = new Dictionary<int, PatientDto>();
        }

        public void AddPatient(Patient patient)
        {
            _patients.Add(patient);
        }

        public List<Patient> GetAllPatients()
        {
            return _patients;
        }
    }
}
