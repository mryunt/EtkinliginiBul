using EtkinliginiBul.Business.Abstract;
using EtkinliginiBul.DAL.Context;
using EtkinliginiBul.DAL.Dtos.Images;
using EtkinliginiBul.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtkinliginiBul.Business.Concrete
{
    public class ImagesService : IImagesService
    {
        public readonly EtkinliginiBulDbContext _etkinliginiBulDbContext;
        public ImagesService(EtkinliginiBulDbContext etkinliginiBulDbContext)
        {
            _etkinliginiBulDbContext = etkinliginiBulDbContext;
        }
        public async Task<List<GetListImagesDto>> GetImagesList()
        {
            return await _etkinliginiBulDbContext.Imagesses.Include(p => p.EventFK).Where(p => !p.IsDeleted).Select(p => new GetListImagesDto
            {
                Id = p.Id,
                Image = p.Image,
                EventID = p.EventFK.Id
            }).ToListAsync();
        }
        public async Task<GetImagesDto> GetImagesById(int id)
        {
            return await _etkinliginiBulDbContext.Imagesses.Include(p => p.EventFK).Where(p => !p.IsDeleted && p.Id == id).Select(p => new GetImagesDto
            {
                Image = p.Image,
                EventID = p.EventFK.Id
            }).FirstOrDefaultAsync();
        }
        public async Task<int> AddImages(AddImagesDto addImagesDto)
        {
            var newImage = new Images
            {
                Image = addImagesDto.Image,
                EventID = addImagesDto.EventID
            };
            await _etkinliginiBulDbContext.Imagesses.AddAsync(newImage);
            return await _etkinliginiBulDbContext.SaveChangesAsync();
        }
        public async Task<int> UpdateImages(int id, UpdateImagesDto updateImagesDto)
        {
            var currentImage = await _etkinliginiBulDbContext.Imagesses.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentImage != null)
            {
                currentImage.EventID=updateImagesDto.EventID;
                currentImage.Image = updateImagesDto.Image;
                currentImage.MDate = DateTime.Now;
                _etkinliginiBulDbContext.Imagesses.Update(currentImage);
                return await _etkinliginiBulDbContext.SaveChangesAsync();
            }
            return -1;
        }

        public async Task<int> DeleteImages(int id)
        {
            var currentImage = await _etkinliginiBulDbContext.Imagesses.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentImage != null)
            {
                currentImage.IsDeleted = true;
                return await _etkinliginiBulDbContext.SaveChangesAsync();
            }
            return -1;
        }



    }
}
