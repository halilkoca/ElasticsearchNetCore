using System;
using ElasticNetCore.Entities;
using Nest;

namespace ElasticNetCore.Mapping
{
    public static class Mapping
    {
        public static CreateIndexDescriptor ProductMapping(this CreateIndexDescriptor descriptor)
        {
            return descriptor.Map<Product>(m => m.Properties(p => p
                .Keyword(k => k.Name(n => n.Id))
                .Text(t => t.Name(n => n.Name))
                .Text(t => t.Name(n => n.ImageUrl))
                .Number(t => t.Name(n => n.Price))
            )
            );
        }
    }
}
