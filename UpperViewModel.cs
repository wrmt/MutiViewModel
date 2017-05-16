using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.MVVM;
using System.Windows.Input;

namespace MutiViewModel
{
    class UpperViewModel : ViewModelBase
    {
        private string vmTxt;
        public string VmTxt
        {
            get { return vmTxt; }
            set
            {
                vmTxt = value;
                RaisePropertyChanged("VmTxt");
            }
        }

        public ICommand CmdClick { get; set; }
        
        public UpperViewModel()
        {
            this.VmTxt = "NotifyAll";
            this.CmdClick = new RelayCommand(_ => {
                this.VmTxt = "UpperButtonClicked";
                RaisePropertyChanged("ToAll");
            });
        }

    }
}
