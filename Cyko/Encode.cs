using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Cyko
{
    class Encode
    {
        bool running;
        int currentItem;
        BindingList<EncodeItem> _encodeList;

        public BindingList<EncodeItem> encodeList
        {
            get { return _encodeList; }
        }

        public Encode()
        {
            GlobalVar.DelegateGlobal a = new GlobalVar.DelegateGlobal(next);
            GlobalVar.setDelegate(a);
            _encodeList = new BindingList<EncodeItem>();
        }

        public void add(EncodeItem a)
        {
            _encodeList.Add(a);
        }

        public void start()
        {
            currentItem = 0;
            encodeList[currentItem].encode();
            running = true;
        }

        public void next()
        {
            if (currentItem + 1 < _encodeList.Count)
            {
                currentItem++;
                encodeList[currentItem].encode();
            }
        }

        public void stop()
        {
            if (running)
            {
                encodeList[currentItem].abort();
                currentItem = 0;
            }

            running = false;
        }

        public bool isRunning()
        {
            return running;
        }
    }
}
