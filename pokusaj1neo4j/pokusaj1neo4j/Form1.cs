using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using pokusaj1neo4j.DomainModel;
using Neo4jClient;
using Neo4jClient.Cypher;

namespace pokusaj1neo4j
{
    public partial class Form1 : Form
    {
        private GraphClient client;
        public Form1()
        {
            InitializeComponent();
            
            client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "blizanci");
            try
            {
                client.Connect();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            /*queryDict.Add("name", "22");
            queryDict.Add("birthday", "312313");
            queryDict.Add("birthplace", "Nis");
            queryDict.Add("biography", actor.biography);*/
            var query = new Neo4jClient.Cypher.CypherQuery("CREATE (n:Actor {id:'22', name:'marko', birthday:'312313', birthplace:'Nis', biography:'dasdsa'}) return n",
                                                            queryDict, CypherResultMode.Set);
            ((IRawGraphClient)client).ExecuteCypher(query);

        }
    }
}
