using Microsoft.Extensions.Options;
using Tutorial.Models;

namespace Tutorial.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly NewBookAlertConfig _newBookAlertConfiguration;
        private NewBookAlertConfig _newBookAlertConfigurationMonitor;
        private readonly IOptionsMonitor<NewBookAlertConfig> _newBookAlertConfigurationMonitor2;

        public MessageRepository(
            IOptions<NewBookAlertConfig> newBookAlertConfiguration,
            IOptionsMonitor<NewBookAlertConfig> newBookAlertConfigurationMonitor)
        {
            _newBookAlertConfiguration = newBookAlertConfiguration.Value;
            _newBookAlertConfigurationMonitor = newBookAlertConfigurationMonitor.CurrentValue;
            newBookAlertConfigurationMonitor.OnChange(config =>
            {
                _newBookAlertConfigurationMonitor = config;
            });
            _newBookAlertConfigurationMonitor2 = newBookAlertConfigurationMonitor;
        }

        public string GetMessage()
        {
            return _newBookAlertConfiguration.Message;
        }

        public string GetMessageMonitor()
        {
            return _newBookAlertConfigurationMonitor.Message;
        }

        public string GetMessageMonitor2()
        {
            return _newBookAlertConfigurationMonitor2.CurrentValue.Message;
        }

    }
}
