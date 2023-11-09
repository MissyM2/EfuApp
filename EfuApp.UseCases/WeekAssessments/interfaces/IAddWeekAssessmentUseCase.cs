using EfuApp.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfuApp.UseCases.WeekAssessments
{
    public interface IAddWeekAssessmentUseCase
    {
        Task ExecuteAsync(WeekAssessment weekAssessment);
    }
}
