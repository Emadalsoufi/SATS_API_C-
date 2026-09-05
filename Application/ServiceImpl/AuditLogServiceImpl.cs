using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.IRepository;
using System;
using System.Collections.Generic;

namespace SATS.Application.ServiceImpl
{
    public class AuditLogServiceImpl : IAuditLogService
    {
        private readonly IAuditLogRepository _auditLogRepository;
        private readonly IMapper _mapper;

        public AuditLogServiceImpl(IAuditLogRepository auditLogRepository, IMapper mapper)
        {
            _auditLogRepository = auditLogRepository;
            _mapper = mapper;
        }

        public void CreateAuditLogService(AuditLogDto auditLogDto)
        {
            if (auditLogDto is null) throw new ArgumentNullException(nameof(auditLogDto));
            var entity = _mapper.Map<AuditLog>(auditLogDto);
            _auditLogRepository.Add(entity);
        }

        public void UpdateAuditLogService(AuditLogDto auditLogDto)
        {
            if (auditLogDto is null) throw new ArgumentNullException(nameof(auditLogDto));
            var existing = _auditLogRepository.GetById(auditLogDto.AuditLogId);
            if (existing is null) throw new ArgumentException("Audit log was not found.", nameof(auditLogDto));
            _mapper.Map(auditLogDto, existing);
            _auditLogRepository.Update(existing);
        }

        public AuditLogDto? GetAuditLogServiceById(int id)
        {
            var entity = _auditLogRepository.GetById(id);
            return entity is null ? null : _mapper.Map<AuditLogDto>(entity);
        }

        public IEnumerable<AuditLogDto> GetAllAuditLogServices()
        {
            var entities = _auditLogRepository.GetAll();
            return _mapper.Map<IEnumerable<AuditLogDto>>(entities);
        }
    }
}
