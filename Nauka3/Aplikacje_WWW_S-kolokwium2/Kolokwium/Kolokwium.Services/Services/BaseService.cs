using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kolokwium.DAL;

namespace Kolokwium.Services.Services
{
    public abstract class BaseService
    {
        protected readonly ApplicationDbContext _dbContext;
        protected readonly IMapper _mapper;

        public BaseService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

    }
}
