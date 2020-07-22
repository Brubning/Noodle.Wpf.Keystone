using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using Keystone.Api;

namespace Noodle.Wpf.Keystone.Services
{
    public class SessionService
    {
        /// <summary>
        /// Current KeystoneAPIChannel
        /// </summary>
        private IKeystoneAPI _currentChannel;

        /// <summary>
        /// Return a WCF client proxy for the Keystone API.
        /// </summary>
        /// <returns></returns>
        internal IKeystoneAPI GetKeystoneApiChannel()
        {
            if (_currentChannel != null)
                return _currentChannel;

            var binding = new BasicHttpsBinding();
            var endpointAddress = new EndpointAddress("https://keystone.kctmo.org.uk/keystoneapi/kapi.svc");
            var factory = new ChannelFactory<IKeystoneAPI>(binding, endpointAddress);
            
            _currentChannel = factory.CreateChannel();

            return _currentChannel;
        }

        /// <summary>
        /// Open a session using the current KeystoneAPI Channel.
        /// </summary>
        /// <returns></returns>
        internal async Task<Guid> OpenKeystoneSession(string username, string password, string database)
        {
            var api = GetKeystoneApiChannel();

            return await api.OpenSessionAsync(username, password, database);
        }

        /// <summary>
        /// Close a session using the current KeystoneAPI Channel.
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        internal async Task CloseKeystoneSession(Guid sessionId)
        {
            var api = GetKeystoneApiChannel();

            await api.CloseSessionAsync(sessionId);
        }

        /// <summary>
        /// Execute a call to the Entity service
        /// </summary>
        /// <returns></returns>
        internal async Task<List<object>> GetEntity(Guid sessionId)
        {
            var api = GetKeystoneApiChannel();
            var result = await api.GetEntityDataAsync(
                sessionId, 
                "Make Models", 
                new string[] { "intMakeModelID", "vchMake"}, 
                "where vchMake is not null");

            /*
            var result = await api.GetEntityDataAsync(
                sessionId, 
                "ServiceType", 
                new string[] { "Id", "Description"}, 
                "Description NOT LIKE 'XXXX'");
             */

            return result.ToList<object>();
        }
    }
}
