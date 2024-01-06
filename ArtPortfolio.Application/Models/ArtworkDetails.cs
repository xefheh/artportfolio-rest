using ArtPortfolio.Application.Mapping.Interfaces;
using ArtPortfolio.Domain.Entities;
using AutoMapper;

namespace ArtPortfolio.Application.Models;

public class ArtworkDetails : IMapWith<Artwork>
{
    public string Id { get; set; }
    public string Title { get; set; } = null!;
    public string Details { get; set; } = null!;
    public byte[] ImageArray { get; set; } = null!;

    public void Mapping(Profile profile) =>
        profile.CreateMap<Artwork, ArtworkDetails>();
}