using System.ComponentModel.DataAnnotations;

namespace CSV2Sql.Models;

public class Journal
{
    public int Id { get; set; }

    [Display(Name = "عنوان")]
    public string Title { get; set; }

    [Display(Name = "شاپا")]
    public string ISSN { get; set; }

    [Display(Name = "شاپای الکترونیکی")]
    public string EISSN { get; set; }

    [Display(Name = "زبان")]
    public string Language { get; set; }

    [Display(Name = "کشور")]
    public string Country { get; set; }

    [Display(Name = "استان")]
    public string Province { get; set; }

    [Display(Name = "ناشر")]
    public string Publisher { get; set; }

    public int YearId { get; set; }
    public virtual Year Year { get; set; }

    public virtual ICollection<Quality> Qualities { get; set; }
}

