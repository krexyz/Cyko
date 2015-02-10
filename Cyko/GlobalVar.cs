using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyko
{
    static class GlobalVar
    {
        public delegate void DelegateGlobal();
        public static Form1 form1;
        public static DelegateGlobal dela;

        public static void setDelegate(DelegateGlobal a){
            dela = a;
        }

        public static Form1 createForm()
        {
            form1 = new Form1();
            return form1;
        }
    }
}
