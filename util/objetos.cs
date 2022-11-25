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
                Console.WriteLine(cli.Nome);
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

            Console.WriteLine(database.insert(this.name_table , new Dictionary<String, object>{
                { "nome", this.nome }, { "email", this.email },
                { "fone", this.fone }, { "endereco", this.endereco },
            }));
        }

        public void get(int id){
            cnx_BD database = new cnx_BD();
            database.get(id, name_table);
        }
    }
}