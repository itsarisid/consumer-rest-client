
using Connector.Models;
using Connector.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace Connector.Client
{
    public partial class frmRestClient : Form
    {
        public frmRestClient()
        {
            InitializeComponent();
            cmbMethod.DataSource = Enum.GetValues(typeof(Method));
            cmbAuthType.DataSource = Enum.GetValues(typeof(AuthenticatorType));

        }

        private void DisplayTreeView(JToken root, string rootName)
        {
            trOutput.BeginUpdate();
            try
            {
                trOutput.Nodes.Clear();
                var tNode = trOutput.Nodes[trOutput.Nodes.Add(new TreeNode(rootName))];
                tNode.Tag = root;

                AddNode(root, tNode);

                trOutput.ExpandAll();
            }
            finally
            {
                trOutput.EndUpdate();
            }
        }

        private void AddNode(JToken token, TreeNode inTreeNode)
        {
            if (token == null)
                return;
            if (token is JValue)
            {
                var childNode = inTreeNode.Nodes[inTreeNode.Nodes.Add(new TreeNode(token.ToString()))];
                childNode.Tag = token;
            }
            else if (token is JObject)
            {
                var obj = (JObject)token;
                foreach (var property in obj.Properties())
                {
                    var childNode = inTreeNode.Nodes[inTreeNode.Nodes.Add(new TreeNode(property.Name))];
                    childNode.Tag = property;
                    AddNode(property.Value, childNode);
                }
            }
            else if (token is JArray)
            {
                var array = (JArray)token;
                for (int i = 0; i < array.Count; i++)
                {
                    var childNode = inTreeNode.Nodes[inTreeNode.Nodes.Add(new TreeNode(i.ToString()))];
                    childNode.Tag = array[i];
                    AddNode(array[i], childNode);
                }
            }
            else
            {
                Debug.WriteLine(string.Format("{0} not implemented", token.Type)); // JConstructor, JRaw
            }
        }

        private void frmRestClient_Load(object sender, EventArgs e)
        {
            var path = "D:\\consumer-rest-client\\Connector\\appsettings.json";
            using (var reader = new StreamReader(path))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var root = JToken.Load(jsonReader);
                DisplayTreeView(root, Path.GetFileNameWithoutExtension(path));
            }

            //trOutput.SetObjectAsJson(new AppSettings());
        }

        private void trOutput_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            trOutput.SelectedNode = e.Node;
            txtNextUrl.Text = e.Node.Text;
        }

        private void btnSaveAuthDetails_Click(object sender, EventArgs e)
        {
            IRepository<ApiDetail> repository = new Repository<ApiDetail>();
            var detail = new ApiDetail
            {
                Name = txtName.Text,
                AuthUrl = txtAuthUrl.Text,
                Method = cmbMethod.SelectedText,
                AuthType = cmbAuthType.SelectedText,
                Token = txtToken.Text,
                CreatedDate = DateTime.Now,
            };

            repository.Insert(detail);
            repository.Save();
        }
    }
}