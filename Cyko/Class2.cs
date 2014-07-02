using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Cyko
{
     class EncodeItem
     {
          private Settings setting;

          private string inputfile, outputpath;
          private string [] presets, tunes, profiles;
          private string inputstring, outputstring, audiostring, x264;
          private string subs;

          //private bool denoise;
          //private bool resmode;


          public EncodeItem () {
               presets = new String[10];
               tunes  = new String[8];
               profiles = new String[3];

               initArray();
          }

          public EncodeItem(string a) 
               : this()
          {
               inputfile = a;
               
          }

          public EncodeItem(string a, string b)
               : this(a)
          {
               outputpath = b;
          }

          public EncodeItem(string a, string b, Settings c)
               : this(a, b)
          {
               setting = c;
          }

          public void setSetting(Settings a){
               setting = a;
          }

          public void initArray(){
               //dunno why choose array xD
               presets[0]= "--x264-preset ultrafast";
               presets[1]= "--x264-preset superfast";
               presets[2]= "--x264-preset veryfast";
               presets[3]= "--x264-preset faster";
               presets[4]= "--x264-preset fast";
               presets[5]= "--x264-preset medium";
               presets[6]= "--x264-preset slow";
               presets[7]= "--x264-preset slower";
               presets[8]= "--x264-preset veryslow";
               presets[9]= "--x264-preset placebo";

               tunes[0]= " --x264-tune film";                    
               tunes[1]= " --x264-tune animation";                    
               tunes[2]= " --x264-tune grain";                    
               tunes[3]= " --x264-tune stillimage";                    
               tunes[4]= " --x264-tune psnr";                    
               tunes[5]= " --x264-tune ssim";                    
               tunes[6]= " --x264-tune fastdecode";                    
               tunes[7]= " --x264-tune zerolatency";
               
               profiles[0]= " --x264-profile baseline ";
               profiles[1]= " --x264-profile main ";
               profiles[2]= " --x264-profile high ";
          }

          public void processArg()
          {
               string containerstring;
               string resolution;
               processx264();

               audiostring = "-E fdk_aac --mixdown stereo -B " +  setting.getAudioBitrate();

               

               if (setting.getResMode() == 0)
                    resolution = " -l ";
               else
                    resolution = " -w ";

               resolution += setting.getResolution();

               if (setting.getDenoise() == true)
                    x264+= "-x nr=1000 ";

               x264 += resolution;

               if (setting.getHardSub() == true)
               {
                    containerstring = "-out.mp4";
                    subs = " -s 1 --subtitle-burn ";
               }
               else
               {
                    containerstring = "-out.mkv";
                    subs = " -s 1,2,3,4,5,6,7,8,9 --subtitle-default ";
               }
               x264 += subs;

               string filename = Path.GetFileNameWithoutExtension(inputfile);
               inputstring = " -i \"" + inputfile + "\"";
               outputstring = " -o \"" + outputpath + "\\" + filename + containerstring + "\" -m ";

          }

          public void processx264()
          {
               int[] temp10 = new int[5];

               string x264q;
               string temp1;

               temp10 = setting.getx264Setting();

               temp1 = "-e x264 ";

               temp1 += presets[temp10[1]];
               temp1 += tunes[temp10[2]];
               temp1 += profiles[temp10[3]];


               if (temp10[0] == 0)
                    x264q = "-q ";
               else
                    x264q = "-2 -T -b ";

               x264q += temp10[4].ToString();

               x264 = temp1;
               x264 += x264q;
          }
          
          public String ToString(){
               string temp = inputstring + outputstring + x264 + audiostring;
               temp = temp.Replace (@"\\", @"\");
               return temp;
          }

          public void checkTest(Delegate A)
          {

          }
     }

     class Settings
     {
          int mode, preset, tunes, profile;
          int x264q;
          bool denoise, hardsub;
          int resolution, resMode;
          int audioBitrate;


          public Settings()
          {
               
          }

          public void setX264Setting(int e, int a, int b, int c, int d)
          {
               mode = a;
               preset = b;
               tunes = c;
               profile = d;
               x264q = e;
          }

          public void setMode(int a, int b){
               mode = a;
               x264q = b;
          }

          public void setPreset(int a){
               preset = a;
          }

          public void setTunes(int a){
               tunes =a;
          }

          public void setProfile(int a){
               profile = a;
          }

          public void setQuality(int a){
               x264q = a;
          }

          public void setPicSetting(int res, int mode, bool a, bool b)
          {
               resolution = res;
               resMode = mode;
               denoise = a;
               hardsub = b;
          }

          

          public void setAudio(int a)
          {
               audioBitrate = a;
          }

          public int[] getx264Setting(){
               int[] temp = new int[5];
               temp[0] = mode;
               temp[1] = preset;
               temp[2] = tunes;
               temp[3] = profile;
               temp[4] = x264q;

               return temp;
          }


          public int getResolution()
          {
               return resolution;
          }

          public int getResMode(){
               return resMode;
          }

          public int getAudioBitrate(){
               return audioBitrate;
          }

          public bool getDenoise(){
               return denoise;
          }

          public bool getHardSub(){
               return hardsub;
          }


     }

     /*
     class Resolution
     {
          private int height = 0, width = 0;
          private int mode;

          Resolution(int a, int b = 0)
          {
               if (b == 0)
                    height = a;
               else
                    width = a;
          }

          public int getRes()
          {
               if (height != 0)
                    return height;
               return width;
          }

          public int getMode()
          {
               return mode;
          }
     }
      */

     class Encode
     {
          public Process p = new Process()
          {
               StartInfo = new ProcessStartInfo()
               {
                    FileName = "handbrakeCli.exe",
                    Arguments = "",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = false,
               },
               EnableRaisingEvents = true

          };
     }
     
}
