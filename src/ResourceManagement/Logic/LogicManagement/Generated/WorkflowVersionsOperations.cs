// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.11.0.0
// Changes may cause incorrect behavior and will be lost if the code is

namespace Microsoft.Azure.Management.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;
    using System.Linq.Expressions;
    using Microsoft.Rest.Azure.OData;
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// WorkflowVersionsOperations operations.
    /// </summary>
    internal partial class WorkflowVersionsOperations : IServiceOperations<LogicManagementClient>, IWorkflowVersionsOperations
    {
        /// <summary>
        /// Initializes a new instance of the WorkflowVersionsOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal WorkflowVersionsOperations(LogicManagementClient client)
        {
            this.Client = client;
        }

        /// <summary>
        /// Gets a reference to the LogicManagementClient
        /// </summary>
        public LogicManagementClient Client { get; private set; }

        /// <summary>
        /// Gets a workflow version.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The resource group name.
        /// </param>    
        /// <param name='workflowName'>
        /// The workflow name.
        /// </param>    
        /// <param name='versionId'>
        /// The workflow versionId.
        /// </param>    
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<AzureOperationResponse<WorkflowVersion>> GetWithHttpMessagesAsync(string resourceGroupName, string workflowName, string versionId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.Client.SubscriptionId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.Client.SubscriptionId");
            }
            if (resourceGroupName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "resourceGroupName");
            }
            if (workflowName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "workflowName");
            }
            if (versionId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "versionId");
            }
            if (this.Client.ApiVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "this.Client.ApiVersion");
            }
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("workflowName", workflowName);
                tracingParameters.Add("versionId", versionId);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "Get", tracingParameters);
            }
            // Construct URL
            string url = this.Client.BaseUri.AbsoluteUri + 
                         "//subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Logic/workflows/{workflowName}/versions/{versionId}";
            url = url.Replace("{subscriptionId}", Uri.EscapeDataString(this.Client.SubscriptionId));
            url = url.Replace("{resourceGroupName}", Uri.EscapeDataString(resourceGroupName));
            url = url.Replace("{workflowName}", Uri.EscapeDataString(workflowName));
            url = url.Replace("{versionId}", Uri.EscapeDataString(versionId));
            List<string> queryParameters = new List<string>();
            if (this.Client.ApiVersion != null)
            {
                queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.Client.ApiVersion)));
            }
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }
            // trim all duplicate forward slashes in the url
            url = Regex.Replace(url, "([^:]/)/+", "$1");
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("GET");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", Guid.NewGuid().ToString());
            if (this.Client.AcceptLanguage != null)
            {
                if (httpRequest.Headers.Contains("accept-language"))
                {
                    httpRequest.Headers.Remove("accept-language");
                }
                httpRequest.Headers.TryAddWithoutValidation("accept-language", this.Client.AcceptLanguage);
            }
            if (customHeaders != null)
            {
                foreach(var header in customHeaders)
                {
                    if (httpRequest.Headers.Contains(header.Key))
                    {
                        httpRequest.Headers.Remove(header.Key);
                    }
                    httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            // Set Credentials
            if (this.Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            if (!(statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK")))
            {
                var ex = new CloudException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                CloudError errorBody = JsonConvert.DeserializeObject<CloudError>(responseContent, this.Client.DeserializationSettings);
                if (errorBody != null)
                {
                    ex = new CloudException(errorBody.Message);
                    ex.Body = errorBody;
                }
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            // Create Result
            var result = new AzureOperationResponse<WorkflowVersion>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            if (httpResponse.Headers.Contains("x-ms-request-id"))
            {
                result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }
            // Deserialize Response
            if (statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK"))
            {
                string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                result.Body = JsonConvert.DeserializeObject<WorkflowVersion>(responseContent, this.Client.DeserializationSettings);
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

    }
}
