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
    /// Interaction logic for CreateCategory.xaml
    /// </summary>
    public partial class Categories : Page
    {
        DAL _dal;

        public Categories()
        {
            InitializeComponent();
            _dal = new DAL();
            this.categoriesGrid.DataContext = _dal.GetCategoryEntities();
        }

        private void categoriesGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        private void addCategory_Click(object sender, RoutedEventArgs e)
        {
            var categoryName = categoryNameTextBox.Text;
            _dal.InsertCategory(categoryName);
            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            this.categoriesGrid.DataContext = null;
            this.categoriesGrid.DataContext = _dal.AnimalsList();
        }
    }
}
