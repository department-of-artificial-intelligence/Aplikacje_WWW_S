using AutoMapper;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public abstract class BaseService
    {
        protected readonly AppDbContext _dbContext;

        protected readonly IMapper _mapper;
        public BaseService(IMapper mapper, AppDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
    }
}
