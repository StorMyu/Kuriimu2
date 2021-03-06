﻿using System;
using System.Windows.Media.Imaging;
using Caliburn.Micro;
using Kontract.Interfaces;
using Kontract.Interfaces.Common;
using Kuriimu2.Dialogs.Common;

namespace Kuriimu2.Dialogs.ViewModels
{
    public sealed class AddTextEntryViewModel : Screen
    {
        //private readonly ITextAdapter _adapter;

        private string _selectedPluginType;
        private ILoadFiles _selectedFormatType;
        private string _selectedFilePath;

        public string Title { get; set; } = "Add Text Entry";
        //public BitmapImage Icon { get; private set; }
        public string Message { get; set; } = "";
        public string Error { get; set; } = string.Empty;
        public int TextBoxWidth { get; set; } = 200;

        public Func<ValidationResult> ValidationCallback;

        public AddTextEntryViewModel()
        {
            //_adapter = adapter;
        }

        public string Name { get; set; }

        public void OKButton()
        {
            // Set output variables

            if (ValidationCallback != null)
            {
                var results = ValidationCallback();

                if (results.CanClose)
                    TryClose(true);
                else
                {
                    Error = results.ErrorMessage;
                    NotifyOfPropertyChange(() => Error);
                }
            }
            else
            {
                TryClose(true);
            }
        }
    }
}
