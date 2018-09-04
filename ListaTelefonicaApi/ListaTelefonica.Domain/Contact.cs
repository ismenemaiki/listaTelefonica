using ListaTelefonica.Domain.Repository;
using System;

namespace ListaTelefonica.Domain
{
    public class Contact
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public IContactRepository Repository { get; set; }
        public Carrier Carrier { get; set; }

        public void Save()
        {
            if (Repository == null)
                throw new ArgumentNullException("Repositorio no dominio de contato nao referenciado.");

            if (String.IsNullOrEmpty(Name))
                throw new Exception("O nome do contato não pode ser vazio.");

            if(Name.Length < 10)
                throw new Exception("O nome do contato não pode ter menos que 10 caracteres.");
          
            if (String.IsNullOrEmpty(PhoneNumber))
                throw new Exception("O telefone do contato não pode ser vazio.");

            if (Carrier == null || Carrier.Id <= 0)
                throw new Exception("Operadora inválida.");

            this.Id = Repository.Add(this);
        }
        //-----------------------------------------
        public void Update()
        {
            if (Repository == null)
                throw new ArgumentNullException("Repositorio no dominio de contato nao referenciado.");
            
            Repository.Update(this); // this.Id
        }
        //-----------------------------------------
    }
}
