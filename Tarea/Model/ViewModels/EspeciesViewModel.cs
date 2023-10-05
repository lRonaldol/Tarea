using System.Collections.Generic;
using Tarea.Model.Entities;

namespace Tarea.Model.ViewModels
{
    public class EspeciesViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string descripcion { get; set; } = null!;

        public ICollection<Especies> Especies { get; set; } = null!;
    }
   
 
}
