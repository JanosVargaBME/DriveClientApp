using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DriveClient.ViewModels
{
    internal class AddItemViewModel : BaseViewModel
    {
        public string Path { get; set; } = string.Empty;

        public AddItemViewModel(INavigation navigation) : base(navigation)
        {
            
            
        }
    }
}
