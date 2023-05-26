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

        private List<CollectionChoosingHelper> ChooseCollections { get; set; }
        public CollectionChoosingHelper SelectedCollection { get; set; }
        public RestCollection<Season> Seasons { get; set; }
        public RestCollection<Sponsor> Sponsors { get; set; }
        public RestCollection<Team> Teams { get; set; }

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
                }
            }
        }
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
                    (DeleteSeasonCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
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
                    (DeleteSeasonCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        #region SeasonCommands
        public ICommand CreateSeasonCommand { get; set; }

        public ICommand DeleteSeasonCommand { get; set; }

        public ICommand UpdateSeasonCommand { get; set; }
        #endregion

        #region SponsorCommands
        public ICommand CreateSponsorCommand { get; set; }

        public ICommand DeleteSponsorCommand { get; set; }

        public ICommand UpdateSponsorCommand { get; set; }
        #endregion

        #region TeamCommands
        public ICommand CreateTeamCommand { get; set; }

        public ICommand DeleteTeamCommand { get; set; }

        public ICommand UpdateTeamCommand { get; set; }
        #endregion



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
                ChooseCollections = new List<CollectionChoosingHelper>
                {
                    new CollectionChoosingHelper() {CollectionName = "Seasons"},
                    new CollectionChoosingHelper() {CollectionName = "Sponsors" },
                    new CollectionChoosingHelper() {CollectionName = "Teams"}
                };
                SelectedCollection = ChooseCollections.FirstOrDefault();

                Seasons = new RestCollection<Season>("http://localhost:2201/", "season", "hub");
                Sponsors = new RestCollection<Sponsor>("http://localhost:2201/", "sponsor", "hub");
                Teams = new RestCollection<Team>("http://localhost:2201/", "team", "hub");


                #region SeasonCommands
                CreateSeasonCommand = new RelayCommand(() =>
                {
                    Seasons.Add(new Season()
                    {
                        Id = SelectedSeason.Id
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


    public class CollectionChoosingHelper
    {
        public string CollectionName { get; set; }
    }

}
