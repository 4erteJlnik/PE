using PE.Entity;
using PE.Infrastructure.Data;
using PE.Infrastructure.DTO;
using PE.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PE.Services
{
    public class FileService : IFileService
    {
        IFileRepository _File;
        IPostRepository _postRepository;
        FTPlink server { get; }
        bool FTP { get; set; }
        public FileService(IFileRepository fileReposiry, IPostRepository postRepository)
        {
            FTPlink Server = null;
            _File = fileReposiry;
            _postRepository = postRepository;
            if (Server != null)
            {
                server = Server;
                FTP = true;
            }
            else
            {
                FTP = false;
            }
        }
        public Picture GetAvatar(People people)
        {
            Filedto file = _File.GetAvatar(people.ID).Result;
            return new Picture
            {
                filename = file.ID,
                file = read(file.ID.ToString())
            };
        }
        public Picture GetAvatar(Guid people)
        {
            Filedto file = _File.GetAvatar(people).Result;
            return new Picture
            {
                filename = file.ID,
                file = read(file.ID.ToString())
            };
        }
        public Picture GetFirstPostPicture(Post post)
        {
            Filedto file = _File.GetFile(post.ID).Result;
            return new Picture
            {
                filename = file.ID,
                file = read(file.ID.ToString())
            };
        }
        public Picture GetFirstPostPicture(Guid post)
        {
            Filedto file = _File.GetFile(post).Result;
            return new Picture
            {
                filename = file.ID,
                file = read(file.ID.ToString())
            };
        }
        public List<Picture> GetOtherPostPicture(Post post)
        {
            List<Filedto> files = _File.GetByPost(post.ID).Result;
            List<Picture> result = new List<Picture>();
            foreach (var picture in files)
            {
                result.Add(new Picture
                {
                    filename = picture.ID,
                    file = read(picture.ID.ToString())
                });
            }
            return result;
        }
        public List<Picture> GetOtherPostPicture(Guid post)
        {
            List<Filedto> files = _File.GetByPost(post).Result;
            List<Picture> result = new List<Picture>();
            foreach (var picture in files)
            {
                result.Add(new Picture
                {
                    filename = picture.ID,
                    file = read(picture.ID.ToString())
                });
            }
            return result;
        }
        public void SetAvatar(Picture picture)
        {
            Filedto filedb = new Filedto
            {
                ID = picture.filename,
                DateOfCreate = DateTime.Now,
                Autorid = picture.filename,
                Lenght = picture.file.Length
            };
            _File.AddFile(filedb);
            try
            {
                save(picture.filename.ToString(), picture.file);
                _File.SaveChanges();
            }
            catch (Exception)
            {
            }
        }
        public void SetPostFirstPicture(Picture picture, Guid Author)
        {
            if (_postRepository.GetByIdAsync(picture.filename).Result.CreatorId == Author)
            {
                Filedto filedb = new Filedto
                {
                    Autorid = Author,
                    ID = picture.filename,
                    DateOfCreate = DateTime.Now,
                    postid = picture.filename,
                    Lenght = picture.file.Length
                };
                _File.AddFile(filedb);
                save(picture.filename.ToString(), picture.file);
                _File.SaveChanges();
            }
            else
                throw new Exception("You are not author");
        }
        public void SetPostOtherPictures(IEnumerable<Picture> pictures, Guid Author)
        {
            Filedto filedb;
            foreach (var picture in pictures)
            {
                filedb = new Filedto
                {
                    Autorid = Author,
                    ID = Guid.NewGuid(),
                    DateOfCreate = DateTime.Now,
                    postid = picture.filename,
                    Lenght = picture.file.Length
                };
                _File.AddFile(filedb);
                save(filedb.ID.ToString(), picture.file);
            }
            _File.SaveChanges();
        }

        protected void save(string filename, byte[] file)
        {
            if (file.Length > 1048576)
                throw new FileLoadException("File size more then 10Mb");
            if (filename == null)
                throw new Exception("File name do not exist");
            if (FTP)
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(server.link + filename);
                if (server.login != null)
                    request.Credentials = new NetworkCredential(server.login, server.password);
                if (server.ssl)
                    request.EnableSsl = server.ssl;
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.ContentLength = file.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(file, 0, file.Length);
                requestStream.Close();
                string response = request.GetResponse().ToString();
                if (response != FtpStatusCode.CommandOK.ToString())
                    throw new Exception("Error: " + response);
            }
            else
            {
                FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "/Files/" + filename, FileMode.CreateNew);
                fs.Write(file, 0, file.Length);
                fs.Close();
            }
        }
        protected byte[] read(string filename)
        {
            if (filename == null)
                throw new Exception("File name do not exist");
            if (FTP)
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(server.link + filename);
                if (server.login != null)
                    request.Credentials = new NetworkCredential(server.login, server.password);
                if (server.ssl)
                    request.EnableSsl = server.ssl;
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                if (response.StatusCode == FtpStatusCode.CommandOK)
                {
                    Stream requestStream = response.GetResponseStream();
                    byte[] buffer = new byte[(int)requestStream.Length];
                    requestStream.Read(buffer, 0, (int)requestStream.Length);
                    response.Close();
                    return buffer;
                }
                else
                    throw new Exception("Error: " + ((FtpStatusCode)response.StatusCode).ToString());
            }
            else
            {

                FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "/Files/" + filename, FileMode.Open);
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
                fs.Close();
                return buffer;
            }
        }


    }
}
