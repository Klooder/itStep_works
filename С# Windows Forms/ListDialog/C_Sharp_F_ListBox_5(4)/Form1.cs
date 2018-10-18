using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Sharp_F_ListBox_5_4_
{
    public partial class Form1 : Form
    {
        TableLayoutPanel TLP = new TableLayoutPanel();
        ListBox LB;
        Product P = new Product();
        int index = 0;

        public Form1()
        {
            InitializeComponent();

            TLP.ColumnCount = 1;
            TLP.RowCount = 3;
            TLP.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            TLP.Size = this.ClientSize;
            TLP.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

            RowStyle RS1 = new RowStyle(SizeType.Absolute, 20);
            TLP.RowStyles.Add(RS1);

            RowStyle RS2 = new RowStyle(SizeType.Percent, 100);
            TLP.RowStyles.Add(RS2);

            RowStyle RS3 = new RowStyle(SizeType.Absolute, 40);
            TLP.RowStyles.Add(RS3);

            this.Controls.Add(TLP);

            Label L = new Label();
            L.Text = "Список";
            L.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            TLP.Controls.Add(L);

            LB = new ListBox();
             LB.ColumnWidth=130;
            LB.MultiColumn = true;
            LB.SelectionMode = SelectionMode.MultiExtended;
            LB.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;
            TLP.Controls.Add(LB);

            FlowLayoutPanel FLP = new FlowLayoutPanel();
            FLP.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            TLP.Controls.Add(FLP);

            Button btnDel = new Button();
            btnDel.Text = "Delete";
            FLP.Controls.Add(btnDel);

            Button btnAdd = new Button();
            btnAdd.Text = "Add";
            FLP.Controls.Add(btnAdd);

            Button btnEdt = new Button();
            btnEdt.Text = "Edit";
            FLP.Controls.Add(btnEdt);

            btnDel.Click += ButtonDelete_Click;
            // btnAdd.Click += ButtonAdd_Click;
            btnEdt.Click += BtnEdt_Click;
            btnAdd.Click += BtnAdd_Click;

            // Заполнение ListBox элементами списка
            for (int i = 0; i < 10; i++)
            {
                LB.Items.Add(new Product("Snickers " + i, 12.5 + i, 45 + i % 10));
            }

        }

        private void BtnEdt_Click(object sender, EventArgs e)
        {
            Form2 F2 = new Form2();
            try
            {
                P = (Product)this.LB.SelectedItem;

                F2.textBoxName.Text = P.Name;
                F2.textBox2.Text = P.Price.ToString();
                F2.textBox3.Text = P.Weight.ToString();
                index = this.LB.SelectedIndex;

            }
            catch
            {
                MessageBox.Show("Ошибка!!! Не выбран элемент!!!");
                return;
            }

            if (F2.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    P.Name = F2.textBoxName.Text;
                    P.Price = Double.Parse(F2.textBox2.Text);
                    P.Weight = Int32.Parse(F2.textBox3.Text);

                }
                catch
                {
                    MessageBox.Show("Ошибка!!! Не верно заполненные поля");
                    return;
                }

                if (this.LB.SelectedIndex > -1)
                {
                    this.LB.Items.RemoveAt(this.LB.SelectedIndex);
                    LB.Items.Insert(index, P);
                }
                else
                {
                    LB.Items.Add(P);
                }
            }
            else
            {
                F2.Close();
            }

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            P = new Product();
            Form2 F2 = new Form2();

            if (F2.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    P.Name = F2.textBoxName.Text;
                    P.Price = Double.Parse(F2.textBox2.Text);
                    P.Weight = Int32.Parse(F2.textBox3.Text);

                }
                catch
                {
                    MessageBox.Show("Ошибка!!! Не верно заполненные поля");
                    return;
                }

                if (this.LB.SelectedIndex > -1)
                {
                    this.LB.Items.RemoveAt(this.LB.SelectedIndex);
                    LB.Items.Insert(index, P);
                }
                else
                {
                    LB.Items.Add(P);
                }

            }
            F2.textBoxName.Clear();
            F2.textBox2.Clear();
            F2.textBox3.Clear();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            int index = this.LB.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("Не выбран элемент списка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (MessageBox.Show("Вы уверены, что хотите удалить : \n" + this.LB.SelectedValue, "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.LB.Items.Remove(this.LB.SelectedItem);
            }
        }

    }
    class Product
    {
        public String Name { get; set; }
        public double Price { get; set; }
        public int Weight { get; set; }
        public Product()
        { }
        public Product(String name, double price, int weight)
        {
            this.Name = name;
            this.Price = price;
            this.Weight = weight;
        }
        public override string ToString()
        {
            return String.Format("{0}     {1}     {2}  ", this.Name, this.Price, this.Weight);
        }
    }
}
