using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ListView2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 50; i++)
            {
                Product P = new Product("Snikers" + i, 12.5 + i % 10, 45 + i % 5);
                this.listView1.Items.Add(P);
                this.comboBox1.SelectedIndex = 0 ;
            }
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            switch (((ComboBoxItem)(this.comboBox1.SelectedItem)).Name)
            {
                case "bigImg":
                    this.bigImageList();
                    break;
                case "smallImg":
                    this.smallImageList();
                    break;
                case "list":
                    this.ImageList();
                    break;
                case "table":
                    this.tableView();
                    break;
                case "title":
                    this.titleImageList();
                    break;
            }
        }
        private void titleImageList()
        {
            DataTemplate DT = new DataTemplate();
            FrameworkElementFactory fefMain = new FrameworkElementFactory(typeof(UniformGrid));
            fefMain.SetValue(UniformGrid.HeightProperty, 70.0);
            fefMain.SetValue(UniformGrid.RowsProperty, 3);
            fefMain.SetValue(UniformGrid.ColumnsProperty, 1);


            FrameworkElementFactory fefLabelName = new FrameworkElementFactory(typeof(Label));
            Binding bindLabelName = new Binding();
            bindLabelName.Path = new PropertyPath("name");
            fefLabelName.SetBinding(Label.ContentProperty, bindLabelName);

            fefMain.AppendChild(fefLabelName);

            FrameworkElementFactory fefLabelPrice = new FrameworkElementFactory(typeof(Label));
            Binding bindLabelPrice = new Binding();
            bindLabelPrice.Path = new PropertyPath("price");
            fefLabelPrice.SetValue(Label.ContentProperty, bindLabelPrice);
            fefMain.AppendChild(fefLabelPrice);

            FrameworkElementFactory fefLabelWeight = new FrameworkElementFactory(typeof(Label));
            Binding bindLabelWeight = new Binding();
            bindLabelWeight.Path = new PropertyPath("weight");
            fefLabelWeight.SetBinding(Label.ContentProperty, bindLabelWeight);
            fefMain.AppendChild(fefLabelWeight);

            DT.VisualTree = fefMain;
            this.listView1.ItemTemplate = DT;

            this.listView1.View = null;

            ItemsPanelTemplate IPT = new ItemsPanelTemplate();
            FrameworkElementFactory fefItemsPanel = new FrameworkElementFactory(typeof(WrapPanel));

            Binding bindWidth = new System.Windows.Data.Binding("ActualWidth");
            bindWidth.Source = this.listView1;

            fefItemsPanel.SetValue(WrapPanel.HeightProperty, bindWidth);
            fefItemsPanel.SetValue(WrapPanel.OrientationProperty, Orientation.Vertical);
            IPT.VisualTree = fefItemsPanel;
            this.listView1.ItemsPanel = IPT;
        }
            private void ImageList()
        {
            DataTemplate DT = new DataTemplate();
            FrameworkElementFactory fefMain = new FrameworkElementFactory(typeof(UniformGrid));
            fefMain.SetValue(UniformGrid.HeightProperty, 25.0);
            fefMain.SetValue(UniformGrid.RowsProperty, 0);
            fefMain.SetValue(UniformGrid.ColumnsProperty, 3);


            FrameworkElementFactory fefLabelName = new FrameworkElementFactory(typeof(Label));
            Binding bindLabelName = new Binding();
            bindLabelName.Path = new PropertyPath("name");
            fefLabelName.SetBinding(Label.ContentProperty, bindLabelName);

            fefMain.AppendChild(fefLabelName);
          
            FrameworkElementFactory fefLabelPrice = new FrameworkElementFactory(typeof(Label));
            Binding bindLabelPrice = new Binding();
            bindLabelPrice.Path = new PropertyPath("price");
            fefLabelPrice.SetValue(Label.ContentProperty, bindLabelPrice);
            fefMain.AppendChild(fefLabelPrice);

            FrameworkElementFactory fefLabelWeight = new FrameworkElementFactory(typeof(Label));
            Binding bindLabelWeight = new Binding();
            bindLabelWeight.Path = new PropertyPath("weight");
            fefLabelWeight.SetBinding(Label.ContentProperty, bindLabelWeight);
            fefMain.AppendChild(fefLabelWeight);

            DT.VisualTree = fefMain;
            this.listView1.ItemTemplate = DT;

            this.listView1.View = null;

            ItemsPanelTemplate IPT = new ItemsPanelTemplate();
            FrameworkElementFactory fefItemsPanel = new FrameworkElementFactory(typeof(WrapPanel));

            Binding bindWidth = new System.Windows.Data.Binding("ActualHeight");
            bindWidth.Source = this.listView1;

            fefItemsPanel.SetValue(WrapPanel.HeightProperty, bindWidth);
            fefItemsPanel.SetValue(WrapPanel.OrientationProperty, Orientation.Vertical);
            IPT.VisualTree = fefItemsPanel;
            this.listView1.ItemsPanel = IPT;
        }
            private void smallImageList()
        {
            DataTemplate DT = new DataTemplate();
            FrameworkElementFactory fefMain = new FrameworkElementFactory(typeof(UniformGrid));
            fefMain.SetValue(UniformGrid.WidthProperty, 70.0);
            fefMain.SetValue(UniformGrid.RowsProperty, 2);
            fefMain.SetValue(UniformGrid.ColumnsProperty, 1);

            FrameworkElementFactory fefSecondRow = new FrameworkElementFactory(typeof(UniformGrid));
            fefSecondRow.SetValue(UniformGrid.RowsProperty, 1);
            fefSecondRow.SetValue(UniformGrid.ColumnsProperty, 2);

            FrameworkElementFactory fefLabelName = new FrameworkElementFactory(typeof(Label));
            Binding bindLabelName = new Binding();
            bindLabelName.Path = new PropertyPath("name");
            fefLabelName.SetBinding(Label.ContentProperty, bindLabelName);

            fefMain.AppendChild(fefLabelName);
            fefMain.AppendChild(fefSecondRow);

            FrameworkElementFactory fefLabelPrice = new FrameworkElementFactory(typeof(Label));
            Binding bindLabelPrice = new Binding();
            bindLabelPrice.Path = new PropertyPath("price");
            fefLabelPrice.SetValue(Label.ContentProperty, bindLabelPrice);
            fefSecondRow.AppendChild(fefLabelPrice);

            FrameworkElementFactory fefLabelWeight = new FrameworkElementFactory(typeof(Label));
            Binding bindLabelWeight = new Binding();
            bindLabelWeight.Path = new PropertyPath("weight");
            fefLabelWeight.SetBinding(Label.ContentProperty, bindLabelWeight);
            fefSecondRow.AppendChild(fefLabelWeight);

            DT.VisualTree = fefMain;
            this.listView1.ItemTemplate = DT;

            this.listView1.View = null;

            ItemsPanelTemplate IPT = new ItemsPanelTemplate();
            FrameworkElementFactory fefItemsPanel = new FrameworkElementFactory(typeof(WrapPanel));

            Binding bindWidth = new System.Windows.Data.Binding("ActualHeight");
            bindWidth.Source = this.listView1;

            fefItemsPanel.SetValue(WrapPanel.HeightProperty, bindWidth);
            fefItemsPanel.SetValue(WrapPanel.OrientationProperty, Orientation.Vertical);
            IPT.VisualTree = fefItemsPanel;
            this.listView1.ItemsPanel = IPT;
        }

            private void bigImageList()
        {
            DataTemplate DT = new DataTemplate();
            FrameworkElementFactory fefMain = new FrameworkElementFactory(typeof(UniformGrid));
            fefMain.SetValue(UniformGrid.WidthProperty, 100.0);
            fefMain.SetValue(UniformGrid.RowsProperty, 2);
            fefMain.SetValue(UniformGrid.ColumnsProperty, 1);

            FrameworkElementFactory fefSecondRow = new FrameworkElementFactory(typeof(UniformGrid));
            fefSecondRow.SetValue(UniformGrid.RowsProperty, 1);
            fefSecondRow.SetValue(UniformGrid.ColumnsProperty, 2);

            FrameworkElementFactory fefLabelName = new FrameworkElementFactory(typeof(Label));
            Binding bindLabelName = new Binding();
            bindLabelName.Path = new PropertyPath("name");
            fefLabelName.SetBinding(Label.ContentProperty, bindLabelName);

            fefMain.AppendChild(fefLabelName);
            fefMain.AppendChild(fefSecondRow);

            FrameworkElementFactory fefLabelPrice = new FrameworkElementFactory(typeof(Label));
            Binding bindLabelPrice = new Binding();
            bindLabelPrice.Path = new PropertyPath("price");
             fefLabelPrice.SetValue(Label.ContentProperty, bindLabelPrice);
            fefSecondRow.AppendChild(fefLabelPrice);

            FrameworkElementFactory fefLabelWeight = new FrameworkElementFactory(typeof(Label));
            Binding bindLabelWeight = new Binding();
            bindLabelWeight.Path = new PropertyPath("weight");
            fefLabelWeight.SetBinding(Label.ContentProperty, bindLabelWeight);
            fefSecondRow.AppendChild(fefLabelWeight);

            DT.VisualTree = fefMain;
            this.listView1.ItemTemplate = DT;

            this.listView1.View = null;

            ItemsPanelTemplate IPT = new ItemsPanelTemplate();
            FrameworkElementFactory fefItemsPanel = new FrameworkElementFactory(typeof(WrapPanel));

            Binding bindWidth = new System.Windows.Data.Binding("ActualWidth");
            bindWidth.Source = this.listView1;

            fefItemsPanel.SetValue(WrapPanel.WidthProperty, bindWidth);
            fefItemsPanel.SetValue(WrapPanel.OrientationProperty, Orientation.Horizontal);
            IPT.VisualTree = fefItemsPanel;
            this.listView1.ItemsPanel = IPT;
        }

        private void tableView ()
        {
            GridViewColumn col1 = new GridViewColumn();
            col1.Header = "Название";
            col1.DisplayMemberBinding = new System.Windows.Data.Binding("name");

            GridViewColumn col2 = new GridViewColumn();
            col2.Header = "Стоимость";
            col2.DisplayMemberBinding = new System.Windows.Data.Binding("price");

            GridViewColumn col3 = new GridViewColumn();
            col3.Header = "Вес";
            col3.DisplayMemberBinding = new System.Windows.Data.Binding("weight");

            GridView GV = new GridView();
            GV.Columns.Add(col1);
            GV.Columns.Add(col2);
            GV.Columns.Add(col3);

            this.listView1.View = GV;           // назначаем GridView

            ItemsPanelTemplate IPT = new ItemsPanelTemplate();
            FrameworkElementFactory FEFUG = new FrameworkElementFactory(typeof(StackPanel));
            FEFUG.SetValue(StackPanel.OrientationProperty, System.Windows.Controls.Orientation.Vertical);
            IPT.VisualTree = FEFUG;
            this.listView1.ItemsPanel = IPT;
        }
    }
       
    class Product
    {
        public String name { set; get; }
        public double price { set; get; }
        public int weight { set; get; }
        public Product(String name, double price, int weight)
        {
            this.name = name;
            this.price = price;
            this.weight = weight;
        }
    }
}
