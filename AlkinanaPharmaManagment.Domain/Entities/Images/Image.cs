﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Domain.Entities.Images
{
    public class Image
    {
        public Guid Id { get; set; }
        public string Url { get; set; }

        public Image()
        {
            
        }
    }
}
