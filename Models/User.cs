using D3___Avaliação.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3___Avaliação.Models
{
    internal class User
    {
        public string IdUser { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Pwd { get; set; } = string.Empty;
    }
}
