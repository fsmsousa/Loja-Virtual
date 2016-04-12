using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{

    public class Produtos
    {


        public IList<Produto> Lista()
        {
            using (var session = NHibernateHelper.OpenSession())
                return session.QueryOver<Produto>()
                              .Fetch(p => p.Categoria)
                              .Eager
                              .List();
        }

   
        public void Salvar(Produto produto)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                session.SaveOrUpdate(produto);
                session.Flush();
            }
        }

        public virtual Produto Por(Guid? id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Get<Produto>(id);
            }
        }

        public virtual void Apagar(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var produto = session.Get<Produto>(id);

                session.Delete(produto);

                session.Flush();
            }
        }
    }
 }
 



