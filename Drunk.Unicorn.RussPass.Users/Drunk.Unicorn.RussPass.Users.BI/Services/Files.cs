using Drunk.Unicorn.RussPass.Users.BI.Interfaces;
using Drunk.Unicorn.RussPass.Users.BI.Options;
using Drunk.Unicorn.RussPass.Users.Data.Models;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Minio;
using Minio.DataModel.Args;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.Users.BI.Services
{
    public class FilesProvider : IFilesProvider
    {
        private readonly IMinioClient _minioClient;
        private readonly FileConfig _config;

        public FilesProvider(IOptions<FileConfig> config)
        {
            _config = config.Value;
            _minioClient = new MinioClient()
                              .WithEndpoint(_config.Url)
                              .WithCredentials(_config.AcceptKey, _config.SecretKey)
                              .Build();
        }

        public async Task<string> SendFile(Stream file, string fileName)
        {
            var f = new PutObjectArgs()
                .WithBucket(_config.MainBucket)
                .WithObject(fileName)
                .WithStreamData(file)
                .WithObjectSize(file.Length)
                .WithContentType("application/octet-stream");

            var link = await _minioClient.PresignedGetObjectAsync(new PresignedGetObjectArgs().WithObject(fileName).WithBucket(_config.MainBucket).WithExpiry(10000));

            return link;
        }

    }

    public class FilesObmennikProvider : IFilesProvider
    {
        private readonly HttpClient _httpClient;
        private readonly Fileobmen _config;

        public FilesObmennikProvider(HttpClient client, IOptions<Fileobmen> config)
        {
            _config = config.Value;

            _httpClient = client;
            _httpClient.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", _config.Key);
        }

        public async Task<string> SendFile(Stream file, string fileName)
        {
            using MultipartFormDataContent multipartContent = new();
            var imageContent = new StreamContent(File.OpenRead($".{Path.DirectorySeparatorChar}john_doe.jpg"));
            imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse(MediaTypeNames.Image.Jpeg);
            multipartContent.Add(imageContent, "image", fileName);
            using var response = await _httpClient.PostAsync(_config.Url, multipartContent);

            var result = JsonSerializer.Deserialize<ImageObmennik>(await response.Content.ReadAsStringAsync());

            return result.Data.Link;
        }
    }
}
