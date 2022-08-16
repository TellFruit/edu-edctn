using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Portal.Application.Interfaces.OuterImpl;
using Portal.Domain.Entities;
using Portal.Domain.Exceptions;
using Portal.Persistence_EF_Core.Repositories.Abstract;
using Portal.Persitence_EF_Core.FrameworkEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Persistence_EF_Core.Repositories
{
    internal class VideoRepository : BaseRepository, IGenericRepository<VideoDomain>
    {
        public VideoRepository(IMapper mapper, PortalContext context) 
            : base(mapper, context) {}

        public async Task<VideoDomain> Create(VideoDomain entity)
        {
            var videoEntity = _mapper.Map<Video>(entity);

            _context.Add(videoEntity);

            return entity;
        }

        public async Task<int> Delete(VideoDomain entity)
        {
            var videoEntity = _context.Materials.OfType<Video>()
                .FirstOrDefault(u => u.Id == entity.Id);

            if (videoEntity == null)
            {
                throw new EntityNotFoundException(nameof(Video));
            }

            _context.Materials.Remove(videoEntity);
            return videoEntity.Id;
        }

        public async Task<ICollection<VideoDomain>> Read()
        {
            var videos = _context.Materials.OfType<Video>()
                .ToList();

            return videos.Select(x => _mapper.Map<VideoDomain>(x)).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task<VideoDomain> Update(VideoDomain entity)
        {
            var videoEntity = _context.Materials.OfType<Video>()
                .FirstOrDefault(u => u.Id == entity.Id);

            var data = _mapper.Map<Video>(entity);

            if (videoEntity == null)
            {
                throw new EntityNotFoundException(nameof(Video));
            }

            videoEntity.Title = data.Title;
            videoEntity.Duration = data.Duration;
            videoEntity.Quality = data.Quality;
            videoEntity.UpdatedAt = data.UpdatedAt;

            _context.Materials.Update(videoEntity);

            return entity;
        }
    }
}
