using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{

    public class Fornecedores
    {


        public IList<Fornecedor> Lista()
        {
            using (var session = NHibernateHelper.OpenSession())
                return session.QueryOver<Fornecedor>()
                    .List();
        }

   
        public void Salvar(Fornecedor fornecedor)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                session.SaveOrUpdate(fornecedor);
                session.Flush();
            }
        }

        public virtual Fornecedor Por(Guid? id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Get<Fornecedor>(id);
            }
        }

        public virtual void Apagar(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var fornecedor = session.Get<Fornecedor>(id);

                session.Delete(fornecedor);

                session.Flush();
            }
        }
    }
 }
 



