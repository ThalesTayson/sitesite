using sitesite.DAL;
using System.Collections.Generic;

namespace sitesite.objetos
{
    public class ObjClientes : List<Cliente>{
        private string name_table = "dbo.Cliente";

        public ObjClientes(){
            cnx_BD database = new cnx_BD();
            Dictionary<string, Dictionary<string, string>> list = database.list(name_table);

            foreach (string itemId in list.Keys)
            {
                Cliente cli = new Cliente();
                cli.Id = int.Parse(itemId);
                cli.Nome = list[itemId]["nome"];
                cli.Email = list[itemId]["email"];
                cli.Endereco = list[itemId]["endereco"];
                cli.Fone = list[itemId]["fone"];
                this.Add(cli);
            }
        }


    }
    
    public class Cliente
    {
        private string name_table = "dbo.Cliente";
        private int id;
        private string? nome;
        private string? email;
        private string? fone;
        private string? endereco;

        public int Id 
        {
            get => this.id;
            set{ this.id = value;}
        }
        public string Nome 
        {
            get => this.nome;
            set{ this.nome = value;}
        }
        public string Email 
        {
            get => this.email;
            set{ this.email = value;}
        }
        public string Fone 
        {
            get => this.fone;
            set{ this.fone = value;}
        }
        public string Endereco 
        {
            get => this.endereco;
            set{ this.endereco = value;}
        }
        public string Name_table {get => this.name_table;}

        public void save(){
            cnx_BD database = new cnx_BD();
            if (this.id != 0){
                string resp = database.update(this.name_table, this.id, new Dictionary<String, object>{
                    { "nome", this.nome }, { "email", this.email },
                    { "fone", this.fone }, { "endereco", this.endereco },
                });

                if (resp == "success"){
                    Console.WriteLine("Cliente Atualizado");
                } else {
                    Console.WriteLine("ERRO na atualização de Cliente");
                }
                
            } else {
                string resp = database.insert(this.name_table , new Dictionary<String, object>{
                    { "nome", this.nome }, { "email", this.email },
                    { "fone", this.fone }, { "endereco", this.endereco },
                });

                if (resp == "success"){
                    Console.WriteLine("Cliente cadastrado");
                } else {
                    Console.WriteLine("ERRO no cadastro do Cliente");
                }
            } 
        }

        public void get(int id){
            cnx_BD database = new cnx_BD();
            
            Dictionary<string, string> c = database.get(id, name_table);
            try
            {
                this.id = int.Parse(c["id"]);
                this.nome = c["nome"];
                this.email = c["email"];
                this.endereco = c["endereco"];
                this.fone = c["fone"];                
            }
            catch (System.Exception)
            {
                throw;
            }

        }
        public void delete(){
            cnx_BD database = new cnx_BD();
            
            string resp = database.delete(this.name_table ,this.id);
            
            if (resp == "success"){
                Console.WriteLine("Cliente deletado");
            } else {
                Console.WriteLine("ERRO no exclusão do Cliente");
            }
        }
    }
}