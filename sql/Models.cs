using SQL.DAO;

namespace SQL.models {
    public class Modelo {



        private Dictionary<string, object> fields
        {
            get
            {

                var Flags = System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance;
                System.Reflection.FieldInfo? fieldInfo = this.GetType().GetField("fields", Flags);
                object obj = fieldInfo.GetValue(this);
                if (obj != null)
                {
                    Dictionary<string, object> dict = obj as Dictionary<string, object>;
                    return dict;
                } else {
                    return new Dictionary<string, object>();
                }
                
                
            }
        }

        private string name_table
        {
            get
            {   
                
                return this.GetType().Name;
            }
        }

        private int id;
        public int Id
        {
            get
            {
                return this.id;
            }
        }
        
        public void save(){
            cnx_BD database = new cnx_BD();
            if (this.id != 0){
                string resp = database.update(this.name_table, this.id, this.fields);

                if (resp == "success"){
                    Console.WriteLine($"{this.name_table} Atualizado(a)");
                } else {
                    Console.WriteLine($"ERRO na atualização de {this.name_table}");
                }
                
            } else {
                string resp = database.insert(this.name_table , this.fields);

                if (resp == "success"){
                    Console.WriteLine($"{this.name_table} cadastrado(a)");
                } else {
                    Console.WriteLine($"ERRO no cadastro de {this.name_table}");
                }
            } 
        }

        public void get(int id){

            cnx_BD database = new cnx_BD();

            this.fields.Clear();

            Dictionary<string, string> c = database.get(id, this.name_table);
            try
            {
                int cont = 0;
                foreach(var item in c)
                {
                    if (cont > 0){
                        this.fields.Add(item.Key, item.Value);
                    } else {
                        this.id = int.Parse(item.Value);
                    }
                    cont += 1;
                }
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
                Console.WriteLine($"{this.name_table} deletado(a)");
            } else {
                Console.WriteLine($"ERRO no exclusão de {this.name_table}");
            }
        }
    }
}