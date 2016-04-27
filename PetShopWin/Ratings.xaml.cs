﻿using PetShopDAL;
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
    /// Interaction logic for Ratings.xaml
    /// </summary>
    public partial class Ratings : Page
    {
        DAL _dal;
        public Ratings()
        {
            InitializeComponent();
            _dal = new DAL();
            this.ratingsGrid.ItemsSource = _dal.GetAnimalsOrderedByCommentCount();
        }
    }
}
