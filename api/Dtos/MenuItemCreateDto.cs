using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class MenuItemCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Category_Id { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Image_Url { get; set; } = string.Empty;
        public string Tag { get; set; } = string.Empty;
    }
}