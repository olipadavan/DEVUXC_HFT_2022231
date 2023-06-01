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
    public class TeamWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        
        public RestCollection<Team> Teams { get; set; }

        private Team selectedTeam;

        public Team SelectedTeam
        {
            get { return selectedTeam; }
            set
            {
                if (value != null)
                {
                    selectedTeam = new Team()
                    {
                        Id = value.Id,
                        SeasonId = value.SeasonId,
                        Name = value.Name
                    };
                    OnPropertyChanged();
                    (DeleteTeamCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        #region TeamCommands
        public ICommand CreateTeamCommand { get; set; }

        public ICommand DeleteTeamCommand { get; set; }

        public ICommand UpdateTeamCommand { get; set; }
        public ICommand SponsorCommand { get; set; }
        public ICommand SeasonCommand { get; set; }
        #endregion



        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public TeamWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Teams = new RestCollection<Team>("http://localhost:2201/", "Team", "hub");

                SponsorCommand = new RelayCommand(() =>
                {
                    new SponsorWindow().Show();
                });
                SeasonCommand = new RelayCommand(() =>
                {
                    new MainWindow().Show();
                });


                
                #region TeamCommands
                CreateTeamCommand = new RelayCommand(() =>
                {
                    Teams.Add(new Team()
                    {
                        Id = SelectedTeam.Id
                    });
                });

                UpdateTeamCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Teams.Update(SelectedTeam);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteTeamCommand = new RelayCommand(() =>
                {
                    Teams.Delete(SelectedTeam.Id);
                },
                () =>
                {
                    return SelectedTeam != null;
                });
                SelectedTeam = new Team();
                #endregion

            }

        }
    }

}
