﻿using DEVUXC_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVUXC_HFT_2022231.Repository.Interfaces
{
    public interface IDriverRepository : IRepository<Driver>
    {
        void UpdateDriverNumber(int id, int NewNumber);
    }
}