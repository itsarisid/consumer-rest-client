﻿using RestSharp;
using Connector.APIHelper.APIResponse;
using Connector.APIHelper.Interface;

namespace Connector.APIHelper.Command
{
    public class RequestCommand(AbstractRequest _abstractRequest, IClient _client) : ICommand
    {
        public byte[] DownloadData()
        {
            throw new System.NotImplementedException("Use the Download Command for File Download");
        }

        public Task<byte[]> DownloadDataAsync()
        {
            throw new System.NotImplementedException("Use the Download Command for File Download");
        }

        public IResponse ExecuteRequest()
        {
            var client = _client.GetClient();
            var request = _abstractRequest.Build();
            var response = client.Execute(request);
            return new Response(response);
        }

        public IResponse<T> ExecuteRequest<T>()
        {
            var client = _client.GetClient();
            var request = _abstractRequest.Build();
            var response = client.Execute<T>(request);
            return new Response<T>(response);
        }
    }
}
