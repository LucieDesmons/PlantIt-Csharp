using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.DTO
{
    public class RegisterModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        //public string? Godfather { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IdUserType { get; set; }
        public string? Degree { get; set; }
        public string? Specialization { get; set; }

        public int? AddressNumber { get; set; }
        public string? PostalCode { get; set; }
        public string? AddressWay { get; set; }
        public string? AdditionalAddress { get; set; }
        public string? AddressTown { get; set; }

        // tout le bordel de l'utilisateur lors de la création de compte
    }
}
