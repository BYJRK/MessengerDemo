using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using MvvmTutorials.ToolkitMessages.Models;
using System.Collections.ObjectModel;

namespace MvvmTutorials.ToolkitMessages.ViewModels;

public partial class StudentListViewModel
    : ObservableRecipient,
      IRecipient<ValueChangedMessage<Student>>
{
    public ObservableCollection<Student> Students { get; } = new();

    [ObservableProperty]
    private bool allowAddNew;

    public int StudentCount => Students?.Count ?? 0;

    public StudentListViewModel()
    {
        Students.CollectionChanged += (_, _) => OnPropertyChanged(nameof(StudentCount));
    }
    
    partial void OnAllowAddNewChanged(bool value)
    {
        WeakReferenceMessenger.Default.Send(new ValueChangedMessage<bool>(value));
    }

    public void Receive(ValueChangedMessage<Student> message)
    {
        Students.Add(message.Value);
    }
}