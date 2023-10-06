
using Connector.Models;
using Connector.Repositories;
using Connector.Services;
using Newtonsoft.Json.Linq;

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


        private async void btnSave_Click(object sender, EventArgs e)
        {
            var headers = dataGridViewHeader.Rows.ConvertToHeader();
            var queryParameters = dataGridViewQueryParameters.Rows.ConvertToQueryParameters();

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
                ApiId = details.Id,
                BaseUrl = txtBaseUrl.Text,
                ResourceUrl = txtResourceUrl.Text,
                NextUrl = txtNextUrl.Text,
                Body = rtxBody.Text,
                Headers = headers,
                QueryParameters = queryParameters,
                CreatedDate = DateTime.Now,
                IsActive = true,
            });
        }

        private void btnAuthGo_Click(object sender, EventArgs e)
        {
            var executer = new RequestExecuter();

            var data = executer.Initialize().Run();

            Utilities.JsonToTreeview(trOutput, data, "root");
        }
    }
}