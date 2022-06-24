using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Web1.Domain;
using Web1.Infrastructure;

namespace Web1.Services
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