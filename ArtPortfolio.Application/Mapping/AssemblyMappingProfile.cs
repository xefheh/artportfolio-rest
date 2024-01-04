using System.Reflection;
using ArtPortfolio.Application.Mapping.Interfaces;
using AutoMapper;

namespace ArtPortfolio.Application.Mapping;

public class AssemblyMappingProfile : Profile
{
    public AssemblyMappingProfile(Assembly assembly) =>
        ApplyFromAssembly(assembly);

    private void ApplyFromAssembly(Assembly assembly)
    {
        var types = assembly.GetTypes()
            .Where(type => type.GetInterfaces()
                .Any(i => i.IsGenericType &&
                          i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
            .ToList();

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);
            var methodInfo = type.GetMethod("Mapping");
            methodInfo?.Invoke(instance, [this]);
        }
    }

}