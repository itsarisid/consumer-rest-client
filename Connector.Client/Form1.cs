
using Azure.Core;
using Connector.Models;
using Connector.Repositories;
using Connector.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Connector.Client
{
    public partial class frmRestClient : Form
    {
        private readonly IService<ApiDetail> apiDetailService;
        private readonly IService<ApiRequest> apiRequestService;
        public frmRestClient()
        {
            InitializeComponent();
            cmbMethod.DataSource = Enum.GetValues(typeof(Method));
            cmbAuthType.DataSource = Enum.GetValues(typeof(AuthenticatorType));
            apiDetailService = new Service<ApiDetail>(new Repository<ApiDetail>());
            apiRequestService = new Service<ApiRequest>(new Repository<ApiRequest>());
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


        private async void btnSave_Click(object sender, EventArgs e)
        {
            var headers = dataGridViewHeader.Rows.ConvertToHeader();
            var queryParameters = dataGridViewHeader.Rows.ConvertToQueryParameters();

           var details = await apiDetailService.AddAsync(new ApiDetail
            {
                Name = txtName.Text,
                AuthUrl = txtAuthUrl.Text,
                Method = cmbMethod.SelectedValue.ToString(),
                AuthType = cmbAuthType.SelectedValue.ToString(),
                Token = txtToken.Text,
                CreatedDate = DateTime.Now,
                IsActive = true,
            });

            var request = await apiRequestService.AddAsync(new ApiRequest
            {
                ApiId=details.Id,
                BaseUrl=txtBaseUrl.Text,
                ResourceUrl=txtResourceUrl.Text,
                NextUrl=txtNextUrl.Text,
                Headers = headers,
                QueryParams = queryParameters,
                CreatedDate = DateTime.Now,
                IsActive=true,
            });

            request.IsSuccessfull = true;
        }
    }
}