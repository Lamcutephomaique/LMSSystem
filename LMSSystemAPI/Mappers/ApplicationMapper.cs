using AutoMapper;
using LMSSystemAPI.Dtos;
using LMSSystemAPI.Models;

namespace LMS.Mappers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() 
        {
            CreateMap<RoleDto, Role>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<ClassDto, Class>().ReverseMap();
            CreateMap<FacultyDto, Faculty>().ReverseMap();
            CreateMap<TeacherDto, Teacher>().ReverseMap();
            CreateMap<CourseDto, Course>().ReverseMap();
            CreateMap<ExamDto, Exam>().ReverseMap();
            CreateMap<QuesstionDto, Question>().ReverseMap();
            CreateMap<AnswerDto, Answer>().ReverseMap();
            CreateMap<TopicDto, Topic>().ReverseMap();
            CreateMap<LessonDto, Lesson>().ReverseMap();
            CreateMap<NotificationDto, Notification>().ReverseMap();
            CreateMap<UserCourseDto, UserCourse>().ReverseMap();

        }

    }
}
