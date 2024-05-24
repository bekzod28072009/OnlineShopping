﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UzumMarket.Domain.Common;
using UzumMarket.Domain.Enums;

namespace UzumMarket.Domain.Entity
{
    public class Order : Auditable
    {
        public decimal TotalAmount { get; set; }
        public List<Item> Items { get; set; }
        public OrderStatus Status { get; set; }
        public string ShippingAddress { get; set; }
        public string PaymentMethod { get; set; }
    }
}
