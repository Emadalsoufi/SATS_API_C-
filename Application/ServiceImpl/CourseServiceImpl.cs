using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.IRepository;
using System;
using System.Collections.Generic;

namespace SATS.Application.ServiceImpl
{
    public class CourseServiceImpl : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseServiceImpl(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public void CreateCourse(CourseDto courseDto)
        {
            if (courseDto is null) throw new ArgumentNullException(nameof(courseDto));
            var entity = _mapper.Map<Course>(courseDto);
            _courseRepository.Add(entity);
        }

        public void UpdateCourse(CourseDto courseDto)
        {
            if (courseDto is null) throw new ArgumentNullException(nameof(courseDto));
            var existing = _courseRepository.GetById(courseDto.CourseId);
            if (existing is null) throw new ArgumentException("Course was not found.", nameof(courseDto));
            _mapper.Map(courseDto, existing);
            _courseRepository.Update(existing);
        }

        public CourseDto? GetCourseById(int id)
        {
            var entity = _courseRepository.GetById(id);
            return entity is null ? null : _mapper.Map<CourseDto>(entity);
        }

        public IEnumerable<CourseDto> GetAllCourses()
        {
            var entities = _courseRepository.GetAll();
            return _mapper.Map<IEnumerable<CourseDto>>(entities);
        }
    }
}
