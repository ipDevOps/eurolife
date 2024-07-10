using Sitecore.Data;

namespace Wedia.Foundation.Assets
{
    public struct Templates
    {
        public struct RenderingAssets
        {
            public static readonly ID ID = new ID("{590778FD-DD53-4664-86F7-ED3894260892}");

            public struct Fields
            {
                public static readonly ID ScriptFiles = new ID("{D7E7D647-0D97-4DF7-A1AE-01253761A71B}");
                public static readonly ID StylingFiles = new ID("{BAE63BA4-2087-4625-B625-EEA9BCD46075}");
                public static readonly ID InlineScript = new ID("{3C4EFD07-B7A6-459D-977A-10EFC2754BA5}");
                public static readonly ID InlineStyling = new ID("{D8979EC1-D460-488F-8D44-CA5F2F489E47}");
            }
        }

        public struct PageAssets
        {
            public static readonly ID ID = new ID("{5014D264-A8D3-44F3-B092-B9FB6E5B9DDC}");

            public struct Fields
            {
                public static readonly ID JavascriptCodeTop = new ID("{35A852ED-2304-4C92-9030-05191E888225}");
                public static readonly ID JavascriptCodeBottom = new ID("{B015A3A0-585E-4EE6-B8F3-0F4B1CDBD4F4}");
                public static readonly ID CssCode = new ID("{937EE756-C171-4A3F-8E74-05170FD315E7}");
                public static readonly ID InheritAssets = new ID("{681982E8-5879-46F1-80CF-27F5201BE782}");
            }
        }

        public struct HasTheme
        {
        public static readonly ID ID = new ID("{8C150565-3782-4332-9878-176440496AEA}");

            public struct Fields
            {
                public static readonly ID Theme = new ID("{EB2AF3CA-2892-4044-B791-394344AB8456}");
            }
        }        
    }
}