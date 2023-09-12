﻿using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Repositories
{
    public interface IDiscountRepository
    {
        Discount Get(string code);
    }
}