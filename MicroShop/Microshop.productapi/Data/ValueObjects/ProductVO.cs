using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microshop.productapi.Data.ValueObjects
{
    public class ProductVO
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Categoryname { get; set; }

        public string imagage_url { get; set; }
    }
}
