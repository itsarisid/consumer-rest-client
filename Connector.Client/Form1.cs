
using Connector.Entities;
using Connector.Models;
using Connector.Repositories;
using Connector.Services;
using Newtonsoft.Json.Linq;
using RestSharp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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
        }

        private void frmRestClient_Load(object sender, EventArgs e)
        {

        }

        private void trOutput_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            trOutput.SelectedNode = e.Node;
            txtNextUrl.Text = e.Node.Text;
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


             var data = executer.Initialize().Run();
            //var data = executer.Validate().Run();

            Utilities.JsonToTreeview(trOutput, data, "root");
        }

    }
}