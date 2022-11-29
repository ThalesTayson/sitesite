using SQL.DAO;
using SQL.models;
using System.Collections.Generic;

namespace APP.Modelos
{
    public class ObjClientes : List<Cliente>{
        private string name_table = "dbo.Cliente";

        public ObjClientes(){
            cnx_BD database = new cnx_BD();
            Dictionary<string, Dictionary<string, string>> list = database.list(name_table);

            foreach (string itemId in list.Keys)
            {
                Cliente cli = new Cliente();
                cli.get(int.Parse(itemId));
                this.Add(cli);
            }
        }


    }
    
    public class Cliente : Modelo
    {
        
        private Dictionary<string, object> fields = new Dictionary<string, object>{
            { "nome", null }, { "email", null },
            { "fone", null }, { "endereco", null },
            {"create_at", null},
        };

        public string Nome 
        {
            get => this.fields["nome"].ToString();
            set{ this.fields["nome"] = value;}
        }
        public string Email 
        {
            get => this.fields["email"].ToString();
            set{ this.fields["email"] = value;}
        }
        public string Fone 
        {
            get => this.fields["fone"].ToString();
            set{ this.fields["fone"] = value;}
        }
        public string Endereco 
        {
            get => this.fields["endereco"].ToString();
            set{ this.fields["endereco"] = value;}
        }
        public string DataCreated
        {
            get => this.fields["create_at"].ToString();
        }
    }
}