using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Modelo;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using System.Collections.Generic;

namespace Modelo
{
    public static class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        
        public static ISession OpenSession()
        {
            //Open and return the nhibernate session
            return SessionFactory.OpenSession();
        }

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    //Create the session factory
                    _sessionFactory = Fluently.Configure()
                                        .Database(MsSqlConfiguration.MsSql2008.ConnectionString(x => x.FromConnectionStringWithKey("ConexaoBanco")).ShowSql())
                                        .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true))
                                        .Mappings(x => x.FluentMappings.Add<ProdutoMap>().Add<CategoriaMap>().Add<FornecedorMap>())
                                        .BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        
    }
}
