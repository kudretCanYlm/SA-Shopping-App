using SA.Domain.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Application.Contracts.Dtos.Media.Image
{
    public class CreateImageDto
    {
        public string Base64Image { get; set; }
        public ImageTypesEnum ImageType { get; set; }
        public Guid ImageOwnerId { get; set; }
    }
}
