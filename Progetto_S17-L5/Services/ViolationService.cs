using Microsoft.EntityFrameworkCore;
using Progetto_S17_L5.Data;
using Progetto_S17_L5.Models;
using Progetto_S17_L5.ViewModels;

namespace Progetto_S17_L5.Services
{
    public class ViolationService
    {
        private readonly ApplicationDbContext _context;

        public ViolationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ViolationsListViewModel> GetAllViolationsAsync()
        {
            try
            {
                var violationsList = new ViolationsListViewModel();

                violationsList.Violations = await _context.Violations.ToListAsync();

                return violationsList;
            }
            catch
            {
                return new ViolationsListViewModel() { Violations = new List<Violation>() };
            }
        }
    }
}
