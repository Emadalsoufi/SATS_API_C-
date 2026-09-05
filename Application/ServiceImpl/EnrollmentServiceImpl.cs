using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.IRepository;
using System;
using System.Collections.Generic;

namespace SATS.Application.ServiceImpl
{
    public class EnrollmentServiceImpl : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IMapper _mapper;

        public EnrollmentServiceImpl(IEnrollmentRepository enrollmentRepository, IMapper mapper)
        {
            _enrollmentRepository = enrollmentRepository;
            _mapper = mapper;
        }

        public void CreateEnrollment(EnrollmentDto enrollmentDto)
        {
            if (enrollmentDto is null) throw new ArgumentNullException(nameof(enrollmentDto));
            var entity = _mapper.Map<Enrollment>(enrollmentDto);
            _enrollmentRepository.Add(entity);
        }

        public void UpdateEnrollment(EnrollmentDto enrollmentDto)
        {
            if (enrollmentDto is null) throw new ArgumentNullException(nameof(enrollmentDto));
            var existing = _enrollmentRepository.GetById(enrollmentDto.EnrollmentId);
            if (existing is null) throw new ArgumentException("Enrollment was not found.", nameof(enrollmentDto));
            _mapper.Map(enrollmentDto, existing);
            _enrollmentRepository.Update(existing);
        }

        public EnrollmentDto? GetEnrollmentById(int id)
        {
            var entity = _enrollmentRepository.GetById(id);
            return entity is null ? null : _mapper.Map<EnrollmentDto>(entity);
        }

        public IEnumerable<EnrollmentDto> GetAllEnrollments()
        {
            var entities = _enrollmentRepository.GetAll();
            return _mapper.Map<IEnumerable<EnrollmentDto>>(entities);
        }
    }
}
