using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormClient.Common;
using WinFormClient.Data;

namespace WinFormClient
{
    public partial class ShipOrderForm : Form
    {
        public ShipOrderForm()
        {
            InitializeComponent();
        }
        private List<Order> orders = new List<Order>();
        private string GetOrdersUrl;
        private string UpDataOrderUrl;
        private async void ShipOrderForm_Load(object sender, EventArgs e)
        {
            try
            {
                orders = await GetOrders();
                this.dataGridView1.DataSource = new BindingList<Order>(orders);
            }
            catch (Exception)
            {
                MessageBox.Show("Can not find orders");
            }

        }

        private async Task<List<Order>> GetOrders()
        {
            GetOrdersUrl = ConfigurationManager.AppSettings["GetOrdersUrl"];
            var response = await HttpAPIClient.GetResponse(GetOrdersUrl, null);
            return JsonConvert.DeserializeObject<List<Order>>(response);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int transactionNumber = (int)this.dataGridView1.SelectedRows[0].Cells["TransactionNumber"].Value;
                UpDataOrderUrl = ConfigurationManager.AppSettings["UpDataOrderUrl"];
                this.orders.ForEach(order =>
                {
                    if(order.TransactionNumber == transactionNumber)
                    {
                        order.Status = "S";
                    }
                });
                this.dataGridView1.Refresh();
                await HttpAPIClient.GetResponse($"{UpDataOrderUrl}?id={transactionNumber}", null, "PUT");
                
            }
            catch (Exception)
            {
                MessageBox.Show("Can not find orders");
            }


        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                orders = await GetOrders();
                this.dataGridView1.DataSource = new BindingList<Order>(orders);

            }
            catch (Exception)
            {
                MessageBox.Show("Can not find orders");
            }


        }
    }
}
