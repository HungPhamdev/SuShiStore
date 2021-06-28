using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Interfaces
{
    public interface IUploadHelper
    {
        void UploadImage(IFormFile file, string rootPath, string phanLoai);
        void RemoveImage(string filePath);
    }
}
