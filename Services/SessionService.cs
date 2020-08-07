using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using Keystone.Api;
using api = Keystone.Api;
using Noodle.Wpf.Keystone.Models;
using Noodle.Wpf.Keystone.ViewModels;
using Visit = Noodle.Wpf.Keystone.Models.Visit;

namespace Noodle.Wpf.Keystone.Services
{
    public class SessionService
    {
        /// <summary>
        /// Current KeystoneAPIChannel
        /// </summary>
        private api.IKeystoneAPI _currentChannel;

        /// <summary>
        /// Return a WCF client proxy for the Keystone API.
        /// </summary>
        /// <returns></returns>
        internal api.IKeystoneAPI GetKeystoneApiChannel()
        {
            if (_currentChannel != null)
                return _currentChannel;

            var binding = new BasicHttpsBinding {MaxReceivedMessageSize = int.MaxValue};
            var endpointAddress = new EndpointAddress("https://keystone.kctmo.org.uk/keystoneapi/kapi.svc");
            var factory = new ChannelFactory<api.IKeystoneAPI>(binding, endpointAddress);
            
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
        /// Get a list of all Competencys
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        internal async Task<List<Competency>> GetCompetencys(Guid sessionId)
        {
            var api = GetKeystoneApiChannel();
            var result = await api.GetEntityDataAsync(
                sessionId, 
                "Competency", 
                new []
                {
                    "Id",
                    "Description"
                },
                "WHERE 1=1");

            var typedResult = result.Cast<object[]>().Select(x => new Competency
            {
                Id = GetInt32(x[0]),
                Description = GetString(x[1])
            });

            return typedResult.ToList(); 
        }

        /// <summary>
        /// Get a list of all Contacts
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        internal async Task<List<Contact>> GetContacts(Guid sessionId)
        {
            var api = GetKeystoneApiChannel();
            var result = await api.GetEntityDataAsync(
                sessionId, 
                "Contact", 
                new []
                {
                    "Id",
                    "JobTitle",
                    "Name",
                    "Address1",
                    "Address2",
                    "Address3",
                    "Address4",
                    "Postcode",
                    "Email1",
                    "Email2",
                    "Telephone1",
                    "Ext1",
                    "Telephone2",
                    "Ext2",
                    "Notes",
                    "ParentId",
                    "Description",
                    "CompanyRegistration",
                    "Url",
                    "Title",
                    "IsPrimary"
                },
                "WHERE 1=1");

            var typedResult = result.Cast<object[]>().Select(x => new Contact
            {
                Id = GetInt32(x[0]),
                JobTitle = GetString(x[1]),
                Name = GetString(x[2]),
                Address1 = GetString(x[3]),
                Address2 = GetString(x[4]),
                Address3 = GetString(x[5]),
                Address4 = GetString(x[6]),
                Postcode = GetString(x[7]),
                Email1 = GetString(x[8]),
                Email2 = GetString(x[9]),
                Telephone1 = GetString(x[10]),
                Ext1 = GetString(x[10]),
                Telephone2 = GetString(x[12]),
                Ext2 = GetString(x[13]),
                Notes = GetString(x[14]),
                ParentId = GetNullableInt32(x[15]),
                Description = GetString(x[16]),
                CompanyRegistration = GetString(x[17]),
                Url = GetString(x[18]),
                Title = GetString(x[19]),
                IsPrimary = GetBoolean(x[20])
            });

            return typedResult.ToList(); 
        }

        /// <summary>
        /// Get a list of all EquipmentTypes
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        internal async Task<List<EquipmentType>> GetEquipmentTypes(Guid sessionId)
        {
            var api = GetKeystoneApiChannel();
            var result = await api.GetEntityDataAsync(
                sessionId, 
                "EquipmentType", 
                new []
                {
                    "Id",
                    "CompetencyId",
                    "Description"
                },
                "WHERE Description NOT LIKE 'XX%'");

            var typedResult = result.Cast<object[]>().Select(x => new EquipmentType
            {
                Id =GetInt32 (x[0]),
                CompetencyId = GetNullableInt32(x[1]),
                Description = GetString(x[2])
            });

            return typedResult.ToList(); 
        }

        /// <summary>
        /// Get a list of all MakeModel
        /// </summary>
        /// <returns></returns>
        internal async Task<List<MakeModel>> GetMakeModels(Guid sessionId)
        {
            var api = GetKeystoneApiChannel();
            var result = await api.GetEntityDataAsync(
                sessionId, 
                "MakeModel", 
                new []
                {
                    "Id",
                    "EquipmentTypeId",
                    "Make",
                    "Model",
                    "Reference",
                    "SubModel"
                }, 
                "where Make is not null");

            var typedResult = result.Cast<object[]>().Select(x => new MakeModel
            {
                Id = GetInt32(x[0]),
                EquipmentTypeId = GetInt32(x[1]),
                Make = GetString(x[2]),
                Model = GetString(x[3]),
                Reference = GetString(x[4]),
                SubModel = GetString(x[5])
            });

            return typedResult.ToList(); 
        }

        /// <summary>
        /// Get a list of all ServiceTypes
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        internal async Task<List<ServiceType>> GetServiceTypes(Guid sessionId)
        {
            var api = GetKeystoneApiChannel();
            var result = await api.GetEntityDataAsync(
                sessionId, 
                "ServiceType", 
                new []
                {
                    "ServiceTypeId",
                    "Description",
                    "Interval",
                    "Duration",
                    "Cost",
                    "IntervalType",
                    "DocumentPrefix"
                }, 
                "WHERE Description NOT LIKE 'XX%'");

            var typedResult = result.Cast<object[]>().Select(x => new ServiceType
            {
                Id = GetInt32(x[0]),
                Description = GetString(x[1]),
                Interval = GetInt32(x[2]),
                Duration = GetInt32(x[3]),
                Cost= GetDouble(x[4]),
                IntervalType = GetInt32(x[5]),
                DocumentPrefix = GetString(x[6])
            });

            return typedResult.ToList(); 
        }

        /// <summary>
        /// Get asset by UPRN
        /// </summary>
        /// <returns></returns>
        internal async Task<List<Asset>> GetAsset(Guid sessionId, AssetSearchCriteria searchCriteria)
        {
            var api = GetKeystoneApiChannel();
            var result = await api.GetAssetInfoAsync(sessionId, searchCriteria.Uprn);

            var asset = new Asset
            {
                AssetId = result.AssetId,
                Uprn = result.UPRN,
                Status = GetAssetStatus(result.Status),
                NlpgUprn = result.NlpgUprn,
                ManagementGroup = result.ManagementGroup,
                AssetType = result.AssetType,
                ParentUprn = result.ParentUprn,
                HouseName = result.HouseName,
                Block = result.Block,
                Address1 = result.Address1,
                Address2 = result.Address2,
                Address3 = result.Address3,
                Address4 = result.Address4,
                PostCode = result.PostCode,
                OsLocation = result.OSLocation,
                LastSurveyor = result.LastSurveyor,
                LastSurveyDate = result.LastSurveyDate,
                NextSurveyDate = result.NextSurveyDate,
                Owner = result.Owner,
                OwnerChangedDate = result.OwnerChangedDate,
                OwnershipPercentage = result.OwnershipPercentage,
                MarketValue = result.MarketValue,
                AnnualRent = result.AnnualRent,
                AnnualOverheads = result.AnnualOverheads,
                Prn = result.PRN,
                BaseAnalysisType = result.BaseAnalysisType,
                XLocation = result.XLocation,
                YLocation = result.YLocation,
                AnalysisClasses = GetAnalysisClasses(result.AnalysisClassInfo)
            };

            return new List<Asset> { asset };
        }

        /// <summary>
        /// Add completed visit and return saved entity
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="visit"></param>
        /// <returns></returns>
        internal async Task<Visit> AddCompletedVisit(Guid sessionId, Visit visit)
        {
            var api = GetKeystoneApiChannel();
            var saved = await api.AddCompletedVisitAsync(
                sessionId,
                new api.Visit
                {
                    UPRN = visit.Uprn,
                    ServiceType = visit.ServiceType,
                    Organisation = visit.Organisation,
                    Due = visit.Due,
                    Actual = visit.Actual,
                    Outcome = visit.Outcome,
                    Comments = visit.Comments
                });

            visit.VisitId = saved.VisitId;
            visit.AssetId = saved.AssetId;
            visit.ServiceTypeId = saved.ServiceTypeId;
            visit.OrganisationId = saved.OrganisationId;
            visit.OutcomeId = saved.OutcomeId;

            return visit;
        }

        internal async Task AddCertificateToVisit(Guid sessionId, string path, Visit visit)
        {
            var title = System.IO.Path
                .GetFileNameWithoutExtension(path)
                .Replace('-', ' ');
            var api = GetKeystoneApiChannel();
            await api.AddAttachmentAsync(
                sessionId,
                new AttachmentInfo
                {
                    ObjectType = ObjectTypes.Visit,
                    ObjectId = visit.VisitId,
                    Title = title,
                    Description = title,
                    Extension = System.IO.Path.GetExtension(path),
                    Path = path
                });
        }

        #region Conversion helpers

        //TODO Convert to generics and extensions

        /// <summary>
        /// Safe method to get a boolean from an empty string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool GetBoolean(object value)
        {
            var input = value?.ToString() ?? string.Empty;
            var isValid = bool.TryParse(input, out var result);

            return isValid && result;
        }

        private int GetInt32(object value)
        {
            var input = value?.ToString() ?? string.Empty;
            var isValid = int.TryParse(input, out var result);

            return isValid ? result : 0;
        }

        private int? GetNullableInt32(object value)
        {
            var input = value?.ToString() ?? string.Empty;
            var isValid = int.TryParse(input, out var result);

            return isValid ? result : (int?)null;
        }

        private double GetDouble(object value)
        {
            var input = value?.ToString();
            var isValid = double.TryParse(input, out var result);

            return isValid ? result : 0d;
        }

        private string GetString(object value)
        {
            var input = value?.ToString() ?? string.Empty;
            return input;
        }

        private AssetStatus GetAssetStatus(api.AssetInfo.AssetStatus status)
        {
            return status switch
            {
                api.AssetInfo.AssetStatus.Copied => AssetStatus.Copied,
                api.AssetInfo.AssetStatus.Surveyed => AssetStatus.Surveyed,
                api.AssetInfo.AssetStatus.SurveyedSelfRepresenting => AssetStatus.SurveyedSelfRepresenting,
                api.AssetInfo.AssetStatus.Unsurveyed => AssetStatus.Unsurveyed,
                _ => AssetStatus.Unsurveyed
            };
        }

        private List<AnalysisClass> GetAnalysisClasses(IEnumerable<api.AssetInfo.ClassInfo> classes)
        {
            return classes
                .Select(x => new AnalysisClass
                {
                    ClassName = x.AnalysisClass,
                    TypeValue = x.AnalysisType
                })
                .ToList();
        }

        #endregion
    }
}
