using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.business.Extentions
{
    public static class Helper
    {
        public static string SaveFile(this IFormFile ImageFile, string rootpath, string foldername)
        {
            string filename=ImageFile.FileName.Length>64
                ?ImageFile.FileName.Substring(ImageFile.FileName.Length-64,64) //64  
                :ImageFile.FileName;
            filename=Guid.NewGuid().ToString()+filename;  //7fhfh356e3vddgdf7474e9bgfghfhdh37 74fhvgvhfyr47474fbfbfbb
            string path=Path.Combine(rootpath,foldername, filename);
            using(FileStream stream=new FileStream(path,FileMode.Create))
            {
                ImageFile.CopyTo(stream);
            }
            return filename;
        }
        public static void DeleteFile(string rootpath,string foldername,string ImageUrl)
        {
            string deletepath = Path.Combine(rootpath, foldername, ImageUrl);
            if(File.Exists(deletepath)) 
            {
                File.Delete(deletepath);
            }
        }
    }
}
