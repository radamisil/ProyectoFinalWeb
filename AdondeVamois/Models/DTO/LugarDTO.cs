using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdondeVamos.Models.DTO
{
    public class LugarDTO
    {
        [Required]
        public int IdLugar { get; set; }

        public string Nombre { get; set; }

        public int Capacidad { get; set; }
    }
}