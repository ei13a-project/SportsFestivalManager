using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SportsFestivalManager.Data
{
    [Table("Teacher")]
    public class Teacher : Person
    {
        public int IdentificationNumber { get; set; }

        [Column("Signature")]
        public byte[] SignatureBytes { get; private set; }

        [NotMapped]
        public Image Signature
        {
            get { return SignatureBytes == null ? null : ByteArrayToImage(SignatureBytes); }
            set { SignatureBytes = ImageToByteArray(value); }
        }

        public Teacher()
        {
        }

        public static byte[] ImageToByteArray(Image image)
        {
            using (var memory = new MemoryStream())
            {
                image.Save(memory, ImageFormat.Png);
                return memory.ToArray();
            }
        }
        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (var memory = new MemoryStream(byteArrayIn))
                return Image.FromStream(memory);
        }
    }
}