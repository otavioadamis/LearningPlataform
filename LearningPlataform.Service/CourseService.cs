using LearningPlataform.Domain.Interfaces;
using LearningPlataform.Domain.Models.DTOs;

namespace LearningPlataform.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public List<CourseResponseDTO> GetAll()
        {
            return _courseRepository.GetAll();
        }
    }
}
