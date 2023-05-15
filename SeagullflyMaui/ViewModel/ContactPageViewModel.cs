using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SeagullflyMaui.Interfaces;
using SeagullflyMaui.Model;

namespace SeagullflyMaui.ViewModel;
public partial class ContactPageViewModel : BaseViewModel
{
	[ObservableProperty]
	List<string> topics;

    [ObservableProperty]
    int selectedTopicIndex;

    [ObservableProperty]
	string email;

    [ObservableProperty]
    string description;

    readonly IEmailService emailService;

    public ContactPageViewModel(IEmailService emailService)
	{
		Title = "KONTAKT";
        topics = new List<string>()
            {
                "Pytanie",
                "Błąd",
                "Ocena"
            };

        this.emailService = emailService;
    }

    [RelayCommand]
    async Task SendEmail()
    {
        var request = new EmailRequest()
        {
            From = email,
            Title = topics[SelectedTopicIndex],
            Description = title,
            Message = description
        };

        await emailService.SendAsync(request);

        ClearForm();
    }

    private void ClearForm()
    {
        Email = string.Empty;
        Title = string.Empty;
        Description = string.Empty;
    }
}
