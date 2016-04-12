using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{

    public class Categorias
    {


        public IList<Categoria> Lista()
        {
            using (var session = NHibernateHelper.OpenSession())
                return session.QueryOver<Categoria>()
                    .List();
        }

   
        public void Salvar(Categoria categoria)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                session.SaveOrUpdate(categoria);
                session.Flush();
            }
        }

        public virtual Categoria Por(Guid? id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Get<Categoria>(id);
            }
        }

        public virtual void Apagar(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var categoria = session.Get<Categoria>(id);

                session.Delete(categoria);

                session.Flush();
            }
        }
    }
 }
 



