using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legendary.Data.Models.Video
{
    public class VideoDB
    {
        public string VideoId { get; set; }
        public string VideoName { get; set; }
        public string ImgId { get; set; }
        public byte Rating { get; set; }
        public DateTime DateCreate { get; set; }
    }
}