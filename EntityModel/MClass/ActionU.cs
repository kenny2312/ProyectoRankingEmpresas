using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModel.MClass
{
    public class ActionU
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Valor { get; set; }
       
       
        public int GroupId { get; set; }
        public GrupoUser Group { get; set; }
       

    }
}