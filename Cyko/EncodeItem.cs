using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyko
{
    class EncodeItem : INotifyPropertyChanged
    {
        #region declaration
        private QueueHelper setting;
        private static Form1 form1;
        private EncodeHelper encodeHelper;

        private string _inputfile, _outputpath;
        private string inputstring, outputstring;
        private string _argument;

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region property
        public string argument
        {
            get { return _argument; }
        }

        public string inputfile
        {
            get { return _inputfile; }
            set { _inputfile = value; }
        }

        public string ouputfile
        {
            get { return _outputpath; }
            set { _outputpath = value; }
        }
        #endregion

        #region constructor
        public EncodeItem()
        {
            setting = new QueueHelper();
            encodeHelper = new EncodeHelper();
            form1 = GlobalVar.form1;
        }

        public EncodeItem(string a)
            : this()
        {
            _inputfile = a;
        }

        public EncodeItem(string a, string b)
            : this(a)
        {
            _outputpath = b;
            pathProcess();
        }

        public EncodeItem(string a, string b, QueueHelper c)
            : this(a, b)
        {
            setting = c;
        }
        #endregion

        #region event Handler
        protected virtual void onPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region methods
        public void setSetting(QueueHelper a)
        {
            setting = a;
        }

        public void pathProcess()
        {
            string filename = Path.GetFileNameWithoutExtension(_inputfile);

            inputstring = " -i \"" + _inputfile + "\"";
            outputstring = " -o \"" + _outputpath + "\\" + filename + setting.getContainer() + "\" -m ";

            _argument = inputstring + outputstring + setting.processArg();
            _argument = _argument.Replace(@"\\", @"\");
        }

        public override String ToString()
        {
            pathProcess();

            return _argument;
        }

        public void encode()
        {
            encodeHelper.runHandbrake(_argument, form1);
            //return callencode(a);
        }

        public void abort()
        {
            encodeHelper.abort();
        }
        /*
         public delegate bool DelegateEncode(string aaa, Form1 form1);

         private void callencode(EncodeHelper a)
         {
             DelegateEncode simple = new DelegateEncode(a.runHandbrake);
             simple.BeginInvoke(argument, form1, new AsyncCallback(CallBack), null);
         }

         private void CallBack(IAsyncResult ar)
         {
             AsyncResult result = (AsyncResult)ar;
             DelegateEncode del = (DelegateEncode) result.AsyncDelegate;
             bool returnvalue = del.EndInvoke(ar);
         }
         */

        #endregion
    }
}
