using PetShopDAL;
using System;
using System.Collections.Generic;
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

namespace PetShopWin
{
    /// <summary>
    /// Interaction logic for Comments.xaml
    /// </summary>
    public partial class Comments : Page
    {
        DAL _dal;
        public Comments()
        {
            InitializeComponent();
            _dal = new DAL();
            this.commentsGrid.DataContext = _dal.GetCommentsList();
        }

        private void categoriesGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        private void RefreshDataGrid()
        {
            this.commentsGrid.DataContext = null;
            this.commentsGrid.DataContext = _dal.GetCommentsList();
        }
    }
}
