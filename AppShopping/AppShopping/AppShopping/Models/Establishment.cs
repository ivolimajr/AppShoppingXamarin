﻿using AppShopping.Libraries.Enums;

namespace AppShopping.Models
{
    public class Establishment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Logo { get; set; }
        public EstablishmentType Type { get; set; }
    }
}
