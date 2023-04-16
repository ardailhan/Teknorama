namespace TeknoramaUI.Managers
{
    public static class FileManager
    {
        public static string GetUniqueNameAndSavePhotoToDisk(this IFormFile pictureFile, IWebHostEnvironment webHostEnvironment)
        {
            string uniqueFileName = default;
            if (pictureFile != null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + pictureFile.Name;

                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");

                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    pictureFile.CopyToAsync(fileStream);
                }
            }
            return uniqueFileName;
        }

        public static void RemoveImageFromDisk(string imageName, IWebHostEnvironment webHostEnvironment)
        {
            if (!string.IsNullOrEmpty(imageName))
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                string filePath = Path.Combine(uploadsFolder, imageName);
                File.Delete(filePath);
            }
        }
    }
}
