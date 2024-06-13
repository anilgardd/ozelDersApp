using OzelDersApp.Business.Abstract;
using OzelDersApp.Data.Abstract;
using OzelDersApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OzelDersApp.Business.Concrete
{
    public class ImageManager : IImageService
    {
        private IImageRepository _imageRepository;

        public ImageManager(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task CreateAsync(Image image)
        {
            await _imageRepository.CreateAsync(image);
        }

        public void Delete(Image image)
        {
            _imageRepository.Delete(image);
        }

        public async Task<List<Image>> GetAllAsync()
        {
            return await _imageRepository.GetAllAsync();    
        }

        public async Task<Image> GetByIdAsync(int id)
        {
            return await _imageRepository.GetByIdAsync(id);
        }


        public void Update(Image image)
        {
            _imageRepository.Update(image);
        }
    }
}
