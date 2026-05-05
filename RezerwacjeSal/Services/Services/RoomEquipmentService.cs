using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class RoomEquipmentService : IRoomEquipmentService
{
    private readonly AppDbContext _context; 

    public RoomEquipmentService(AppDbContext context)
    {
        _context = context;
    }


}