using CommunityToolkit.Mvvm.Messaging.Messages;

namespace TaskManagement.Messenger
{
    public class RootSnackBarChangedMessage : ValueChangedMessage<string>
    {
        public RootSnackBarChangedMessage(string value) : base(value)
        {
        }
    }
}
