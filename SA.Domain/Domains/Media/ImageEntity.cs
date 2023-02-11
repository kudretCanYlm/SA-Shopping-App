using SA.Domain.Base;
using SA.Domain.Base.Enums;

namespace SA.Domain.Domains.Media
{
    public class ImageEntity : BaseEntity
    {
        public ImageEntity() : base()
        {

        }

        public string FileExtension { get; set; }
        public byte[] ImageData { get; set; }

        public ImageTypesEnum ImageType { get; set; }
        public Guid ImageOwnerId { get; set; }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return FileExtension;
            yield return ImageData;
        }

        public static string ToBase64Image(ImageEntity imageEntity)
        {
            string base64 = "data:" + imageEntity.FileExtension + ";base64," + Convert.ToBase64String(imageEntity.ImageData);

            return base64;
        }

        public static string ToImageFileExtension(string base64)
        {
            return base64.Split(';')[0].Substring(5);
        }

        public static byte[] ToByteArrayImage(string base64)
        {
            return Convert.FromBase64String(base64.Split(',')[1]);
        }
    }
}
