using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Kolokwium.Model.DataModels;
public class Autor
{
    public int Id { get; set; }
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public string Biografia { get; set; }

    public virtual IList<Ksiazka> Ksiazki { get; set; } // relacje jeden autor do wielu ksiazek
}