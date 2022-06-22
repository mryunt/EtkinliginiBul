using AppCore.Entity;
using EtkinliginiBul.DAL.Dtos.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtkinliginiBul.Business.Abstract
{
    public interface IImagesService : IEntity
    {
        public Task<List<GetListImagesDto>> GetImagesList();
        public Task<GetImagesDto> GetImagesById(int id);
        public Task<int> AddImages(AddImagesDto addImagesDto);
        public Task<int> UpdateImages(int id, UpdateImagesDto updateImagesDto);
        public Task<int> DeleteImages(int id);
    }
}
