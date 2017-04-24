using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTPClient
{

    public class Ftp
    {
        private string host = null;
        private string user = null;
        private string pass = null;
        private FtpWebRequest ftpRequest = null;
        private FtpWebResponse ftpResponse = null;
        private Stream ftpStream = null;
        private int bufferSize = 2048;

        public Ftp(string hostIP, string userName, string password)
        {
            host = hostIP;
            user = userName;
            pass = password;
        }

        async public void Download(string remoteFile, string localFile)
        {
            try
            {
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + remoteFile);

                ftpRequest.Credentials = new NetworkCredential(user, pass);

                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;

                ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;

                ftpResponse = (FtpWebResponse)await ftpRequest.GetResponseAsync();

                ftpStream =  ftpResponse.GetResponseStream();

                FileStream localFileStream = new FileStream(localFile, FileMode.Create);

                byte[] byteBuffer = new byte[bufferSize];
                int bytesRead = await ftpStream.ReadAsync(byteBuffer, 0, bufferSize);

                try
                {
                    while (bytesRead > 0)
                    {
                        localFileStream.Write(byteBuffer, 0, bytesRead);
                        bytesRead = await ftpStream.ReadAsync(byteBuffer, 0, bufferSize);
                    }
                }
                catch (Exception)
                {

                }

                localFileStream.Close();
                ftpStream.Close();
                ftpResponse.Close();
                ftpRequest = null;
            }
            catch (Exception) { }

        }


     async   public void Upload(string remoteFile, string localFile)
        {
            try
            {
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + remoteFile);

                ftpRequest.Credentials = new NetworkCredential(user, pass);

                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;

                ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;

                ftpStream = ftpRequest.GetRequestStream();
                FileStream localFileStream = new FileStream(localFile, FileMode.Open);

                byte[] byteBuffer = new byte[bufferSize];
                int bytesSent =await localFileStream.ReadAsync(byteBuffer, 0, bufferSize);


                try
                {
                    while (bytesSent != 0)
                    {
                       await ftpStream.WriteAsync(byteBuffer, 0, bytesSent);
                        bytesSent = await localFileStream.ReadAsync(byteBuffer, 0, bufferSize);
                    }
                }
                catch (Exception)
                {

                }

                localFileStream.Close();
                ftpStream.Close();
                ftpRequest = null;
            }
            catch (Exception)
            {

            }
            return;
        }



        public string[] DirectoryListSimple(string directory)
        {
            try
            {
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + directory);

                ftpRequest.Credentials = new NetworkCredential(user, pass);

                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;

                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;

                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                

                ftpStream =ftpResponse.GetResponseStream();

                StreamReader ftpReader = new StreamReader(ftpStream);

                string directoryRaw = null;
                directoryRaw += "В предыдущую папку|";
                try
                {
                    while (ftpReader.Peek() != -1)
                    {
                        directoryRaw += ftpReader.ReadLine() + "|";
                    }
                }
                catch (Exception) { }
                ftpReader.Close();
                ftpStream.Close();
                ftpResponse.Close();
                ftpRequest = null;
                try
                {
                    string[] directoryList = directoryRaw.Split("|".ToCharArray());
                    return directoryList;
                }
                catch (Exception)
                {

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Сервер не доступен. Попробуйте другой");
            }
            return new string[] { "В предыдущую папку" };
        }

        public void Delete(string deleteFile)
        {
            try
            {
                ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + deleteFile);
                ftpRequest.Credentials = new NetworkCredential(user, pass);

                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile;

                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();

                ftpResponse.Close();
                ftpRequest = null;
            }
            catch (Exception)
            {

            }
            return;
        }






























        /*
    public string[] DirectoryListDetailed(string directory)
    {
        try
        {
            ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + directory);
            ftpRequest.Credentials = new NetworkCredential(user, pass);
            ftpRequest.UseBinary = true;
            ftpRequest.UsePassive = true;
            ftpRequest.KeepAlive = true;
            ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
            ftpStream = ftpResponse.GetResponseStream();
            StreamReader ftpReader = new StreamReader(ftpStream);
            string directoryRaw = null;
            try { while (ftpReader.Peek() != -1) { directoryRaw += ftpReader.ReadLine() + "|"; } }
            catch (Exception  ) {   }
            ftpReader.Close();
            ftpStream.Close();
            ftpResponse.Close();
            ftpRequest = null;
            try { string[] directoryList = directoryRaw.Split("|".ToCharArray()); return directoryList; }
            catch (Exception  ) {   }
        }
        catch (Exception  ) {   }
        return new string[] { "" };
    }*/

        /*
        public void Rename(string currentFileNameAndPath, string newFileName)
        {
            try
            {

                ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + currentFileNameAndPath);

                ftpRequest.Credentials = new NetworkCredential(user, pass);

                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;

                ftpRequest.Method = WebRequestMethods.Ftp.Rename;

                ftpRequest.RenameTo = newFileName;

                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();

                ftpResponse.Close();
                ftpRequest = null;
            }
            catch (Exception  ) {   }
            return;
        }


        public void CreateDirectory(string newDirectory)
        {
            try
            {

                ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + newDirectory);

                ftpRequest.Credentials = new NetworkCredential(user, pass);

                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;

                ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;

                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();

                ftpResponse.Close();
                ftpRequest = null;
            }
            catch (Exception  ) {   }
            return;
        }


        public string GetFileCreatedDateTime(string fileName)
        {
            try
            {
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + fileName);
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                ftpRequest.Method = WebRequestMethods.Ftp.GetDateTimestamp;
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                ftpStream = ftpResponse.GetResponseStream();
                StreamReader ftpReader = new StreamReader(ftpStream);
                string fileInfo = null;
                try { fileInfo = ftpReader.ReadToEnd(); }
                catch (Exception  ) {   }
                ftpReader.Close();
                ftpStream.Close();
                ftpResponse.Close();
                ftpRequest = null;
                return fileInfo;
            }
            catch (Exception  ) {   }
            return "";
        }

        public string GetFileSize(string fileName)
        {
            try
            {
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + fileName);
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                ftpRequest.Method = WebRequestMethods.Ftp.GetFileSize;
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                ftpStream = ftpResponse.GetResponseStream();
                StreamReader ftpReader = new StreamReader(ftpStream);
                string fileInfo = null;
                try { while (ftpReader.Peek() != -1) { fileInfo = ftpReader.ReadToEnd(); } }
                catch (Exception  ) {   }
                ftpReader.Close();
                ftpStream.Close();
                ftpResponse.Close();
                ftpRequest = null;
                return fileInfo;
            }
            catch (Exception  ) {   }
            return "";
        }*/
    }
}