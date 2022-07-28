using System;
using System.Threading.Tasks;
using TemplateReplace.Domain.Emailing;
using Volo.Abp.Application.Services;

namespace TemplateReplace.Application
{
    public class EmailAppService : ApplicationService
    {
        private readonly EmailService _emailService;

        public EmailAppService(EmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task SendEmailAsync()
        {
            await _emailService.SendAsync("bartvanhoey@hotmail.com");
        }
    }
}
