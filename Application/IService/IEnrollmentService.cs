using Application.DTOs;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IEnrollmentService
    {
        void CreateEnrollment(EnrollmentDto enrollmentDto);
        void UpdateEnrollment(EnrollmentDto enrollmentDto);
        EnrollmentDto? GetEnrollmentById(int id);
        IEnumerable<EnrollmentDto> GetAllEnrollments();
    }

}
