// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Contacts;
using Windows.Foundation;
using Windows.Foundation.Collections;
using WinRT;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace GoProListViewExample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
       // private ObservableCollection<Contact> _contact = Contact.GetContacts(10);
        private ObservableCollection<Contact> _contact = new ObservableCollection<Contact>();

        int _currItemIndex = 0;
        int _prevItemIndex = 0;


        public MainPage()
        {
            this.InitializeComponent();
          
        }

        void InitializeValues()
        {

            for(int i = 0; i < 10; i++)
            {
                Contact ce = new Contact();
                this._contact.Add(ce);

            }
           
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if(AudioFileListView.SelectedIndex != -1) _contact.RemoveAt(AudioFileListView.SelectedIndex);
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AudioFileListView.SelectedIndex != -1)
            {
                _currItemIndex = AudioFileListView.SelectedIndex;
                this._contact[_currItemIndex].AudioSelected = true;

                if(_prevItemIndex != _currItemIndex && _prevItemIndex >= 0 && _prevItemIndex < _contact.Count)
                    this._contact[_prevItemIndex].AudioSelected = false;

                _prevItemIndex = _currItemIndex;
            }
        }

        private void AudioFileListView_Loaded(object sender, RoutedEventArgs e)
        {
             InitializeValues();
        }
    }
}
