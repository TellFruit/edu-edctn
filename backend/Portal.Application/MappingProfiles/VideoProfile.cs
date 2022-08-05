using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.MappingProfiles
{
    internal class VideoProfile : Profile
    {
        public VideoProfile()
        {
            CreateMap<Video, VideoDTO>();

            CreateMap<VideoDTO, Video>();
        }
    }
}
