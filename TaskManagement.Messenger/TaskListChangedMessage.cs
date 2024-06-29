using CommunityToolkit.Mvvm.Messaging.Messages;

namespace TaskManagement.Messenger
{
    public class TaskListChangedMessage : ValueChangedMessage<bool>
    {
        public TaskListChangedMessage(bool value) : base(value)
        {
        }
    }
}
