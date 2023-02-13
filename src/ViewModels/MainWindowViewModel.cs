using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MvvmTutorials.ToolkitMessages.ViewModels;

public partial class MainWindowViewModel
    : ObservableRecipient,
      IRecipient<PropertyChangedMessage<string>>
{
    [ObservableProperty]
    private string information = "INSERT INTO Students ...";

    /// <summary>
    /// 接收来自 <see cref="StudentFormViewModel"/> 的属性变化的消息，并更新 <see cref="Information"/>
    /// </summary>
    public void Receive(PropertyChangedMessage<string> message)
    {
        if (message.Sender is StudentFormViewModel vm)
            Information = vm.SqlQuery;
    }
}