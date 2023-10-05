using Tarea.Model.Entities;

namespace Tarea.Model.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<ClaseModel> Clase { get; set; } = null!;
    }

    public class ClaseModel
    {

        public int id { get; set; }
        public string nombre { get; set; } = null!;
        public string descripcion { get; set; } = null!;
    }



}
