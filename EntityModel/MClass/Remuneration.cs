using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityModel.MClass
{
    class Remuneration
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]

        //id de la Renumeration 
        public string Guid { get; set; }
        
        //sueldo base
        public string Base_salary { get; set; }
        
        //remuneracion alimatacion
        public string Power_Supply { get; set; }

        //remuneracion horas extra
        public string Extra_Hours { get; set; }

        //remuneracion bono navideño
        public string Christmas_Bonus { get; set; }

        public string IEES { get; set; }

        public string Transport { get; set; }

        public string Uniforms { get; set; }
        
        //remuneracion iies
        //remuenracion transporte 
        //remuneracion para los uniformes 

    }
}
