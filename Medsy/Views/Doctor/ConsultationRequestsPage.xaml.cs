using MedSy.Models;
using MedSy.ViewModels;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MedSy.Views.Doctor
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ConsultationRequestsPage : Page
    {
        private ConsultationRequestsViewModel consultationRequestsViewModel;
        public ConsultationRequestsPage()
        {
            this.InitializeComponent();
            consultationRequestsViewModel = new ConsultationRequestsViewModel();
            ConsultationRequestUC consultationRequestUC = new ConsultationRequestUC(consultationRequestsViewModel);
            consultationRequestUC.CreateRoomClickedEvent += NavigateToOnlineConsultation;
            root.Children.Add(consultationRequestUC);
        }

        private void ReturnConsultationRequestsClicked()
        {
            consultationRequestsViewModel.UpdateNextConsultationTodayToDone();
            root.Children.Clear();
            ConsultationRequestUC consultationRequestUC = new ConsultationRequestUC(consultationRequestsViewModel);
            consultationRequestUC.CreateRoomClickedEvent += NavigateToOnlineConsultation;
            root.Children.Add(consultationRequestUC);

        }
        private void NavigateToOnlineConsultation()
        {
            root.Children.Clear();
            OnlineConsultationUC onlineConsultationUC = new OnlineConsultationUC(consultationRequestsViewModel);
            onlineConsultationUC.ReturnConsultationRequestsEvent += ReturnConsultationRequestsClicked;
            root.Children.Add(onlineConsultationUC);
        }
    }
}
