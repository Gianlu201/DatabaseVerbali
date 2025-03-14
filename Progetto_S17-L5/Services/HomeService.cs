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
                //var verbalsList = await _context.Verbals.GroupBy(r => r.RegisterId).ToListAsync();
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
    }
}
