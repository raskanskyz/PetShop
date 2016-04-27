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
using PetShopDAL;
using System.Data;

namespace PetShopWin
{
    /// <summary>
    /// Interaction logic for Animals.xaml
    /// </summary>
    public partial class Animals : Page
    {
        DAL _dal;

        public Animals()
        {
            InitializeComponent();
            _dal = new DAL();
            this.animalGrid.DataContext = _dal.AnimalsList();
            this.animalCatListBox.ItemsSource = _dal.GetCategories();
        }

        private void animalGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {

        }

        private void animalGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            Animal entity = dg.SelectedItems[0] as Animal;
            if (!_dal.IsAnimalNew(entity.AnimalId))
            {
                _dal.UpdateAnimal(entity.AnimalId, entity.Name, entity.Age, entity.PictureName, entity.Description);
            }
        }

        private void saveChangesButton_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(animalCatListBox.SelectedValue.ToString());
            _dal.InsertAnimal(animalNameTextBox.Text, Convert.ToInt32(animalAgeTextBox.Text), animalPictureTextBox.Text, animalDescTextBox.Text, animalCatListBox.SelectedValue.ToString());
            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            this.animalGrid.DataContext = null;
            this.animalGrid.DataContext = _dal.AnimalsList();
        }
    }
}
