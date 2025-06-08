// klasy
using System.ComponentModel.DataAnnotations.Schema;
namespace Kolokwium.Model.DataModels;
public class Ksiazka
{
    public int Id { get; set; }
    public string Tytul { get; set; }

    [ForeignKey("AutorId")]
    public int? AutorId { get; set; } //relacje wiele ksiazek do jednego autora
    public virtual Autor? Autor { get; set; }

    public virtual IList<Biblioteka> Biblioteki { get; set; } // relacje wiele ksiazek do wielu bibliotek

    public int WydawnictwoId { get; set; }
    public virtual Wydawnictwo Wydawnictwo { get; set; }
    public int RokWydania { get; set; }

}

// DbSet i modelBuilder
modelBuilder.Entity<Ksiazka>()
                .HasOne(k => k.Autor)
                .WithMany(a => a.Ksiazki)
                .HasForeignKey(k => k.AutorId);
modelBuilder.Entity<Biblioteka>()
    .HasOne(b => b.Dyrektor)
    .WithOne(d => d.Biblioteka)
    .HasForeignKey< Dyrektor >(d => d.BibliotekaId);
// migracje
// Interfaces
using Kolokwium.ViewModel.VM;
using System.Linq.Expressions;

namespace Kolokwium.Services.Interfaces
{
    public interface IKsiazkaService
    {
        IEnumerable<KsiazkiVm> GetKsiazki(Expression<Func<KsiazkiVm, bool>>? filter = null);
        KsiazkiVm AddKsiazka(AddKsiazkaVm addKsiazkaVm);
        KsiazkiVm DeleteKsiazka(int id);
    }
}

// ConcreteServices
using AutoMapper;
using Kolokwium.DAL;
using Kolokwium.Model.DataModels;
using Kolokwium.Services.Interfaces;
using Kolokwium.ViewModel.VM;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Kolokwium.Services.ConcreteServices
{
    public class KsiazkaService : BaseService, IKsiazkaService
    {
        public KsiazkaService(ApplicationDbContext dbContext, IMapper mapper, ILogger<KsiazkaService> logger)
            : base(dbContext, mapper, logger)
        {
        }

        public IEnumerable<KsiazkiVm> GetKsiazki(Expression<Func<KsiazkiVm, bool>>? filter = null)
        {
            var ksiazki = DbContext.Ksiazki.ToList();
            var ksiazkiVm = Mapper.Map<List<KsiazkiVm>>(ksiazki);

            if (filter != null)
            {
                return ksiazkiVm.AsQueryable().Where(filter).ToList();
            }
            return ksiazkiVm;
        }

        public KsiazkiVm AddKsiazka(AddKsiazkaVm addKsiazkaVm)
        {
            var ksiazka = Mapper.Map<Ksiazka>(addKsiazkaVm);
            DbContext.Ksiazki.Add(ksiazka);
            DbContext.SaveChanges();
            return Mapper.Map<KsiazkiVm>(ksiazka);
        }

        public KsiazkiVm DeleteKsiazka(int id)
        {
            var ksiazka = DbContext.Ksiazki.FirstOrDefault(k => k.Id == id);
            if (ksiazka == null)
                throw new Exception("Książka nie istnieje");

            DbContext.Ksiazki.Remove(ksiazka);
            DbContext.SaveChanges();
            return Mapper.Map<KsiazkiVm>(ksiazka);
        }
    }
}
// 7. AutoMapperProfiles
using AutoMapper;
using Kolokwium.Model.DataModels;
using Kolokwium.ViewModel.VM;
namespace Kolokwium.Services.Configuration.AutoMapperProfiles;
public class MainProfile : Profile
{
    public MainProfile()
    {
        CreateMap<Ksiazka, KsiazkiVm>()
             .ForMember(dest => dest.ImieNazwiskoAutora, opt => opt.MapFrom(src => src.Autor.Imie + " " + src.Autor.Nazwisko));
        CreateMap<AddKsiazkaVm, Ksiazka>()
            .ForMember(dest => dest.WydawnictwoId, opt => opt.MapFrom(src => src.WydawnictwoId));
    }
}
// VM
namespace Kolokwium.ViewModel.VM
{
    public class KsiazkiVm
    {
        public int Id { get; set; }
        public string Tytul { get; set; } = string.Empty;
        public string WydawnictwoNazwa { get; set; } = string.Empty;
        public int RokWydania { get; set; }
        public string ImieNazwiskoAutora { get; set; } = string.Empty;
        
    }
}
// Controller
using Microsoft.AspNetCore.Mvc;
using Kolokwium.Services.Interfaces;
namespace Kolokwium.Web.Controllers;

