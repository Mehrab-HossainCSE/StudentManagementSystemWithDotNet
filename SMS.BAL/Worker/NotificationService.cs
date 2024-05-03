using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.BAL.Worker
{
    public class NotificationService : BackgroundService
    {
        private readonly ILogger<NotificationService> _logger;

        public NotificationService(ILogger<NotificationService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // Perform data processing tasks
                // Generate notifications for specific events

                _logger.LogInformation("Data processing and notification using Worker Service  generation completed at: {time}", DateTimeOffset.Now);

                // Wait for an hour before running again
                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
               
            }
        }
    }
}
