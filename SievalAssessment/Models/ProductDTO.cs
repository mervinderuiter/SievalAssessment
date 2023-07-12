using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SievalAssessment.Models
{
    public class ProductDTO
    {
        public string? SKU { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }

    }
}