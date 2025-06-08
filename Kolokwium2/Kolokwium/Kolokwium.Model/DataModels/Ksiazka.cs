using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Kolokwium.Model.DataModels;
public class Ksiazka
{
    public int Id { get; set; }
    public string Tytul { get; set; }

    [ForeignKey("AutorId")]
    public int AutorId { get; set; } //relacje wiele ksiazek do jednego autora
    public virtual Autor Autor { get; set; }

    public virtual IList<Biblioteka> Biblioteki { get; set; } // relacje wiele ksiazek do wielu bibliotek

    public int WydawnictwoId { get; set; }
    public virtual Wydawnictwo Wydawnictwo { get; set; }
    public int RokWydania { get; set; }

}