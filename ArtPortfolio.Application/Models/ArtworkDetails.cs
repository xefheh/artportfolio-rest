using ArtPortfolio.Application.Mapping.Interfaces;
using ArtPortfolio.Domain.Entities;
using AutoMapper;
using MongoDB.Bson;

namespace ArtPortfolio.Application.Models;

public class ArtworkDetails : IMapWith<Artwork>
{
    public ObjectId Id { get; set; }
    public string Title { get; set; } = null!;
    public string Details { get; set; } = null!;
    public byte[] ImageArray { get; set; } = null!;

    public void Mapping(Profile profile) =>
        profile.CreateMap<Artwork, ArtworkDetails>();
}