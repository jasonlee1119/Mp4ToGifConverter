using Microsoft.Extensions.Logging;
using Mp4ToGifConverter.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mp4ToGifConverter.Services
{
    public class FileIOService : IFileIOService
    {
        private readonly ILogger<FileIOService> _logger;

        public FileIOService(ILogger<FileIOService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
