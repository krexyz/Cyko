using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyko
{
    static class X264Const
    {
        static string[] preset = new string[10];
        static string[] tune = new string[8];
        static string[] profile = new string[3];

        public static string getPreset(int n)
        {
            return preset[n];
        }
        public static string getTune(int n)
        {
            return tune[n];
        }
        public static string getProfile(int n)
        {
            return profile[n];
        }
                                      
        static X264Const()                
        {
            preset[0] = "--x264-preset ultrafast";
            preset[1] = "--x264-preset superfast";
            preset[2] = "--x264-preset veryfast";
            preset[3] = "--x264-preset faster";
            preset[4] = "--x264-preset fast";
            preset[5] = "--x264-preset medium";
            preset[6] = "--x264-preset slow";
            preset[7] = "--x264-preset slower";
            preset[8] = "--x264-preset veryslow";
            preset[9] = "--x264-preset placebo";

            tune[0] = "--x264-tune film";
            tune[1] = "--x264-tune animation";
            tune[2] = "--x264-tune grain";
            tune[3] = "--x264-tune stillimage";
            tune[4] = "--x264-tune psnr";
            tune[5] = "--x264-tune ssim";
            tune[6] = "--x264-tune fastdecode";
            tune[7] = "--x264-tune zerolatency";

            profile[0] = "--x264-profile baseline ";
            profile[1] = "--x264-profile main ";
            profile[2] = "--x264-profile high ";
        }
    }
}
