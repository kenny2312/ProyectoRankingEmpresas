using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityModel.MClass
{
    public class Cargos
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Key]
        public string Guid { get; set; }

        [StringLength(20)]
        public string Code { get; set; }

        [StringLength(55)]
        public string Name { get; set; }

        public DateTime CreationDate { get; set; }
        
        public int remuneraciones { get; set; }

        public string EmpresaId{ get; set; }
        [ForeignKey("EmpresaId")]
        public virtual Empresa EmpresaR{ get; set; }

        //  public virtual Remuneracion rem { get; set; }

        #region atributos de la clase
        //id
        //guid
        //cargo
        //remuneracion total +sueldo base + bonos +
        //remuneracion sueldo base
        //remuneracion alimatacion
        //remuneracion horas extra
        //remuneracion bono navideño
        //remuneracion iies
        //remuenracion transporte 
        //remuneracion para los uniformes 
        //
        #endregion


    }
}
