using DEVUXC_GUI_2022232.WPFClient;
using Microsoft.Toolkit.Mvvm;
using DEVUXC_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Newtonsoft.Json.Linq;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace DEVUXC_HFT_2022232.WPFClient
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
        public RestCollection<Sponsor> Sponsors { get; set; }
        public RestCollection<Team> Teams { get; set; }

        private Season selectedSeason;
        private Sponsor selectedSponsor;
        private Team selectedTeam;

        public Season SelectedSeason
        {
            get { return SelectedSeason; }
            set
            {
                if (value != null)
                {
                    SelectedSeason = new Season()
                    {
                        SeasonYear = value.SeasonYear,
                        Id = value.Id,
                        Teams = value.Teams
                    };
                    OnPropertyChanged();
                    (DeleteSeasonCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }public Sponsor SelectedSponsor
        {
            get { return selectedSponsor; }
            set
            {
                if (value != null)
                {
                    SelectedSponsor = new Sponsor()
                    {
                        Id = value.Id,
                        Name = value.Name,
                        TeamId = value.TeamId,
                        Money = value.Money,
                        Team = value.Team

                    };
                    OnPropertyChanged();
                    (DeleteSeasonCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }public Team SelectedTeam
        {
            get { return SelectedTeam; }
            set
            {
                if (value != null)
                {
                    SelectedTeam = new Team()
                    {
                        Id = value.Id,
                        Drivers = value.Drivers,
                        Season = value.Season,
                        SeasonId = value.SeasonId,
                        Sponsors = value.Sponsors,
                        Name = value.Name
                    };
                    OnPropertyChanged();
                    (DeleteSeasonCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateSeasonCommand { get; set; }
        public ICommand CreateSponsorCommand { get; set; }
        public ICommand CreateTeamCommand { get; set; }

        public ICommand DeleteSeasonCommand { get; set; }
        public ICommand DeleteSponsorCommand { get; set; }
        public ICommand DeleteTeamCommand { get; set; }

        public ICommand UpdateSeasonCommand { get; set; }
        public ICommand UpdateSponsorCommand { get; set; }
        public ICommand UpdateTeamCommand { get; set; }

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
                Seasons = new RestCollection<Season>("http://localhost:53910/", "Season", "hub");
                Sponsors = new RestCollection<Sponsor>("http://localhost:53910/", "Sponsor", "hub");
                Teams = new RestCollection<Team>("http://localhost:53910/", "Team", "hub");

                #region Season
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
                    Seasons.Delete(SelectedSeason.SeasonYear);
                },
                () =>
                {
                    return SelectedSeason != null;
                });
                SelectedSeason = new Season();
                #endregion

                #region Sponsor
                CreateSponsorCommand = new RelayCommand(() =>
                {
                    Sponsors.Add(new Sponsor()
                    {
                        Id = SelectedSponsor.Id,
                        Name = SelectedSponsor.Name,
                        TeamId = SelectedSponsor.TeamId,
                        Money = SelectedSponsor.Money,
                        Team = SelectedSponsor.Team
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

                #region Team
                CreateTeamCommand = new RelayCommand(() =>
                {
                    Teams.Add(new Team()
                    {
                        Id = SelectedTeam.Id,
                        Drivers = SelectedTeam.Drivers,
                        Season = SelectedTeam.Season,
                        SeasonId = SelectedTeam.SeasonId,
                        Sponsors = SelectedTeam.Sponsors,
                        Name = SelectedTeam.Name
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
                    return selectedTeam != null;
                });
                SelectedTeam = new Team();
                #endregion
            }
        }
    }
}
