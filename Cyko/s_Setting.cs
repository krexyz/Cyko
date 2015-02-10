using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyko
{
    public static class s_Setting
    {
        public static int mode, preset, tune, profile, vquality;
        public static int resolution, resMode;
        public static int audioBitrate;
        public static bool denoise, hardsubs;

        static s_Setting()
        {
            mode = 0;
            preset = 5;
            tune = 1;
            profile = 2;
            vquality = 23;

            resolution = 720;
            resMode = 0;

            audioBitrate = 128;

            denoise = false;
            hardsubs = false;
        }

        public static void setPreset(int a)
        {
            preset = a;
        }

        public static void setTunes(int a)
        {
            tune = a;
        }

        public static void setProfile(int a)
        {
            profile = a;
        }

        public static void setPicSetting(int res, int mode, bool a, bool b)
        {
            resolution = res;
            resMode = mode;
            denoise = a;
            hardsubs = b;
        }

        public static void setAudio(int a)
        {
            audioBitrate = a;
        }

        public static int getResolution()
        {
            return resolution;
        }

        public static int getResMode()
        {
            return resMode;
        }

        public static int getAudioBitrate()
        {
            return audioBitrate;
        }

        public static bool getDenoise()
        {
            return denoise;
        }

        public static bool getHardSub()
        {
            return hardsubs;
        }
    }
}
