using AutoMapper;
using AutoMapper.QueryableExtensions;
using File_Sharing.Models;
using File_Sharing.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace File_Sharing.Services
{
    public interface IUploadService
    {
        IQueryable<UploadViewModel> GetAll();
        IQueryable<UploadViewModel> Search(string term);
        Task Create(InputUpload model);
        Task<UploadViewModel> Find(string id, string userId);
        Task Delete(string id, string userId);
        IQueryable<UploadViewModel> GetByUserId(string userId);
        Task<UploadViewModel> Find(string id);
        Task IncreamentDownloadCount(string id);
    }

    public class UploadService : IUploadService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public UploadService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IQueryable<UploadViewModel> GetByUserId(string userId)
        {
            var result = context.Uploads.Where(a => a.UserId == userId)
                .OrderByDescending(s => s.DownloadCount)
                .ProjectTo<UploadViewModel>(mapper.ConfigurationProvider);

            return result;
        }

        public async Task Create(InputUpload model)
        {
            var mappedObj = mapper.Map<Uploads>(model);
            await context.Uploads.AddAsync(mappedObj);

            await context.SaveChangesAsync();
        }

        public async Task Delete(string id, string userId)
        {
            var result = await context.Uploads.FirstOrDefaultAsync(x => x.UploadId == id && x.UserId == userId);
            if (result != null)
            {
                context.Uploads.Remove(result);
                await context.SaveChangesAsync();

            }
        }

        public async Task<UploadViewModel> Find(string id, string userId)
        {
            var result = await context.Uploads.FirstOrDefaultAsync(x=>x.UploadId == id && x.UserId == userId);
            if (result != null)
            {
                //  AutoMapper
                return mapper.Map<UploadViewModel>(result);
            }
            return null;
        }

        public async Task<UploadViewModel> Find(string id)
        {
            var result = await context.Uploads.FindAsync(id);
            if (result != null)
            {
                //  AutoMapper
                return mapper.Map<UploadViewModel>(result);
            }
            return null;
        }

        public IQueryable<UploadViewModel> GetAll()
        {
            var result = context.Uploads
                .OrderByDescending(s => s.DownloadCount)
                .ProjectTo<UploadViewModel>(mapper.ConfigurationProvider);

            return result;
        }

        public IQueryable<UploadViewModel> Search(string term)
        {
            var result = context.Uploads
                .Where(a => a.OriginalFileName.Contains(term))
                .OrderByDescending(s => s.DownloadCount)
                .ProjectTo<UploadViewModel>(mapper.ConfigurationProvider)
                .Take(10);

            return result;
        }

        public async Task IncreamentDownloadCount(string id)
        {
            var result = await context.Uploads.FindAsync(id);
            if (result != null)
            {
                result.DownloadCount++;
                context.Update(result);
                await context.SaveChangesAsync();
            }
        }
    }
}
