using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncDatabaseCancellationDemo
{
    public partial class Form1 : Form
    {
        Dictionary<Guid, CancellationTokenSource> _RequestsQueue;

        public Form1()
        {
            InitializeComponent();
            _RequestsQueue = new Dictionary<Guid, CancellationTokenSource>();
            Shown += Form1_Shown;
            customersList.SelectedIndexChanged += CustomersList_SelectedIndexChanged;
            clearListLinkLabel.Click += ClearListLinkLabel_Click;
        }

        private async void calculateCurrentCustomerAmount()
        {
            var customer = customersList.SelectedItem as dto.Customer;
            if (customer == null) return;

            Cursor = Cursors.AppStarting;            

            cancelPreviousPendingRequestFromQueue();
            var currentRequestCancellationTokenKey = createRequestCancellationTokenKey();
            addCurrentRequestCancellationTokenKeyToQueue(currentRequestCancellationTokenKey);
            updateUICalculatingCurrentRequest(customer);

            var amount = await getCustomerAmountFromDatabase(customer, currentRequestCancellationTokenKey);

            updateUICurrentRequestCustomerAmount(currentRequestCancellationTokenKey, amount);
            removeCurrentRequestFromQueue(currentRequestCancellationTokenKey);

            Cursor = Cursors.Default;
        }

        private void cancelPreviousPendingRequestFromQueue()
        {
            foreach (var token in _RequestsQueue)
                if (!token.Value.IsCancellationRequested)
                {
                    token.Value.Cancel();
                    requestsListBox.Items.Insert(0, string.Format("Request {0} -> CANCELLED", token.Key));
                }
        }

        private KeyValuePair<Guid, CancellationTokenSource> createRequestCancellationTokenKey()
        {
            var currentRequestCancellationToken = new CancellationTokenSource();
            var tokenKey = Guid.NewGuid();
            var currentRequestCancellationTokenKey = new KeyValuePair<Guid, CancellationTokenSource>(tokenKey, currentRequestCancellationToken);
            return currentRequestCancellationTokenKey;
        }

        private void addCurrentRequestCancellationTokenKeyToQueue(KeyValuePair<Guid, CancellationTokenSource> currentRequestCancellationTokenKey)
        {
            _RequestsQueue.Add(currentRequestCancellationTokenKey.Key, currentRequestCancellationTokenKey.Value);
            requestsListBox.Items.Insert(0, string.Format("Request {0} -> ADDED", currentRequestCancellationTokenKey.Key));
        }

        private void updateUICalculatingCurrentRequest(AsyncDatabaseCancellationDemo.dto.Customer customer)
        {
            customerIdLabel.Text = customer.ToString();
            customerAmountLabel.Text = "Calculating...";
        }

        private static async Task<decimal> getCustomerAmountFromDatabase(AsyncDatabaseCancellationDemo.dto.Customer customer, KeyValuePair<Guid, CancellationTokenSource> currentRequestCancellationTokenKey)
        {
            return await services.DatabaseService.GetCustomerCurrentAmount(customer.CustomerId, currentRequestCancellationTokenKey.Value);
        }

        private void updateUICurrentRequestCustomerAmount(KeyValuePair<Guid, CancellationTokenSource> currentRequestCancellationTokenKey, decimal amount)
        {
            if (!currentRequestCancellationTokenKey.Value.IsCancellationRequested)
            {
                customerAmountLabel.Text = amount.ToString("n2");
            }
        }

        private void removeCurrentRequestFromQueue(KeyValuePair<Guid, CancellationTokenSource> currentRequestCancellationTokenKey)
        {
            if (!currentRequestCancellationTokenKey.Value.IsCancellationRequested)
            {
                _RequestsQueue.Remove(currentRequestCancellationTokenKey.Key);
                requestsListBox.Items.Insert(0, string.Format("Request {0} -> FINISHED", currentRequestCancellationTokenKey.Key));
            }
        }

        private void ClearListLinkLabel_Click(object sender, EventArgs e)
        {
            requestsListBox.Items.Clear();
        }

        private async void Form1_Shown(object sender, EventArgs e)
        {
            await loadCustomers();
        }

        private async Task loadCustomers()
        {
            var customers = await services.DatabaseService.GetCustomersList();
            customersList.Items.Clear();
            customers.ForEach(p => customersList.Items.Add(p));
        }
        
        private void CustomersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculateCurrentCustomerAmount();
        }

    }
}
