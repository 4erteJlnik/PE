using PE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE.Services
{
    public interface IFileService
    {
        Picture GetAvatar(People people);
        Picture GetAvatar(Guid people);
        Picture GetFirstPostPicture(Post post);
        Picture GetFirstPostPicture(Guid post);
        List<Picture> GetOtherPostPicture(Post post);
        List<Picture> GetOtherPostPicture(Guid post);
        void SetAvatar(Picture picture);
        void SetPostFirstPicture(Picture picture, Guid Author);
        void SetPostOtherPictures(IEnumerable<Picture> pictures, Guid Author);


    }
}
