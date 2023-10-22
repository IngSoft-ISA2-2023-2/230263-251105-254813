using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaGo.Exceptions;

namespace PharmaGo.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Pharmacy? Pharmacy { get; set; }

        public void ValidProduct()
        {
            ValidName();
            ValidCode();
            ValidDescription();   
        }

        private void ValidDescription()
        {
            if (string.IsNullOrEmpty(Description) || Description.Length > 70)
            {
                throw new InvalidDescriptionException("La descripción de un producto no puede ser vacía ni con más de 70 caracteres");
            }
        }

        private void ValidCode()
        {
            if (Code.GetType().Equals(typeof(int)) && Code.ToString().Length != 5)
            {
                throw new InvalidCodeException("El código del producto debe ser númerico de 5 dígitos");
            }
        }

        private void ValidName()
        {
            if (Name.Length <= 0 || Name.Length > 30) // Hasta 30
            {
                throw new InvalidNameException("El nombre del procuto debe ser de 30 caracteres");
            }
        }
    }
}
