using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WpfTreeView4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string path;
        private void fillTree(String fullPath, DirItem parent)
        {
            try
            {
                String[] dirs = Directory.GetDirectories(fullPath);
                foreach (String dir in dirs)
                {
                    DirItem DI = new DirItem(System.IO.Path.GetFileName(dir), dir);
                    parent.Nodes.Add(DI);

                    // нужно ли добавлять обманный дочерний узел
                    try
                    {
                        String[] a = Directory.GetDirectories(dir);
                        if (a.Length > 0)
                        {
                            DI.Nodes.Add(new DirItem("?", "?"));
                        }
                    }
                    catch { }
                }
            }
            catch { }
            //string fileName = @"D:/1.png";
            //BitmapImage bm1 = new BitmapImage(new Uri(fileName));
            ////bm1.BeginInit();
            ////bm1.UriSource = new Uri(fileName, UriKind.Relative);
            ////bm1.CacheOption = BitmapCacheOption.OnLoad;
            ////bm1.EndInit();
            //this.ImageBig.Source = bm1;
            // // ListViewItem lvi = new ListViewItem();
            // Image im = new Image();
            // im.Source = new BitmapImage(new Uri(fileName));
            //// this.ImageSmall.Items.Add(im);
            // this.ImageSmall.Items.Add(im);
            // ImageList imageListSmall = new ImageList();
            // this.ImageSmall
            //Image image = new Image();
            //image.;

            //string fileName1 = @"D:/1.png";
            //BitmapImage bm2 = new BitmapImage();
            //bm2.BeginInit();
            //bm2.UriSource = new Uri(fileName1, UriKind.Relative);
            //bm2.CacheOption = BitmapCacheOption.OnLoad;
            //bm2.EndInit();
            // this.ImageSmall.Items.i
        }
        public MainWindow()
        {
            InitializeComponent();
            String[] drives = Directory.GetLogicalDrives();
            foreach (String drive in drives)
            {
                DirItem DI = new DirItem(drive, drive);
                fillTree(drive, DI);
                this.treeView1.Items.Add(DI);
            }


        }
        public String ImageNameGL(string path)
        {

            return @path;

        }
        private void treeView1_Expanded(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show( e.OriginalSource.GetType().Name+":"+((TreeViewItem)e.OriginalSource).Header.GetType().Name);
            DirItem DI = ((TreeViewItem)e.OriginalSource).Header as DirItem;
            if (DI == null) return;
            DI.Nodes.Clear(); // очищает дочерние узлы распахиваемого узла
            fillTree(DI.fullPath, DI); // заполняем реальными дочерними узлами распахиваемый узел
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //this.ListView1.Items.Add(new DirectoryInfo(path).Name);
            ImageBig.Source = null;
            try
            {
            //    TreeViewItem tmp = (TreeViewItem)e.OriginalSource;
            //    DirItem DI = (DirItem)tmp.Header;
               // MessageBox.Show("!");
                //path = DI.fullPath;
                //  MessageBox.Show(DI.fullPath);
                // this.ListView1.Items.Clear();
                this.ImageSmall.Items.Clear();
                this.ListView1.Items.Add(new ImFile(new DirectoryInfo(path).Name, path));
                String[] files = Directory.GetFiles(path);
                foreach (String file in files)
                {
                    String extension = System.IO.Path.GetExtension(file);
                    if (extension == ".png" || extension == ".bmp" || extension == ".jpg" || extension == ".svg")
                    {
                        // MessageBox.Show(DI.fullPath);
                        // this.ImageSmall.Items.Add(new DirItem(System.IO.Path.GetFileName(file), file));
                        //// ImageNameGL(System.IO.Path.GetFileName(new ));
                        BitmapImage bm1 = new BitmapImage();
                        bm1.BeginInit();
                        bm1.UriSource = new Uri(file, UriKind.Relative);
                        bm1.CacheOption = BitmapCacheOption.OnLoad;
                        bm1.DecodePixelHeight = 100;
                        bm1.EndInit();
                        
                        this.ImageSmall.Items.Add(new ImgBlock(bm1));

                    }

                }
            }
            catch { }
        }

        private void treeView1_Selected(object sender, RoutedEventArgs e)
        {

            //ImageBig.Source = null;
            //try
            //{
            TreeViewItem tmp = (TreeViewItem)e.OriginalSource;
            DirItem DI = (DirItem)tmp.Header;
            path = DI.fullPath;
            //  MessageBox.Show(DI.fullPath);
            //   this.ListView1.Items.Clear();
            //    this.ListView1.Items.Add(new DirectoryInfo(DI.fullPath).Name);
            //    String[] files = Directory.GetFiles(DI.fullPath);
            //    foreach (String file in files)
            //    {
            //        String extension = System.IO.Path.GetExtension(file);
            //        if (extension == ".png" || extension == ".bmp" || extension == ".jpg" || extension == ".svg")
            //            this.ListView1.Items.Add(new DirItem(System.IO.Path.GetFileName(file), file));

            //    }
            //}
            //catch { }
        }

        private void treeView1_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            MessageBox.Show("123");
        }

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            BitmapImage BI = (BitmapImage)((Grid)sender).Tag;
            this.ImageBig.Source = new BitmapImage(new Uri(BI.UriSource.ToString()));
        }

        private void ListView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.ListView1.Items.RemoveAt(this.ListView1.SelectedIndex);
                this.ImageSmall.Items.Clear();
                this.ImageBig.Source = null;
            }
            catch { }
        }

        private void ListView1_Selected(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("!");
            this.ImageSmall.Items.Clear();
            TreeViewItem tmp = (TreeViewItem)e.OriginalSource;
            DirItem DI = (DirItem)tmp.Header;
            String[] files = Directory.GetFiles(DI.fullPath);
            foreach (String file in files)
            {
                String extension = System.IO.Path.GetExtension(DI.fullPath);
                if (extension == ".png" || extension == ".bmp" || extension == ".jpg" || extension == ".svg")
                {
                    // MessageBox.Show(DI.fullPath);
                    // this.ImageSmall.Items.Add(new DirItem(System.IO.Path.GetFileName(file), file));
                    //// ImageNameGL(System.IO.Path.GetFileName(new ));
                    BitmapImage bm1 = new BitmapImage();
                    bm1.BeginInit();
                    bm1.UriSource = new Uri(file, UriKind.Relative);
                    bm1.CacheOption = BitmapCacheOption.OnLoad;
                    bm1.DecodePixelHeight = 100;
                    bm1.EndInit();

                    this.ImageSmall.Items.Add(new ImgBlock(bm1));

                }

            }
        }
    }
    class ImFile
    {
        public String Name { get; set; }
        public String Path { get; set; }
        public String img
        {
            set { }
            get
            {
                if (Name == Path)
                    return @"Resources/Drive.png";
                return @"Resources/folder (2).png";
            }
                }
        public ImFile( string name, string path)
        {
            this.Name = name;
          
            this.Path = path;
        }
    }
    class DirItem
    {
        public String fileName { get; set; }
        public String fullPath { get; set; }
        private ObservableCollection<DirItem> nodes = new ObservableCollection<DirItem>(); // колекция дочерних узлов
        public ObservableCollection<DirItem> Nodes
        {
            get
            {
                return this.nodes;
            }
            set
            {
                this.nodes = value;
            }
        }
        public String ImageName
        {
            get
            {
                if (fileName == fullPath)
                    return @"Resources/Drive.png";
                return @"Resources/folder (2).png";
            }
            set { }
        }

        public DirItem(String fileName, String fullPath)
        {
            this.fileName = fileName;
            this.fullPath = fullPath;
        }

    }

    class ImgBlock
    {
        public BitmapImage imgPath { set; get; }
        public ImgBlock(BitmapImage s)
        {
            this.imgPath = s;
        }
    }
}
