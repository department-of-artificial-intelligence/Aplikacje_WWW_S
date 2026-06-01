using AutoMapper;
using Kolokwium.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
