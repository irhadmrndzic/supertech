using superTech.Models.ReportsModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace superTech.WinUI.Reports
{
    public partial class Reports : Form
    {
        private readonly APIService.APIService _reportsService = new APIService.APIService("reports");
        public Reports()
        {
            InitializeComponent();
        }
        private void DisplayStringListInDataGrid(List<string> passedList, ref DataGridView gridToUpdate, string newColumnHeader)
        {
            DataTable gridData = new DataTable();
            gridData.Columns.Add(newColumnHeader);

            foreach (string listItem in passedList)
            {
                gridData.Rows.Add(listItem);
            }

            BindingSource gridDataBinder = new BindingSource();
            gridDataBinder.DataSource = gridData;
            dgvMostSoldProducts.DataSource = gridDataBinder;
        }

        private async void Reports_Load(object sender, EventArgs e)
        {


            ReportsModel req = new ReportsModel();
            var reports = await _reportsService.Get<ReportsModel>(req);
            lblEmployeesCount.Text = reports.EmployeesCount.ToString();
            lblBuyersCount.Text = reports.BuyersCount.ToString();
      
            lblProductsCount.Text = reports.AllProductCount.ToString();
            lblBuyerOrdersCount.Text = reports.BuyerOrdersCount.ToString();
            lblProductsSold.Text = reports.ProductsSold.ToString();
            lblBuyerBillsSum.Text = reports.BuyerBillsSum;
            pbEmployees.SizeMode = PictureBoxSizeMode.Zoom;
            dgvMostSoldProducts.AutoGenerateColumns = false;

            dgvMostSoldProducts.ClearSelection();
            Color back = Color.FromKnownColor(KnownColor.ControlLight);

            dgvMostSoldProducts.RowsDefaultCellStyle.SelectionBackColor = back;
            dgvMostSoldProducts.RowsDefaultCellStyle.SelectionForeColor = Color.Black;

            dgvMostSoldProducts.Columns[0].Width = 200;
            dgvMostSoldProducts.Columns[1].Width = 53;
            dgvMostSoldProducts.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMostSoldProducts.DataSource = reports.TopSoldProducts;

            dgvMonthlyOrders.Columns[1].Width = 80;
            dgvMonthlyOrders.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMonthlyOrders.AutoGenerateColumns = false;

            dgvMonthlyOrders.DataSource = reports.MonthlyOrders;

            dgvMostSoldProducts.ScrollBars = ScrollBars.None;
            dgvMonthlyOrders.ScrollBars = ScrollBars.None;
            dgvMonthlyOrders.RowsDefaultCellStyle.SelectionBackColor = back;
            dgvMonthlyOrders.RowsDefaultCellStyle.SelectionForeColor = Color.Black;

            dgvProdsByDate.RowsDefaultCellStyle.SelectionBackColor = back;
            dgvProdsByDate.RowsDefaultCellStyle.SelectionForeColor = Color.Black;


            dgvProdsByDate.Columns[0].Width = 200;
            dgvProdsByDate.Columns[1].Width = 50;
            dgvProdsByDate.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProdsByDate.AutoGenerateColumns = false;





            this.panel1.BorderStyle = BorderStyle.None;
            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width,
                  panel1.Height, 8, 8));

            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width,
                 panel2.Height, 8, 8));

            panel3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel3.Width,
             panel3.Height, 8, 8));

            panel4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel4.Width,
            panel4.Height, 8, 8));


            panel5.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel5.Width,
            panel5.Height, 8, 8));

            panel6.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel6.Width,
            panel6.Height, 8, 8));


            panel7.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel7.Width,
            panel7.Height, 8, 8));


            panel8.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel8.Width,
            panel8.Height, 8, 8));

            panel9.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel9.Width,
            panel9.Height, 8, 8));
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
       (
           int nLeftRect,     // x-coordinate of upper-left corner
           int nTopRect,      // y-coordinate of upper-left corner
           int nRightRect,    // x-coordinate of lower-right corner
           int nBottomRect,   // y-coordinate of lower-right corner
           int nWidthEllipse, // height of ellipse
           int nHeightEllipse // width of ellipse
       );

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            ReportsSearchRequest req = new ReportsSearchRequest();
            req.DateFrom = dtpDateFrom.Value;
            req.DateTo = dtpDateTo.Value;

            ReportsModel model = await _reportsService.Get<ReportsModel>(req);
            dgvProdsByDate.DataSource = model.TopProductsByDateModel;
        }

        private void dgvProdsByDate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }


}

