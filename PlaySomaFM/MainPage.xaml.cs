using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.BackgroundAudio;

namespace PlaySomaFM
{
    public partial class MainPage : PhoneApplicationPage
    {
        BackgroundAudioPlayer player;
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            this.stationList.ItemsSource = SomaStation.All;

            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.ads.ApplicationId = "test_client";
                this.ads.AdUnitId = "Image480_80";
            }
            else
            {
                this.ads.ApplicationId = "c9927395-2e97-4f88-a772-bebdf362e155";
                this.ads.AdUnitId = "10022741";
            }
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            
            player = BackgroundAudioPlayer.Instance;

            player.PlayStateChanged -= player_PlayStateChanged;
            player.PlayStateChanged += player_PlayStateChanged;

            updateState();

            if (this.stationList.SelectedItem != null)
            {
                this.stationList.Loaded -= stationList_Loaded;
                this.stationList.Loaded += stationList_Loaded;
            }
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }

        private void stationList_Loaded(object sender, RoutedEventArgs e)
        {
            this.stationList.ScrollIntoView(this.stationList.SelectedItem);
        }

        private void player_PlayStateChanged(object sender, EventArgs e)
        {
            updateState();
        }

        private void stopBtn_Click(object sender, RoutedEventArgs e)
        {
            player.Stop();
        }

        private void stationList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var station = (SomaStation)e.AddedItems[0];
                if (getCurStationName() != station.Name)
                {
                    player.Stop();
                    player.Track = createTrack(station);
                    player.Play();
                }
            }
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AboutPage.xaml", UriKind.Relative));
        }

        private void updateState()
        {
            if (player.PlayerState == PlayState.Playing)
            {
                var stationName = getCurStationName();
                this.stopBtn.Content = "Stop \"" + stationName + "\"";
                this.stationList.SelectedItem =
                    this.stationList.Items.FirstOrDefault(o => ((SomaStation)o).Name == stationName);
            }
            else if (player.PlayerState == PlayState.BufferingStarted)
                this.stopBtn.Content = "Buffering...";
            else
                this.stopBtn.Content = "Nothing is playing";
        }

        private AudioTrack createTrack(SomaStation station)
        {
            AudioTrack track = new AudioTrack(
                new Uri("http://ice.somafm.com/"+station.URL+"?ext=.mp3"),
                station.Name, "Soma.fm", null, station.ImageUri, 
                station.Name, EnabledPlayerControls.Pause);

            return track;
        }

        private string getCurStationName()
        {
            if (player.Track != null)
                return player.Track.Tag;
            else
                return string.Empty;
        }
    }
}