public class KsiazkaController : Controller
{
    private readonly IKsiazkaService _ksiazkaService;

    public KsiazkaController(IKsiazkaService ksiazkaService)
    {
        _ksiazkaService = ksiazkaService;
    }

    public IActionResult Index()
    {
        var ksiazki = _ksiazkaService.GetKsiazki();
        return View(ksiazki);
    }
}
using Microsoft.AspNetCore.Mvc;
using Kolokwium.Services.Interfaces;
using Kolokwium.ViewModel.VM;

namespace Kolokwium.Web.Controllers;

public class AddKsiazkaController : Controller
{
    private readonly IKsiazkaService _ksiazkaService;

    public AddKsiazkaController(IKsiazkaService ksiazkaService)
    {
        _ksiazkaService = ksiazkaService;
    }


    public IActionResult Add()
    {
        return View("~/Views/Ksiazka/Add.cshtml");
    }

    [HttpPost]
    public IActionResult Add(AddKsiazkaVm addKsiazkaVm)
    {
        if (ModelState.IsValid)
        {
            _ksiazkaService.AddKsiazka(addKsiazkaVm);
            return RedirectToAction("Index", "Ksiazka");
        }
        return View("~/Views/Ksiazka/Add.cshtml", addKsiazkaVm);
    }
}
using Microsoft.AspNetCore.Mvc;
using Kolokwium.Services.Interfaces;
using Kolokwium.ViewModel.VM;
namespace Kolokwium.Web.Controllers;
public class DeleteKsiazkaController : Controller
{
    private readonly IKsiazkaService _ksiazkaService;

    public DeleteKsiazkaController(IKsiazkaService ksiazkaService)
    {
        _ksiazkaService = ksiazkaService;
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var ksiazka = _ksiazkaService.DeleteKsiazka(id);
        if (ksiazka == null)
        {
            return NotFound();
        }
        return RedirectToAction("Index", "Ksiazka");
    }
}
// Views
@model IEnumerable<Kolokwium.ViewModel.VM.KsiazkiVm>
<h2>Książki</h2>
<table class="table">

<thead>
    <tr>
        <th>Tytuł</th>
        <th>Wydawnictwo</th>
        <th>Rok Wydania</th>
        <th>Imie Nazwisko Autora</th>
        <th>Usuń</th>
    </tr>
</thead>
<tbody>
    @foreach (var ksiazka in Model)
    {
        <tr>
            <td>@ksiazka.Tytul</td>
            <td>@ksiazka.WydawnictwoNazwa</td>
            <td>@ksiazka.RokWydania</td>
            <td>@ksiazka.ImieNazwiskoAutora</td>
            <td>
                <form asp-controller="DeleteKsiazka" asp-action="Delete" method="post">
                    <input type="hidden" name="id" value="@ksiazka.Id" />
                    <button type="submit" class="btn btn-danger">Usuń</button>
                </form>
            </td>
        </tr>
    }
</tbody>
</table>
<a  asp-controller="AddKsiazka" asp-action="Add">Dodaj książkę</a>
// Home
<a asp-controller="Ksiazka" asp-action="Index">Wszystkie Książki</a> <br>
// Program.cs
using Kolokwium.Services.Interfaces;
using Kolokwium.Services.ConcreteServices;
builder.Services.AddTransient<IKsiazkaService, KsiazkaService>();

//Add
@model Kolokwium.ViewModel.VM.AddKsiazkaVm

@{
    ViewData["Title"] = "Dodaj książkę";
}

<h2>Dodaj książkę</h2>

<form asp-action="Add" asp-controller="AddKsiazka" method="post">
    <div class="form-group">
        <label asp-for="Tytul"></label>
        <input asp-for="Tytul" class="form-control" />
        <span asp-validation-for="Tytul" class="text-danger"></span>
    </div>
    <div class="form-group">
        <label asp-for="AutorId"></label>
        <input asp-for="AutorId" class="form-control" />
        <span asp-validation-for="AutorId" class="text-danger"></span>
    </div>
    <div class="form-group">
        <label asp-for="WydawnictwoId"></label>
        <input asp-for="WydawnictwoId" class="form-control" />
        <span asp-validation-for="WydawnictwoId" class="text-danger"></span>
    </div>
    <button type="submit" class="btn btn-primary">Dodaj</button>
    <a asp-action="Index" asp-controller="Ksiazka" class="btn btn-secondary">Powrót</a>
</form>