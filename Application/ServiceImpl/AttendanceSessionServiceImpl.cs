using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.IRepository;
using System;
using System.Collections.Generic;

namespace SATS.Application.ServiceImpl
{
    public class AttendanceSessionServiceImpl : IAttendanceSessionService
    {
        private readonly IAttendanceSessionRepository _sessionRepository;
        private readonly IMapper _mapper;

        public AttendanceSessionServiceImpl(IAttendanceSessionRepository sessionRepository, IMapper mapper)
        {
            _sessionRepository = sessionRepository;
            _mapper = mapper;
        }

        public void CreateAttendanceSession(AttendanceSessionDto attendanceSessionDto)
        {
            if (attendanceSessionDto is null) throw new ArgumentNullException(nameof(attendanceSessionDto));
            var entity = _mapper.Map<AttendanceSession>(attendanceSessionDto);
            _sessionRepository.Add(entity);
        }

        public void UpdateAttendanceSession(AttendanceSessionDto attendanceSessionDto)
        {
            if (attendanceSessionDto is null) throw new ArgumentNullException(nameof(attendanceSessionDto));
            var existing = _sessionRepository.GetById(attendanceSessionDto.SessionId);
            if (existing is null) throw new ArgumentException("Attendance session was not found.", nameof(attendanceSessionDto));
            _mapper.Map(attendanceSessionDto, existing);
            _sessionRepository.Update(existing);
        }

        public AttendanceSessionDto? GetAttendanceSessionById(int id)
        {
            var entity = _sessionRepository.GetById(id);
            return entity is null ? null : _mapper.Map<AttendanceSessionDto>(entity);
        }

        public IEnumerable<AttendanceSessionDto> GetAllAttendanceSessions()
        {
            var entities = _sessionRepository.GetAll();
            return _mapper.Map<IEnumerable<AttendanceSessionDto>>(entities);
        }
    }
}
