using Microsoft.Extensions.Logging;
using SA.Application.Services.Auth.Login;
using SA.Data.Context;
using SA.Data.Infrastructure;
using SA.Data.Repository.Auth.Login;
using SA.Data.Repository.Media.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Application.Services.Media.Image
{
	public class ImageService:IImageService
	{
		private readonly ILogger<LoginService> _logger;
		private readonly IImageRepository _imageRepository;
		private readonly IUnitOfWork<SAContext> _unitOfWork;

		public ImageService(ILogger<LoginService> logger, IImageRepository imageRepository, IUnitOfWork<SAContext> unitOfWork)
		{
			_logger = logger;
			_imageRepository = imageRepository;
			_unitOfWork = unitOfWork;
		}

        
    }
}
