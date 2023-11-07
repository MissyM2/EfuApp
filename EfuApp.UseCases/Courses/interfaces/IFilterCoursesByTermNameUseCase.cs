using EfuApp.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfuApp.UseCases.Courses
{
    public interface IFilterCoursesByTermNameUseCase
    {
        Task<IEnumerable<Course>> ExecuteAsync(string termName = "");
    }
}
