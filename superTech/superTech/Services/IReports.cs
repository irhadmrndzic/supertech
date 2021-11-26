
using superTech.Models.ReportsModel;

namespace superTech.Services
{
   public interface IReports
    {
        public ReportsModel GetReports(ReportsSearchRequest request);
    }
}
