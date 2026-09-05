using Application.DTOs;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IAuditLogService
    {
        void CreateAuditLogService(AuditLogDto enrollmentDto);
        void UpdateAuditLogService(AuditLogDto auditLogDto);
        AuditLogDto? GetAuditLogServiceById(int id);
        IEnumerable<AuditLogDto> GetAllAuditLogServices();
    }
}
