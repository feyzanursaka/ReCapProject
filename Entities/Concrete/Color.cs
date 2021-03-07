using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Color : IEntity
    {
        public string ColurName { get; set; }
        public int ColorID { get; set; }
    }
}