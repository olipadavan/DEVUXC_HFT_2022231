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
using System.Windows.Controls;
using System.Windows.Input;

namespace DEVUXC_HFT_2022231.WPF.Client
{
    public class MainWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        
        public RestCollection<Season> Seasons { get; set; }
        
        private Season selectedSeason;

        public Season SelectedSeason
        {
            get { return selectedSeason; }
            set
            {
                if (value != null)
                {
                    selectedSeason = new Season()
                    {
                        Id = value.Id,
                        SeasonYear = value.SeasonYear,
                        Teams = value.Teams
                    };
                    OnPropertyChanged();
                    (DeleteSeasonCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateSeasonCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        

        #region SeasonCommands
        public ICommand CreateSeasonCommand { get; set; }

        public ICommand DeleteSeasonCommand { get; set; }

        public ICommand UpdateSeasonCommand { get; set; }
        #endregion

       
        public ICommand SponsorCommand { get; set; }
        public ICommand TeamCommand { get; set; }



        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                
                Seasons = new RestCollection<Season>("http://localhost:2201/", "Season/ReadAll", "hub");
                
                SponsorCommand = new RelayCommand(() =>
                {
                    new SponsorWindow().Show();
                });
                TeamCommand = new RelayCommand(() =>
                {
                    new TeamWindow().Show();
                });


                #region SeasonCommands
                CreateSeasonCommand = new RelayCommand(() =>
                {
                    Seasons.Add(new Season()
                    {
                        SeasonYear = SelectedSeason.SeasonYear
                    });
                });

                UpdateSeasonCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Seasons.Update(SelectedSeason);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteSeasonCommand = new RelayCommand(() =>
                {
                    Seasons.Delete(SelectedSeason.Id);
                },
                () =>
                {
                    return SelectedSeason != null;
                });
                SelectedSeason = new Season();
                #endregion


               
            }

        }
    }

}
