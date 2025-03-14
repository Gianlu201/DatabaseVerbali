using Microsoft.EntityFrameworkCore;
using Progetto_S17_L5.Data;
using Progetto_S17_L5.Models;
using Progetto_S17_L5.ViewModels;

namespace Progetto_S17_L5.Services
{
    public class VerbalService
    {
        private readonly ApplicationDbContext _context;
        private readonly RegisterService _registerService;
        private readonly ViolationService _violationService;

        public VerbalService(
            ApplicationDbContext context,
            RegisterService registerService,
            ViolationService violationService
        )
        {
            _context = context;
            _registerService = registerService;
            _violationService = violationService;
        }

        private async Task<bool> TrySaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<VerbalsListViewModel> GetAllVerbalsAsync()
        {
            try
            {
                var violationsList = new VerbalsListViewModel();

                violationsList.Verbals = await _context
                    .Verbals.Include(v => v.Register)
                    .Include(v => v.VerbalViolations)
                    .ThenInclude(vv => vv.Violation)
                    .ToListAsync();

                return violationsList;
            }
            catch
            {
                return new VerbalsListViewModel() { Verbals = new List<Verbal>() };
            }
        }

        public async Task<RegistersListViewModel> GetAllRegistersAsync()
        {
            try
            {
                var registersList = await _registerService.GetAllRegistersAsync();

                return registersList;
            }
            catch
            {
                return new RegistersListViewModel() { Registers = new List<Register>() };
            }
        }

        public async Task<bool> AddVerbalAsync(AddVerbalViewModel addVerbalViewModel)
        {
            try
            {
                var newGuid = Guid.NewGuid();

                var verbal = new Verbal()
                {
                    VerbalId = newGuid,
                    VerbalDate = addVerbalViewModel.VerbalDate,
                    VerbalTranscriptionDate = addVerbalViewModel.VerbalTranscriptionDate,
                    VerbalAddress = addVerbalViewModel.VerbalAddress,
                    OfficerName = addVerbalViewModel.OfficerName,
                    Amount = addVerbalViewModel.Amount,
                    PointsDeduction = addVerbalViewModel.PointsDeduction,
                    RegisterId = addVerbalViewModel.RegisterId,
                };

                foreach (var violation in addVerbalViewModel.ViolationId)
                {
                    var verbalViolation = new VerbalViolation()
                    {
                        VerbalViolationId = Guid.NewGuid(),
                        ViolationId = violation,
                        VerbalId = newGuid,
                    };

                    _context.VerbalViolation.Add(verbalViolation);
                }

                _context.Verbals.Add(verbal);

                return await TrySaveChangesAsync();
            }
            catch
            {
                return false;
            }
        }

        public async Task<ViolationsListViewModel> GetAllViolationsAsync()
        {
            try
            {
                var violationsList = await _violationService.GetAllViolationsAsync();

                return violationsList;
            }
            catch
            {
                return new ViolationsListViewModel() { Violations = new List<Violation>() };
            }
        }
    }
}
