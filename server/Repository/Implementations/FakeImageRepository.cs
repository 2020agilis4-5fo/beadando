using Data;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class FakeImageRepository : ICrudRepository<ImagehubImage>
    {
        private string _imageFodlerPath; 

        public FakeImageRepository()
        {
            var basePath = Directory.GetParent(Environment.CurrentDirectory).FullName;
            _imageFodlerPath = Path.Combine(Path.Combine(basePath, "Repository"), "TempImages");
        }
        public async Task CreateAsync(ImagehubImage newEntry)
        {
            this.SaveimageFromBase64Encoded(newEntry.Base64EncodedImage, newEntry.FileName);
        }

        public Task DeleteAsync(ImagehubImage deletee)
        {
            throw new NotImplementedException();
        }

        public async Task<ImagehubImage> GetElementAsync(int id)
        {
            var imgUris = Directory.GetFiles(_imageFodlerPath, "*.jpg");
            var randomImage = imgUris[id % imgUris.Length]; // simple solution based on the circular buffer pattern
            var converted = ConvertImageFromPathToBase64String(randomImage);
            return await Task.FromResult(new ImagehubImage()
            {
                FileName = Path.GetFileName(randomImage),
                Base64EncodedImage = ConvertImageFromPathToBase64String(randomImage)
            });
        }

        public async Task<IEnumerable<ImagehubImage>> GetElementsAsync()
        {          
            var imageUris = Directory.GetFiles(_imageFodlerPath, "*.jpg");
            return await Task.FromResult(imageUris.Select(uri => new ImagehubImage()
            {
                FileName = Path.GetFileName(uri),
                Base64EncodedImage = ConvertImageFromPathToBase64String(uri)
            }));
        }

        public Task UpdateAsync(ImagehubImage updatee)
        {
            throw new NotImplementedException();
        }

        private string ConvertImageFromPathToBase64String(string path)
        {
            var imgBytes = File.ReadAllBytes(path);
            return Convert.ToBase64String(imgBytes);
        }

        private void SaveimageFromBase64Encoded(string base64Encoded, string fileName)
        {
            // based on https://stackoverflow.com/questions/5400173/converting-a-base-64-string-to-an-image-and-saving-it
            var imagePath = Path.Combine(_imageFodlerPath, fileName);
            File.WriteAllBytes(imagePath, Convert.FromBase64String(base64Encoded));
        }
    }
}
