using System.ComponentModel.DataAnnotations;

namespace WeVsVirus.Business.ViewModels
{
    public class PrimitiveViewModel<T>
    {
        [Required(ErrorMessage = "Ungültige Eingabe")]
        public T Data { get; set; }
    }
}
