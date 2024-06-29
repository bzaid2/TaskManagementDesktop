using CommunityToolkit.Mvvm.Messaging.Messages;

namespace TaskManagement.Messenger
{
    public class CloseRootDrawerhostChangedMessage : ValueChangedMessage<bool>
    {
        public CloseRootDrawerhostChangedMessage(bool value) : base(value)
        {
        }
    }
}
