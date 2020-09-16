using System;
using System.Collections.Generic;
using System.Text;
using TP3.Domain;
using TP3.Repository;

namespace TP3.ApplicationService
{
    public class AmigoServices
    {
        private AmigoRepository Repository { get; set; }

        public AmigoServices(AmigoRepository repository)
        {
            this.Repository = repository;
        }

        public IEnumerable<Amigo> GetAll()
        {
            return Repository.GetAll();
        }

        public Amigo GetAmigoById(Guid id)
        {
            return Repository.GetAmigoById(id);
        }

        public void Save(Amigo amigo)
        {
            if (this.GetAmigoByEmail(amigo.Email) != null)
            {
                throw new Exception("Já existe um cadastro com esse email, favor cadastrar outro.");
            }

            this.Repository.Save(amigo);

        }

        public Amigo GetAmigoByEmail(string email)
        {
            return Repository.GetAmigoByEmail(email);
        }

        public void Delete(Guid id)
        {
            Repository.Delete(id);
        }

        public void Update(Guid id, Amigo amigo)
        {
            Repository.Update(id, amigo);
        }
    }
}
