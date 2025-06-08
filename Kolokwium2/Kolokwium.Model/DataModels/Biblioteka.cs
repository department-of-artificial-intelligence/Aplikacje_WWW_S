using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Kolokwium.Model.DataModels;
public class Biblioteka
{
    public int Id { get; set; }
    public string Nazwa { get; set; }
    public string Adres { get; set; }
    public virtual IList<Ksiazka> Ksiazki { get; set; } // relacje wiele bibliotek do wielu ksiazek
}