using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL;

namespace Services.Services
{
    public abstract class BaseService
    {
        protected readonly AppDbContext _dbContext;
        protected readonly IMapper _mapper;

        public BaseService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
    }
}
