using Microsoft.TeamFoundation.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MutiViewModel
{
    class LowerViewModel : ViewModelBase
    {
        #region Text
        private string vmTxt;
        public string VmTxt
        {
            get { return vmTxt; }
            set { vmTxt = value; RaisePropertyChanged("VmTxt"); }
        }
        #endregion

        #region Button
        public ICommand CmdClick { get; set; }
        #endregion

        public LowerViewModel()
        {
            this.VmTxt = "NotifyChildToChild";
            this.CmdClick = new RelayCommand(_ => {
                this.VmTxt = "LowerButtonClicked";
                RaisePropertyChanged("ToUpper");
            });
        }
    }
}
