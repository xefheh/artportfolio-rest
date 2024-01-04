using System.Reflection;
using ArtPortfolio.Domain.Common.Attributes;

namespace ArtPortfolio.Domain.Common.Abstracts;

/// <summary>
/// Сущность, с обновляемыми полями свойствами.
/// Обновляемое свойство пометить аттрибутом Updatable
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public abstract class UpdatableEntity<TEntity> 
   where TEntity : UpdatableEntity<TEntity>
{
   private static readonly PropertyInfo[] UpdatablePropertyInfos = (typeof(TEntity))
      .GetProperties()
      .Where(property => property
         .GetCustomAttributes()
         .Any(attribute => attribute is Updatable))
      .ToArray();

   /// <summary>
   /// Обновить поля сущности.
   /// </summary>
   /// <param name="other">Сущность с обновлёнными полями</param>
   public void UpdateFields(TEntity other)
   {
      var thisEntity = this;
      foreach (var propertyInfo in UpdatablePropertyInfos)
      {
         var newPropertyValue = propertyInfo.GetValue(other);
         propertyInfo.SetValue(thisEntity, newPropertyValue);
      }
   }
}