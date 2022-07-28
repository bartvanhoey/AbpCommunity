using System;
using System.Threading.Tasks;
using EasyAbp.PrivateMessaging.PrivateMessageNotifications;
using EasyAbp.PrivateMessaging.PrivateMessages;
using EasyAbp.PrivateMessaging.PrivateMessages.Dtos;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Users;

namespace AddressBook.Application.PrivateMessaging
{

    [Dependency(ReplaceServices = true)]
    public class MyPrivateMessageAppService : PrivateMessageAppService
    {
        public MyPrivateMessageAppService(IDataFilter dataFilter, IExternalUserLookupServiceProvider externalUserLookupServiceProvider, IPrivateMessageRepository privateMessageRepository, IPrivateMessageSenderSideManager privateMessageSenderSideManager, IPrivateMessageReceiverSideManager privateMessageReceiverSideManager, IPrivateMessageNotificationRepository privateMessageNotificationRepository) : base(dataFilter, externalUserLookupServiceProvider, privateMessageRepository, privateMessageSenderSideManager, privateMessageReceiverSideManager, privateMessageNotificationRepository)
        {
        }

        public override Task<PrivateMessageDto> CreateAsync(CreateUpdatePrivateMessageDto input)
        {
            if (input.ToUserName == CurrentUser.UserName)
            {
                throw new UserFriendlyException("Don't send messages to yourself");
            }
            return base.CreateAsync(input);
        }

    }
}
