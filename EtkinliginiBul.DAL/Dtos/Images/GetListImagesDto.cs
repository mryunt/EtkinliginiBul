﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtkinliginiBul.DAL.Dtos.Images
{
    public class GetListImagesDto
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int EventID { get; set; }
    }
}
