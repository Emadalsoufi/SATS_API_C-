using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.IRepository;
using System;
using System.Collections.Generic;

namespace SATS.Application.ServiceImpl
{
    public class AttendanceRecordServiceImpl : IAttendanceRecordService
    {
        private readonly IAttendanceRecordRepository _recordRepository;
        private readonly IMapper _mapper;

        public AttendanceRecordServiceImpl(IAttendanceRecordRepository recordRepository, IMapper mapper)
        {
            _recordRepository = recordRepository;
            _mapper = mapper;
        }

        public void CreateAttendanceRecordService(AttendanceRecordDto attendanceRecordServiceDto)
        {
            if (attendanceRecordServiceDto is null) throw new ArgumentNullException(nameof(attendanceRecordServiceDto));
            var entity = _mapper.Map<AttendanceRecord>(attendanceRecordServiceDto);
            _recordRepository.Add(entity);
        }

        public void UpdateAttendanceRecordService(AttendanceRecordDto attendanceRecordDto)
        {
            if (attendanceRecordDto is null) throw new ArgumentNullException(nameof(attendanceRecordDto));
            var existing = _recordRepository.GetById(attendanceRecordDto.RecordId);
            if (existing is null) throw new ArgumentException("Attendance record was not found.", nameof(attendanceRecordDto));
            _mapper.Map(attendanceRecordDto, existing);
            _recordRepository.Update(existing);
        }

        public AttendanceRecordDto? GetAttendanceRecordServiceById(int id)
        {
            var entity = _recordRepository.GetById(id);
            return entity is null ? null : _mapper.Map<AttendanceRecordDto>(entity);
        }

        public IEnumerable<AttendanceRecordDto> AttendanceRecordServices()
        {
            var entities = _recordRepository.GetAll();
            return _mapper.Map<IEnumerable<AttendanceRecordDto>>(entities);
        }
    }
}
