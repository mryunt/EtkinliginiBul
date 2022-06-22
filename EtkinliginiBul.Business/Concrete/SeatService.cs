using EtkinliginiBul.Business.Abstract;
using EtkinliginiBul.DAL.Context;
using EtkinliginiBul.DAL.Dtos.Seat;
using EtkinliginiBul.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtkinliginiBul.Business.Concrete
{
    public class SeatService : ISeatService
    {
        public readonly EtkinliginiBulDbContext _etkinliginiBulDbContext;
        public SeatService(EtkinliginiBulDbContext etkinliginiBulDbContext)
        {
            _etkinliginiBulDbContext = etkinliginiBulDbContext;
        }

        public async Task<List<GetListSeatDto>> GetSeatList()
        {
            return await _etkinliginiBulDbContext.Seats.Where(p => !p.IsDeleted).Select(p => new GetListSeatDto
            {
                Id = p.Id,
                SeatNo = p.SeatNo,
                SeatPrice = p.SeatPrice
            }).ToListAsync();
        }
        public async Task<GetSeatDto> GetSeatById(int id)
        {
            return await _etkinliginiBulDbContext.Seats.Include(p => p.SalonFK).Where(p => !p.IsDeleted && p.Id == id).Select(p => new GetSeatDto
            {
                SalonId=p.SalonFK.Id,
                SeatNo = p.SeatNo,
                SeatPrice = p.SeatPrice
            }).FirstOrDefaultAsync();
        }
        public async Task<int> AddSeat(AddSeatDto addSeatDto)
        {
            var newSeat = new Seat
            {
                SalonID = addSeatDto.SalonId,
                SeatNo = addSeatDto.SeatNo,
                SeatPrice = addSeatDto.SeatPrice
            };
            await _etkinliginiBulDbContext.Seats.AddAsync(newSeat);
            return await _etkinliginiBulDbContext.SaveChangesAsync();
        }
        public async Task<int> UpdateSeat(int id, UpdateSeatDto updateSeatDto)
        {
            var currentSeat = await _etkinliginiBulDbContext.Seats.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentSeat != null)
            {
                currentSeat.SalonID = updateSeatDto.SalonId;
                currentSeat.SeatNo = updateSeatDto.SeatNo;
                currentSeat.SeatPrice = updateSeatDto.SeatPrice;
                currentSeat.MDate = DateTime.Now;
                _etkinliginiBulDbContext.Seats.Update(currentSeat);
                return await _etkinliginiBulDbContext.SaveChangesAsync();
            }
            return -1;
        }

        public async Task<int> DeleteSeat(int id)
        {
            var currentSeat = await _etkinliginiBulDbContext.Seats.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentSeat != null)
            {
                currentSeat.IsDeleted = true;
                return await _etkinliginiBulDbContext.SaveChangesAsync();
            }
            return -1;
        }



    }
}
