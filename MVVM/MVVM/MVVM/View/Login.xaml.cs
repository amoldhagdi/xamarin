﻿using MVVM.Services;
using MVVM.ViewModels;

namespace MVVM.View
{
    public partial class Login
    { 
        public Login()
        {
            InitializeComponent();
            this.BindingContext = new LoginModel();
        } 
    }
}
