
using Connector.Entities;
using Connector.Models;
using Connector.Repositories;
using Connector.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

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
            cmbReqMethod.DataSource = Enum.GetValues(typeof(Method));
            cmbAuthType.DataSource = Enum.GetValues(typeof(AuthenticatorType));
            cmbRequestBodyType.DataSource = Enum.GetValues(typeof(RequestBodyType));
            //cmbContentType.DataSource = Enum.GetValues(typeof(ContentType));
            apiDetailService = new Service<ApiDetail>(new Repository<ApiDetail>());
            apiRequestService = new Service<ApiRequest>(new Repository<ApiRequest>());
            btnSave.Enabled = false;
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

        private void trOutput_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //trOutput.SelectedNode = e.Node;
            // txtNextUrl.Text = e.Node.Text;

            //var nextParent = e.Node.Parent;

            //string node = "";
            //while (nextParent != null)
            //{
            //    node = nextParent.Text + "." + node;
            //    nextParent = nextParent.Parent;
            //}

            //txtNextUrl.Text = node;
        }

        private ApiDetail GetApiDetail() => new ApiDetail
        {
            Name = txtName.Text,
            AuthUrl = txtAuthUrl.Text,
            Method = cmbMethod.SelectedValue.ToString(),
            AuthType = cmbAuthType.SelectedValue.ToString(),
            ConsumerKey = txtKey.Text,
            ConsumerSecret = txtSecret.Text,
            UserName = txtKey.Text,
            Password = txtSecret.Text,
            OauthToken = txtKey.Text,
            OauthTokenSecret = txtSecret.Text,
            Token = txtToken.Text,
            Apikey = txtToken.Text,
            CreatedDate = DateTime.Now,
            IsActive = true,
        };

        private ApiRequest GetApiRequest() => new ApiRequest
        {
            BaseUrl = txtBaseUrl.Text,
            ResourceUrl = txtResourceUrl.Text,
            NextUrl = txtNextUrl.Text,
            Body = rtxBody.Text,
            ContentType = cmbRequestBodyType.SelectedValue.ToString(),
            Headers = dataGridViewHeader.Rows.ConvertToHeader(),
            QueryParameters = dataGridViewQueryParameters.Rows.ConvertToQueryParameters(),
            CreatedDate = DateTime.Now,
            IsActive = true,
        };



        private async void btnSave_Click(object sender, EventArgs e)
        {
            var apiDetail = GetApiDetail();

            var details = await apiDetailService.AddAsync(apiDetail);

            var apiRequest = GetApiRequest();
            apiRequest.ApiId = details.Id;

            _ = await apiRequestService.AddAsync(apiRequest);
        }

        private void btnAuthGo_Click(object sender, EventArgs e)
        {
            var apiDetail = GetApiDetail();
            var request = GetApiRequest();

            var executer = new RequestExecuter
            {
                validateRequest = new ValidateRequestParam
                {
                    ApiDetail = apiDetail,
                    ApiRequest = request,
                }
            };


            //var data = executer.Initialize().Run();
            var data = executer.Validate().Run();

            Utilities.JsonToTreeview(trOutput, data, "root");
            //trOutput.ExpandAll();
        }

        private void trOutput_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var ancestorsAndSelf = e.Node.FullPath.Split(trOutput.PathSeparator.ToCharArray());
            string node = string.Join(".", ancestorsAndSelf);
            txtNextUrl.Text = node;
            btnSave.Enabled = true;
        }
    }
}