using MvvmHelpers.Commands;
using Seagullfly.Interfaces;
using Seagullfly.Models;
using Seagullfly.Views;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Seagullfly.ViewModels
{
    public class FeadbackViewModel : ViewModelBase
    {
        List<string> topics;
        public List<string> Topics
        {
            get => topics;
            set => SetProperty(ref topics, value);
        }
        int selectedTopicIndex;
        public int SelectedTopicIndex
        {
            get => selectedTopicIndex;
            set => SetProperty(ref selectedTopicIndex, value);
        }
        string email;
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
        string title;
        new public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
        string description;
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public ICommand TrySendEmailCommand { get; }
        public ICommand SelectTopic { get; }

        IEmailService emailService;

        public FeadbackViewModel()
        {
            Topics = new List<string>()
            {
                "Question",
                "Error",
                "Review"
            };

            TrySendEmailCommand = new AsyncCommand(SendEmail);
            emailService = DependencyService.Get<IEmailService>();
        }

        async Task SendEmail()
        {
            var request = new EmailRequest()
            {
                From = email,
                Title = topics[SelectedTopicIndex],
                Description = title,
                Message = description
            };

            emailService.SendAsync(request);

            ClearForm();
            await Shell.Current.GoToAsync($"{nameof(SeagullflyPage)}");
        }

        private void ClearForm()
        {
            Email = string.Empty;
            Title = string.Empty;
            Description = string.Empty;
        }
    }
}
