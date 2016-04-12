using FluentNHibernate.Mapping;

namespace Modelo
{
    public class CategoriaMap : ClassMap<Categoria>
    {
        public CategoriaMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.Nome);
           
        }
    }
}
