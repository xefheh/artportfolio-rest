using AutoMapper;

namespace ArtPortfolio.Application.Mapping.Interfaces;

public interface IMapWith<T>
{
    void Mapping(Profile profile) =>
        profile.CreateMap(typeof(T), GetType());
}