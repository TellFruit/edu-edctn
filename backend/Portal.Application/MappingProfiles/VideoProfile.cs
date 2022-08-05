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
            CreateMap<Video, VideoDTO>()
                .ForMember(v => v.Perks, opt => opt.MapFrom(src => src.Perks));

            CreateMap<VideoDTO, Video>()
                .ForMember(v => v.Perks, opt => opt.MapFrom(src => src.Perks));
        }
    }
}
