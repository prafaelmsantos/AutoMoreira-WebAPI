using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMoreira.API.Models
{
    public class Modelo
    {
        public Modelo()
        {
                
        }


        public Modelo(int modeloId, string modeloNome)
        {
            ModeloId = modeloId;
            ModeloNome = modeloNome;
            
        }

        public int ModeloId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Nome do Modelo")]
        public string ModeloNome { get; set; }


    }
}
