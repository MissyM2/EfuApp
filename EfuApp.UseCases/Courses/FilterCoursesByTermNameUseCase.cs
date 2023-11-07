using EfuApp.CoreBusiness;
using EfuApp.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfuApp.UseCases.Courses
{
    public class FilterCoursesByTermNameUseCase : IFilterCoursesByTermNameUseCase
    {
        private readonly ICourseRepository courseRepository;

        public FilterCoursesByTermNameUseCase(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public async Task<IEnumerable<Course>> ExecuteAsync(string termName = "")
        {
            return await courseRepository.GetCoursesByNameAsync(termName);
        }
    }
}
