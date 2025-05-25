using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;

namespace SchoolRegister.Services.ConcreteServices
{
    public abstract class BaseService
    {
        protected readonly ApplicationDbContext DbContext = null!;
        protected readonly ILogger Logger = null!;
        protected readonly IMapper Mapper = null!;
        public BaseService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger)
        {
            DbContext = dbContext;
            Logger = logger;
            Mapper = mapper;
        }
    }
}