﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto
    {
        public int CarId { get; set; }
        public string CarDescription { get; set; }
        public string BrandName { get; set; }
        public string ModelYear { get; set; }
    }
}
