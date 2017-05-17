using Microsoft.TeamFoundation.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MutiViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Text
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
        #endregion

        #region Button 
        public ICommand CmdClick { get; set; }
        #endregion

        #region ViewModel   
        private UpperViewModel vmUpper;
        public UpperViewModel VmUpper
        {
            get { return vmUpper; }
            set
            {
                vmUpper = value;
                RaisePropertyChanged("VmUpper");
            }
        }

        private LowerViewModel vmLower;
        public LowerViewModel VmLower
        {
            get { return vmLower; }
            set
            {
                vmLower = value;
                RaisePropertyChanged("VmLower");
            }
        }
        #endregion

        public MainViewModel()
        {
            this.VmTxt = "NotifyChildren";
            this.VmUpper = new UpperViewModel();
            this.VmLower = new LowerViewModel();
            this.CmdClick = new RelayCommand(_ => {
                this.VmTxt = "ParentButtonClicked";
                this.VmUpper.VmTxt = "fromParent";
                this.VmLower.VmTxt = "fromParent";
            });
            this.VmUpper.PropertyChanged += (o, e) => {
                if (e.PropertyName == "ToAll")
                {
                    this.VmTxt = "fromUpper";
                    this.VmLower.VmTxt = "fromUpper";
                }
            };
            this.VmLower.PropertyChanged += (o, e) => {
                if (e.PropertyName == "ToUpper")
                {
                    this.VmUpper.VmTxt = "fromLower";
                }
            };
        }
    }
}
