﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMoreira.API.Models
{
    public class Marca
    {
        public Marca()
        {

        }

        public Marca(int marcaId, string marcaNome)
        {
            MarcaId = marcaId;
            MarcaNome = marcaNome;
        }

        [Key]
        public int MarcaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Nome da Marca")]
        public string MarcaNome { get; set; }

    }
}
