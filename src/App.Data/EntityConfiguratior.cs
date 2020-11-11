using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace App.Data
{
    /// <summary>
    /// Механизм конфигураций Entity моделей
    /// </summary>
    internal static class EntityConfiguratior
    {
        private static Type entityTypeConfigurationInterface = typeof(IEntityTypeConfiguration<>);

        private static IEnumerable<Type> GetEntitiesConfigurations(Assembly assembly)
        {
            return assembly.GetClssesByInterface(entityTypeConfigurationInterface).Where(p => p.IsAbstract == false);
        }

        public static void BuildEntitiesConfiguration(this ModelBuilder modelBuilder, Assembly assembly)
        {
            foreach (var entityConfigurationType in GetEntitiesConfigurations(assembly))
            {
                var entityType = entityConfigurationType.GetInterface(entityTypeConfigurationInterface.Name).GenericTypeArguments.Single(t => t.IsClass);

                var applyConfigMethod = modelBuilder.GetType().GetMethods().Where(m => m.Name.Equals("ApplyConfiguration") && m.IsGenericMethod)
                    .Single(m => m.GetParameters().Any(p => p.ParameterType.Name.Equals(entityTypeConfigurationInterface.Name)));

                var applyConfigGenericMethod = applyConfigMethod.MakeGenericMethod(entityType);

                applyConfigGenericMethod.Invoke(modelBuilder, new object[] { Activator.CreateInstance(entityConfigurationType) });
            }
        }

        public static IEnumerable<Type> GetClssesByInterface(this Assembly assembly, Type @interface)
        {
            if (@interface.IsGenericType)
            {
                return assembly.GetTypes().Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == @interface) && t.GetTypeInfo().IsClass);
            }
            else
            {
                return assembly.GetTypes().Where(t => t.GetInterfaces().Contains(@interface) && t.GetTypeInfo().IsClass);
            }
        }
    }
}
