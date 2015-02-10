using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyko
{
    class QueueHelper
    {
        string container = string.Empty;

        public QueueHelper()
        {

        }

        public string processx264()
        {
            string x264q;
            string temp1;

            temp1 = "-e x264 ";

            temp1 += Cyko.X264Const.getPreset(s_Setting.preset);
            temp1 += " ";
            temp1 += Cyko.X264Const.getTune(s_Setting.tune);
            temp1 += " ";
            temp1 += Cyko.X264Const.getProfile(s_Setting.profile);

            if (s_Setting.mode == 0)
                x264q = "-q ";
            else
                x264q = "-2 -T -b ";

            x264q += s_Setting.vquality.ToString();

            temp1 += x264q;
            return temp1;
        }

        public string processArg()
        {

            string resolution;
            string subs;
            string x264;

            x264 = processx264();

            if (s_Setting.getResMode() == 0)
                resolution = " -l ";
            else
                resolution = " -w ";

            resolution += s_Setting.getResolution();

            if (s_Setting.getDenoise() == true)
                x264 += "-x nr=1000 ";

            x264 += resolution;

            if (s_Setting.getHardSub() == true)
            {
                container = "-out.mp4";
                subs = " -s 1 --subtitle-burn ";
            }
            else
            {
                container = "-out.mkv";
                subs = " -s 1,2,3,4,5,6,7,8,9 --subtitle-default ";
            }

            x264 += " -E fdk_aac --mixdown stereo -B " + s_Setting.getAudioBitrate();
            x264 += subs;

            return x264;
        }

        public string getContainer()
        {
            if (s_Setting.getHardSub() == true)
            {
                container = "-out.mp4";
            }
            else
            {
                container = "-out.mkv";
            }
            return container;
        }
    }
}
