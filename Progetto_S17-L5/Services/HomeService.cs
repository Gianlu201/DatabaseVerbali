using Microsoft.EntityFrameworkCore;
using Progetto_S17_L5.Data;
using Progetto_S17_L5.Models;
using Progetto_S17_L5.ViewModels;

namespace Progetto_S17_L5.Services
{
    public class HomeService
    {
        private readonly ApplicationDbContext _context;

        public HomeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<OptionOneViewModel>> OptionOneAsync()
        {
            try
            {
                var verbalList = await _context
                    .Verbals.GroupBy(v => v.Register.RegisterId)
                    .Select(g => new
                    {
                        NVerbals = g.Count(),
                        TrasgressorName = g.Max(v => v.Register.Name),
                        TrasgressorSurnameName = g.Max(v => v.Register.Surname),
                        TrasgressorFiscalCode = g.Max(v => v.Register.FiscalCode),
                    })
                    .ToListAsync();

                var optionOneList = new List<OptionOneViewModel>();

                foreach (var item in verbalList)
                {
                    optionOneList.Add(
                        new OptionOneViewModel()
                        {
                            FiscalCode = item.TrasgressorFiscalCode,
                            Name = item.TrasgressorName,
                            Surname = item.TrasgressorSurnameName,
                            NVerbals = item.NVerbals,
                        }
                    );
                }

                return optionOneList;
            }
            catch
            {
                return new List<OptionOneViewModel>();
            }
        }

        public async Task<List<OptionTwoViewModel>> OptionTwoAsync()
        {
            try
            {
                var verbalList = await _context
                    .Verbals.GroupBy(v => v.Register.RegisterId)
                    .Select(g => new
                    {
                        TotPoints = g.Sum(v => v.PointsDeduction),
                        TrasgressorName = g.Max(v => v.Register.Name),
                        TrasgressorSurnameName = g.Max(v => v.Register.Surname),
                        TrasgressorFiscalCode = g.Max(v => v.Register.FiscalCode),
                    })
                    .ToListAsync();

                var optionOneList = new List<OptionTwoViewModel>();

                foreach (var item in verbalList)
                {
                    optionOneList.Add(
                        new OptionTwoViewModel()
                        {
                            FiscalCode = item.TrasgressorFiscalCode,
                            Name = item.TrasgressorName,
                            Surname = item.TrasgressorSurnameName,
                            TotPoints = item.TotPoints,
                        }
                    );
                }

                return optionOneList;
            }
            catch
            {
                return new List<OptionTwoViewModel>();
            }
        }

        public async Task<List<OptionThreeViewModel>> OptionThreeAsync()
        {
            try
            {
                var verbalList = await _context
                    .Verbals.Select(g => new
                    {
                        Points = g.PointsDeduction,
                        TrasgressorName = g.Register.Name,
                        TrasgressorSurnamename = g.Register.Surname,
                        VerbalDate = g.VerbalDate,
                        VerbalAmount = g.Amount,
                    })
                    .Where(v => v.Points > 10)
                    .ToListAsync();

                var optionOneList = new List<OptionThreeViewModel>();

                foreach (var item in verbalList)
                {
                    optionOneList.Add(
                        new OptionThreeViewModel()
                        {
                            Amount = item.VerbalAmount,
                            Name = item.TrasgressorName,
                            Surname = item.TrasgressorSurnamename,
                            ViolationDate = item.VerbalDate,
                            Points = item.Points,
                        }
                    );
                }

                return optionOneList;
            }
            catch
            {
                return new List<OptionThreeViewModel>();
            }
        }

        public async Task<List<OptionFourViewModel>> OptionFourAsync()
        {
            try
            {
                var verbalList = await _context
                    .Verbals.Select(g => new
                    {
                        VerbalId = g.VerbalId,
                        TrasgressorName = g.Register.Name,
                        TrasgressorSurnamename = g.Register.Surname,
                        TrasgressorFiscalCode = g.Register.FiscalCode,
                        VerbalAmount = g.Amount,
                        VerbalDate = g.VerbalDate,
                    })
                    .Where(v => v.VerbalAmount > 400)
                    .ToListAsync();

                var optionOneList = new List<OptionFourViewModel>();

                foreach (var item in verbalList)
                {
                    optionOneList.Add(
                        new OptionFourViewModel()
                        {
                            VerbalId = item.VerbalId,
                            Name = item.TrasgressorName,
                            Surname = item.TrasgressorSurnamename,
                            FiscalCode = item.TrasgressorFiscalCode,
                            ViolationDate = item.VerbalDate,
                            Amount = item.VerbalAmount,
                        }
                    );
                }

                return optionOneList;
            }
            catch
            {
                return new List<OptionFourViewModel>();
            }
        }
    }
}
