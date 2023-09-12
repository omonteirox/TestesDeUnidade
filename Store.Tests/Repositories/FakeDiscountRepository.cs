﻿using Store.Domain.Entities;
using Store.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests.Repositories
{
    public class FakeDiscountRepository : IDiscountRepository
    {
        public Discount Get(string code)
        {
            if (code.Equals("12345678"))
                return new Discount(10, DateTime.Now.AddDays(5));
            if (code.Equals("11111111"))
                return new Discount(10, DateTime.Now.AddDays(-5));
            return null;
        }
    }
}