using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wedia.Foundation.Dictionary
{
    public struct Templates
    {
        public struct DictionaryFolder
        {
            public static ID ID = new ID("{FE52759A-2CE3-4A73-9CFF-CE38A089CE8D}");
        }

        public struct DictionaryEntry
        {
            public static ID ID = new ID("{1FEDD608-B4A0-4DB4-80F0-4E9A50140E17}");

            public struct Fields
            {
                public static ID Phrase = new ID("{38302AFF-D022-418E-A9BB-188E32878193}");
            }
        }
    }
}