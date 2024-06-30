﻿using Microsoft.AspNetCore.Http;
using TripleA.Data.Entities;
using TripleA.Infrustructure.unitOfWork;
using TripleA.Service.Abstracts;

namespace TripleA.Service.implementations
{
    public class AdvertisementService : IAdvertisementsService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFileService fileService;
        private readonly IPhotoService photoService;

        public AdvertisementService(IUnitOfWork unitOfWork, IFileService fileService, IPhotoService photoService)
        {
            this.unitOfWork = unitOfWork;
            this.fileService = fileService;
            this.photoService = photoService;
        }

        public async Task<string> AddAdvertisements(Advertisement advertisement, IFormFile? file = null)
        {
            if (file != null)
            {
                var result = await photoService.AddPhotoAsync(file);
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var fileUrl = result.Url.ToString();
                    advertisement.image = fileUrl;
                }
                else
                {
                    advertisement.image = "NoFile";
                }

            }
            else
            {
                advertisement.image = "NoFile";
            }

            await unitOfWork.Advertisements.AddAsync(advertisement);
            await unitOfWork.SaveChangesAsync();
            return "Added";
        }

        public async Task<List<Advertisement>> GetAdvertisementListAsync()
        {
            var result = await unitOfWork.Advertisements.GetAllAsync();
            return result.ToList();
        }
    }
}