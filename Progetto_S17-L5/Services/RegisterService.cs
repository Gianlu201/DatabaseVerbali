using Microsoft.EntityFrameworkCore;
using Progetto_S17_L5.Data;
using Progetto_S17_L5.Models;
using Progetto_S17_L5.ViewModels;

namespace Progetto_S17_L5.Services
{
    public class RegisterService
    {
        private readonly ApplicationDbContext _context;

        public RegisterService(ApplicationDbContext context)
        {
            _context = context;
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

        public async Task<RegistersListViewModel> GetAllRegistersAsync()
        {
            try
            {
                var registersList = new RegistersListViewModel();

                registersList.Registers = await _context.Registers.ToListAsync();

                return registersList;
            }
            catch
            {
                return new RegistersListViewModel() { Registers = new List<Register>() };
            }
        }

        public async Task<bool> AddRegisterAsync(AddRegisterViewModel addRegisterViewModel)
        {
            try
            {
                string fileName = "default.png";
                var webPath = Path.Combine("uploads", "images", fileName);

                if (addRegisterViewModel.Picture != null)
                {
                    fileName = addRegisterViewModel.Picture.FileName;

                    var path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot",
                        "uploads",
                        "images",
                        fileName
                    );

                    await using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await addRegisterViewModel.Picture.CopyToAsync(stream);
                    }

                    webPath = Path.Combine("uploads", "images", fileName);
                }

                var register = new Register()
                {
                    RegisterId = Guid.NewGuid(),
                    Name = addRegisterViewModel.Name,
                    Surname = addRegisterViewModel.Surname,
                    Address = addRegisterViewModel.Address,
                    City = addRegisterViewModel.City,
                    CAP = addRegisterViewModel.CAP,
                    FiscalCode = addRegisterViewModel.FiscalCode,
                    Picture = webPath,
                };

                _context.Registers.Add(register);

                return await TrySaveChangesAsync();
            }
            catch
            {
                return false;
            }
        }

        public async Task<EditRegisterViewModel> GetRegisterByIdAsync(Guid id)
        {
            try
            {
                var register = _context.Registers.FirstOrDefault(r => r.RegisterId == id);

                if (register == null)
                {
                    return new EditRegisterViewModel()
                    {
                        Name = "",
                        Surname = "",
                        Address = "",
                        CAP = "",
                        City = "",
                        FiscalCode = "",
                    };
                }

                var selectedRegister = new EditRegisterViewModel()
                {
                    RegisterId = register.RegisterId,
                    Name = register.Name,
                    Surname = register.Surname,
                    Address = register.Address,
                    City = register.City,
                    CAP = register.CAP,
                    FiscalCode = register.FiscalCode,
                    PictureUrl = register.Picture,
                };

                return selectedRegister;
            }
            catch
            {
                return new EditRegisterViewModel()
                {
                    Name = "",
                    Surname = "",
                    Address = "",
                    CAP = "",
                    City = "",
                    FiscalCode = "",
                };
            }
        }

        public async Task<bool> EditRegisterAsync(EditRegisterViewModel editRegisterViewModel)
        {
            try
            {
                var register = _context.Registers.FirstOrDefault(r =>
                    r.RegisterId == editRegisterViewModel.RegisterId
                );

                if (register == null)
                {
                    return false;
                }

                register.Name = editRegisterViewModel.Name;
                register.Surname = editRegisterViewModel.Surname;
                register.FiscalCode = editRegisterViewModel.FiscalCode;
                register.Address = editRegisterViewModel.Address;
                register.City = editRegisterViewModel.City;
                register.CAP = editRegisterViewModel.CAP;

                if (editRegisterViewModel.Picture != null)
                {
                    var fileName = editRegisterViewModel.Picture.FileName;

                    var path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot",
                        "uploads",
                        "images",
                        fileName
                    );

                    await using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await editRegisterViewModel.Picture.CopyToAsync(stream);
                    }

                    var webPath = Path.Combine("uploads", "images", fileName);

                    register.Picture = webPath;
                }

                return await TrySaveChangesAsync();
            }
            catch
            {
                return false;
            }
        }
    }
}
