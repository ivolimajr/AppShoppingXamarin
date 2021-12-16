using AppShopping.Libraries.Helpers.MVVM;
using AppShopping.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace AppShopping.ViewModels
{
    public class TicketScanViewModel : BaseViewModel
    {
        public string TicketNumber { get; set; }
        public ICommand TicketTextChangeCommand { get; set; }
        public ICommand TicketScanCommand { get; set; }
        public ICommand TicketPaidHistoryCommand { get; set; }
        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                SetProperty(ref _message, value);
            }
        }

        public TicketScanViewModel()
        {
            TicketScanCommand = new MvvmHelpers.Commands.AsyncCommand(TicketScan);
            TicketPaidHistoryCommand = new Command(TicketPaidHistory);
            TicketTextChangeCommand = new Command(TicketTextChange);
        }

        private async Task TicketScan()
        {
            var scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += async (result) =>
            {
                scanPage.IsScanning = false;
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Shell.Current.Navigation.PopAsync();
                    Message = result.Text;

                    TicketProccess(result.Text);
                });

            };

            await Shell.Current.Navigation.PushAsync(scanPage);
        }
        private void TicketPaidHistory()
        {

        }
        private void TicketProccess(string ticketNumber)
        {
            try
            {
                var ticket = new TicketService().GetTicket(ticketNumber);
                if (ticket.Status == Libraries.Enums.TicketStatus.PAID)
                    Message = "Ticket Pago";
                if (ticket.Status == Libraries.Enums.TicketStatus.PEDING)
                    Message = "Aguardando pagamento valor de: " + ticket.Price ;

            }
            catch (Exception e)
            {

                Message = e.Message;
            }
        }
        private void TicketTextChange()
        {
            if(TicketNumber != null && TicketNumber.Length == 15)
            {
                TicketProccess(TicketNumber.Replace(" ", string.Empty));
            }
        }
    }
}
