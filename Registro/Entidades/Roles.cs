using System.Windows.Input;
using System.ComponentModel.DataAnnotations;
namespace Registro
{
    public class Roles{
    
    [Key] public string? Rolid { get; set; }
        public string? Descripcion { get; set; }

        public string? Fecha { get; set; }

        

        public Roles (string? rolid, string? descripcion, string? fecha)
        {
            this.Rolid = rolid;
            this.Descripcion = descripcion;
            this.Fecha = fecha;
        }
        

    }
}