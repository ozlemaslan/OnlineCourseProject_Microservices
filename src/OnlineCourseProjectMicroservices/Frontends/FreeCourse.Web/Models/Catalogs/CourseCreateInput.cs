using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FreeCourse.Web.Models.Catalogs
{
    public class CourseCreateInput
    {
        [Display(Name="Kurs adı")]
        public string Name { get; set; }
        [Display(Name = "Kurs açıklama")]
        public string Description { get; set; }
        [Display(Name = "Kurs ücreti")]
        public decimal Price { get; set; }
        public string Picture { get; set; }
        public string UserId { get; set; }
        public FeatureViewModel Feature { get; set; }
        [Display(Name = "Kurs categori")]
        public string CategoryId { get; set; }
        [Display(Name = "Kurs Resim")]
        public IFormFile PhotoFormFile { get; set; }
    }
}
