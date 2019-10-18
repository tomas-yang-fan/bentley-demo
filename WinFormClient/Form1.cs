﻿using Newtonsoft.Json;
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
        private IList<Order> orders = new List<Order>();
        private string GetOrdersUrl;
        private string UpDataOrderUrl;
        private async void ShipOrderForm_Load(object sender, EventArgs e)
        {
            orders = await GetOrders();
            this.dataGridView1.DataSource = new BindingList<Order>(orders);
        }

        private async Task<IList<Order>> GetOrders()
        {
            GetOrdersUrl = ConfigurationManager.AppSettings["GetOrdersUrl"];
            var response = await HttpAPIClient.GetResponse(GetOrdersUrl, null);
            return JsonConvert.DeserializeObject<List<Order>>(response);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            int transactionNumber = (int)this.dataGridView1.SelectedRows[0].Cells["TransactionNumber"].Value;
            UpDataOrderUrl = ConfigurationManager.AppSettings["UpDataOrderUrl"];
             await HttpAPIClient.GetResponse($"{UpDataOrderUrl}?id={transactionNumber}", null,"PUT");
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            orders = await GetOrders();
            this.dataGridView1.DataSource = new BindingList<Order>(orders);
        }
    }
}