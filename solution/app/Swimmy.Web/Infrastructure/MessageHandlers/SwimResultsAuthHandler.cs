namespace Swimmy.Web.Infrastructure.MessageHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;

    using Swimmy.Services.Contracts;
    using Swimmy.Web.Infrastructure.Extensions;

    public class SwimResultsAuthHandler : DelegatingHandler
    {
        IEnumerable<string> authHeaderValues;

        /// <summary>
        /// Sends an HTTP request to the inner handler to send to the server as an asynchronous operation.
        /// </summary>
        /// <returns>
        /// Returns <see cref="T:System.Threading.Tasks.Task`1"/>. The task object representing the asynchronous operation.
        /// </returns>
        /// <param name="request">The HTTP request message to send to the server.</param><param name="cancellationToken">A cancellation token to cancel operation.</param><exception cref="T:System.ArgumentNullException">The <paramref name="request"/> was null.</exception>
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            try
            {
                request.Headers.TryGetValues("Authorization", out this.authHeaderValues);
                if (this.authHeaderValues == null)
                {
                    return base.SendAsync(request, cancellationToken);
                }

                var tokens = this.authHeaderValues.FirstOrDefault();
                tokens = tokens.Replace("Basic", string.Empty).Trim();

                if (string.IsNullOrEmpty(tokens))
                {
                    var data = Convert.FromBase64String(tokens);
                    var decodeString = Encoding.UTF8.GetString(data);
                    var tokensValues = decodeString.Split(':');
                    IMembershipService membershipService = request.GetMembershipService();
                    var membershipCtx = membershipService.ValidateUser(tokensValues[0], tokensValues[1]);
                    if (membershipCtx.User != null)
                    {
                        var principal = membershipCtx.Principal;
                        Thread.CurrentPrincipal = principal;
                        HttpContext.Current.User = principal;
                    }
                    else
                    {
                        return BuildHttpResonseMessage(HttpStatusCode.Unauthorized);
                    }
                }
                else
                {
                    return BuildHttpResonseMessage(HttpStatusCode.Forbidden);
                }
            }
            catch
            {
                return BuildHttpResonseMessage(HttpStatusCode.Forbidden);
            }

            return base.SendAsync(request, cancellationToken);
        }

        private static Task<HttpResponseMessage> BuildHttpResonseMessage(HttpStatusCode httpStatusCode)
        {
            var response = new HttpResponseMessage(httpStatusCode);
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }
    }
}