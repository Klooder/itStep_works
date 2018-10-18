using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace Fifteen
{

    public partial class MainWindow
    {
        private Tuple<int, int> m_emptyCell;
        public MainWindow()
        {
            InitializeComponent();
            Cells = new ObservableCollection<Cell>();
            for (var i = 1; i < 16; i++)
            {
                var cell = new Cell { Text = string.Format("{0}", i) };
                cell.MouseLeftButtonDown += (o, e) => CellClick((Cell)o);
                Cells.Add(cell);
            }
            Initialize();
        }

        private void Initialize()
        {
            var tuples = new List<Tuple<int, int>>();
            for (var col = 0; col < 4; col++)
                for (var row = 0; row < 4; row++)
                    tuples.Add(new Tuple<int, int>(col, row));
            var index = 0;
            var random = new Random(DateTime.Now.Millisecond);
            do
            {
                var tuple = tuples[random.Next(tuples.Count)];
                var cell = Cells[index];
                cell.Column = tuple.Item1;
                cell.Row = tuple.Item2;
                tuples.Remove(tuple);
                index++;
            } while (tuples.Count > 1);
            m_emptyCell = tuples[0];
        }
        private void CellClick(Cell cell)
        {
            if (m_emptyCell.Item1 == cell.Column - 1 && m_emptyCell.Item2 == cell.Row)
            {
                m_emptyCell = new Tuple<int, int>(cell.Column, m_emptyCell.Item2);
                cell.Column -= 1;
            }
            else if (m_emptyCell.Item1 == cell.Column + 1 && m_emptyCell.Item2 == cell.Row)
            {
                m_emptyCell = new Tuple<int, int>(cell.Column, m_emptyCell.Item2);
                cell.Column += 1;
            }
            else if (m_emptyCell.Item1 == cell.Column && m_emptyCell.Item2 == cell.Row - 1)
            {
                m_emptyCell = new Tuple<int, int>(m_emptyCell.Item1, cell.Row);
                cell.Row -= 1;
            }
            else if (m_emptyCell.Item1 == cell.Column && m_emptyCell.Item2 == cell.Row + 1)
            {
                m_emptyCell = new Tuple<int, int>(m_emptyCell.Item1, cell.Row);
                cell.Row += 1;
            }

            CheckResult();
        }

        private void CheckResult()
        {
            //TODO: Must be implemented
        }

        #region Cells...
        private static readonly DependencyPropertyKey CellsPropertyKey = DependencyProperty.RegisterReadOnly("Cells", typeof(ObservableCollection<Cell>), typeof(MainWindow), new UIPropertyMetadata(default(ObservableCollection<Cell>)));
        public static readonly DependencyProperty CellsProperty = CellsPropertyKey.DependencyProperty;
        public ObservableCollection<Cell> Cells
        {
            get { return (ObservableCollection<Cell>)GetValue(CellsProperty); }
            private set { SetValue(CellsPropertyKey, value); }
        }
        #endregion
    }
}
