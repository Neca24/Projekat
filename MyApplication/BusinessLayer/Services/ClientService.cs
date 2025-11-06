using BusinessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using DataAccessLayer.Models;

namespace BusinessLayer.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly ILogger<ClientService> _logger;
        private readonly IHttpContextAccessor _http;

        private bool ipRecorded;
        public string? UserIp { get; set; }

        public ClientService(IClientRepository clientRepository, ILogger<ClientService> logger, IHttpContextAccessor http)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _http = http ?? throw new ArgumentNullException(nameof(http));
        }

        public async Task<bool> LogAsync(string ip)
        {
            var log = new Client
            {
                Ip = ip,
                DateTime = DateTime.Now
            };

            var res = await _clientRepository.AddAsync(log);

            if (res)
            {
                _logger.LogInformation("IP upisan");
                return true;
            }
            else
            {
                _logger.LogWarning("IP nije upisan");
                return false;
            }
        }
    }
}
