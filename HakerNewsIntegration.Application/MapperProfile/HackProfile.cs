using AutoMapper;
using HakerNewsIntegration.Domain.DTOs;
using HakerNewsIntegration.Domain.Models;

namespace HakerNewsIntegration.Application.MapperProfile
{
    public class HackProfile : Profile
    {
        public HackProfile()
        {
            CreateMap<HakerAgentResponse, HakerHakingResponseDTO>()
                .ForMember(dest => dest.PostedBy, opt => opt.MapFrom(src => src.By))
                .ForMember(dest => dest.Uri, opt => opt.MapFrom(src => src.Url))
                .ForMember(dest => dest.CommentCount, opt => opt.MapFrom(src => src.Descendants))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Score))
                .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Time));
        }
    }
}
