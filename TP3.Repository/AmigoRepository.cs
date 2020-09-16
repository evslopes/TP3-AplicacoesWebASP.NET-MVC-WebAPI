using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TP3.Domain;
using TP3.Repository.Context;
using TP3.Repository.Mapping;

namespace TP3.Repository
{
    public class AmigoRepository
    {
        private AmigoContext Context { get; set; }

        public AmigoRepository(AmigoContext context)
        {
            this.Context = context;
        }

        public IEnumerable<Amigo> GetAll()
        {
            return Context.Amigos.AsEnumerable();
        }

        public Amigo GetAmigoById(Guid id)
        {
            return Context.Amigos.FirstOrDefault(x => x.Id == id);
        }

        public void Save (Amigo amigo)
        {
            this.Context.Amigos.Add(amigo);
            this.Context.SaveChanges();
        }

        public Amigo GetAmigoByEmail(string email)
        {
            return Context.Amigos.FirstOrDefault(x => x.Email == email);
        }

        public void Delete(Guid id)
        {
            var amigo = Context.Amigos.FirstOrDefault(x => x.Id == id);

            this.Context.Amigos.Remove(amigo);
            this.Context.SaveChanges();
        }

        public void Update (Guid id, Amigo amigo)
        {
            var amigoOld = Context.Amigos.FirstOrDefault(x => x.Id == id);

            amigoOld.Nome = amigo.Nome;
            amigoOld.Sobrenome = amigo.Sobrenome;
            amigoOld.Email = amigo.Email;
            amigoOld.Telefone = amigo.Telefone;
            amigoOld.DataDeAniversario = amigo.DataDeAniversario;

            Context.Amigos.Update(amigoOld);
            this.Context.SaveChanges();
        }

    }
}
