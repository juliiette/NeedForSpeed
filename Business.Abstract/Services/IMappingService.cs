using Business.Models;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract.Services
{
    public interface IMappingService
    {
        DetailModel Map(Detail detail);

        Detail Map(DetailModel detailModel);
    }
}
