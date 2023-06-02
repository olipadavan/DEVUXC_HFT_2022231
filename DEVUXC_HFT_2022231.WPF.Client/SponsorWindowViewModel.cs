using DEVUXC_HFT_2022231.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MovieDbApp.WpfClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DEVUXC_HFT_2022231.WPF.Client
{
    public class SponsorWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        
        public RestCollection<Sponsor> Sponsors { get; set; }

        
        private Sponsor selectedSponsor;

        public Sponsor SelectedSponsor
        {
            get { return selectedSponsor; }
            set
            {
                if (value != null)
                {
                    selectedSponsor = new Sponsor()
                    {
                        Id = value.Id,
                        Money = value.Money,
                        Name = value.Name,
                        TeamId = value.TeamId,
                    };
                    OnPropertyChanged();
                    (DeleteSponsorCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateSponsorCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
       
        #region SponsorCommands
        public ICommand CreateSponsorCommand { get; set; }

        public ICommand DeleteSponsorCommand { get; set; }

        public ICommand UpdateSponsorCommand { get; set; }
        public ICommand SeasonCommand { get; set; }
        public ICommand TeamCommand { get; set; }
        #endregion

       
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public SponsorWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Sponsors = new RestCollection<Sponsor>("http://localhost:2201/", "Sponsor", "hub");

                SeasonCommand = new RelayCommand(() =>
                {
                    new MainWindow().Show();
                });
                TeamCommand = new RelayCommand(() =>
                {
                    new TeamWindow().Show();
                });


               
                #region SponsorCommands
                CreateSponsorCommand = new RelayCommand(() =>
                {
                    Sponsors.Add(new Sponsor()
                    {
                        Id = SelectedSponsor.Id
                    });
                });

                UpdateSponsorCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Sponsors.Update(SelectedSponsor);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteSponsorCommand = new RelayCommand(() =>
                {
                    Sponsors.Delete(SelectedSponsor.Id);
                },
                () =>
                {
                    return SelectedSponsor != null;
                });
                SelectedSponsor = new Sponsor();
                #endregion


                

            }

        }
    }


    public class CollectionChoosingHelper
    {
        public string CollectionName { get; set; }
    }
}
