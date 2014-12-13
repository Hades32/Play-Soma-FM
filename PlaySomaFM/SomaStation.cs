using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.Linq;

namespace PlaySomaFM
{
    public class SomaStation
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }

        public Uri ImageUri
        {
            get
            {
                var uri = new Uri("/img/" + this.Image, UriKind.Relative);
                return uri;
            }
        }

        public static readonly IEnumerable<SomaStation> All = new List<SomaStation>()
            {
                new SomaStation(){ Image="u80s-120.png",URL="u80s",Name="Underground 80s",Description="Early 80s UK Synthpop and a bit of New Wave." },
                new SomaStation(){ Image="groovesalad120.png",URL="groovesalad",Name="Groove Salad",Description="A nicely chilled plate of ambient beats and grooves." },
                new SomaStation(){ Image="sog120.jpg",URL="suburbsofgoa",Name="Suburbs of Goa",Description="Desi-influenced Asian world beats and beyond." },
                new SomaStation(){ Image="lush120.jpg",URL="lush",Name="Lush",Description="Sensuous and mellow vocals, mostly female, with an electronic influence." },
                new SomaStation(){ Image="sss.jpg",URL="spacestation",Name="Space Station Soma",Description="Tune in, turn on, space out. Spaced-out ambient and mid-tempo electronica" },
                new SomaStation(){ Image="dronezone120.jpg",URL="dronezone",Name="Drone Zone",Description="Served best chilled, safe with most medications. Atmospheric textures with minimal beats." },
                new SomaStation(){ Image="missioncontrol120.jpg",URL="missioncontrol",Name="Mission Control",Description="Live and historic NASA mission audio mixed with electronic ambient." },
                new SomaStation(){ Image="cliqhop.png",URL="cliqhop",Name="cliqhop idm",Description="Blips'n'beeps backed mostly w/beats. Intelligent Dance Music." },
                new SomaStation(){ Image="indychick.jpg",URL="indiepop",Name="indie pop rocks",Description="New and favorite classic indie pop tracks." },
                new SomaStation(){ Image="digitalis120.png",URL="digitalis",Name="Digitalis",Description="Digitally affected analog rock to calm the agitated heart. Screengazing encouraged." },
                new SomaStation(){ Image="poptron120.png",URL="poptron",Name="PopTron!",Description="Electropop and indie dance rock with sparkle and pop." },
                new SomaStation(){ Image="covers120.jpg",URL="covers",Name="Covers",Description="Just Covers, songs you know only not by the original artists. We've got you covered." },
                new SomaStation(){ Image="secretagent120.jpg",URL="secretagent",Name="Secret Agent",Description="The soundtrack for your stylish, mysterious, dangerous life. For Spies and PIs too!" },
                new SomaStation(){ Image="bootliquor.png",URL="bootliquor",Name="Boot Liquor",Description="Americana roots music with a bit of attitude. For Cowhands, Cowpokes and Cowtippers." },
                new SomaStation(){ Image="sonicuniverse120.jpg",URL="sonicuniverse",Name="Sonic Universe",Description="A mix of avant garde jazz, euro jazz and nu jazz. Eclectic takes on traditional jazz." },
                new SomaStation(){ Image="illstreet.jpg",URL="illstreet",Name="Illinois Street Lounge",Description="Classic bachelor pad, playful exotica and vintage music of tomorrow." },
                new SomaStation(){ Image="tagstrancefract.jpg",URL="tags",Name="Tag's Trip",Description="Progressive house / trance. Tip top tunes." },
                new SomaStation(){ Image="blender.png",URL="beatblender",Name="Beat Blender",Description="A late night blend of deep-house and downtempo chill." },
                new SomaStation(){ Image="doomed.png",URL="doomed",Name="Doomed",Description="Dark music for tortured souls. A haunted industrial/ambient soundtrack." },
                new SomaStation(){ Image="1023brc.jpg",URL="brfm",Name="Black Rock FM",Description="From the Playa to the world, for the 2010 Burning Man festival."},
                // new as of 2012-07-28
                new SomaStation(){ Image="dubstep120.png",URL="dubstep",Name="Dub Step Beyond",Description="Dubstep, Dub and Deep Bass. May damage speakers at high volume."},
                new SomaStation(){ Image="480min120.png",URL="480min",Name="480 Minutes",Description="Live Every Friday: What alternative rock radio would sound like if they played more than Nirvana sound-alikes."},
                /*
                 * //don't work yet as no proxy server link is available
                new SomaStation(){ Image="sxfm120.png",URL="sxfm",Name="South by Soma",Description="Music from bands who performed at SXSW, one of the biggest and best music festivals in the world. [explicit]"},
                new SomaStation(){ Image="sf1033120.png",URL="sf1033",Name="SF 10-33",Description="Ambient music mixed with the sounds of San Francisco public safety radio traffic."},
                */
            }.OrderBy(ss => ss.Name);
    }
}
