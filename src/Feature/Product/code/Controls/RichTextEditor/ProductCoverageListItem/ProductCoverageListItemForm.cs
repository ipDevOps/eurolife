using Sitecore;
using Sitecore.Diagnostics;
using Sitecore.Web;
using Sitecore.Web.UI.HtmlControls;
using Sitecore.Web.UI.Pages;
using Sitecore.Web.UI.Sheer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Wedia.Feature.Product.Controls.RichTextEditor.ProductCoverageListItem
{
  public class ProductCoverageListItemForm : DialogForm
  {
    protected Edit PackName;
    protected Edit PackSummary;
    protected Memo PackCoverages;

    protected string Mode
    {
      get
      {
        string str = StringUtil.GetString(ServerProperties[nameof(Mode)]);
        if (!string.IsNullOrEmpty(str))
          return str;
        return "shell";
      }
      set
      {
        Assert.ArgumentNotNull((object)value, nameof(value));
        ServerProperties[nameof(Mode)] = (object)value;
      }
    }

    protected override void OnCancel(object sender, EventArgs args)
    {
      Assert.ArgumentNotNull(sender, nameof(sender));
      Assert.ArgumentNotNull((object)args, nameof(args));
      if (Mode == "webedit")
        base.OnCancel(sender, args);
      else
        SheerResponse.Eval("scCancel()");
    }

    protected override void OnLoad(EventArgs e)
    {
      Assert.ArgumentNotNull((object)e, nameof(e));
      base.OnLoad(e);
      if (Context.ClientPage.IsEvent)
        return;
      Mode = WebUtil.GetQueryString("mo");
    }

    protected override void OnOK(object sender, EventArgs args)
    {
      Assert.ArgumentNotNull(sender, nameof(sender));
      Assert.ArgumentNotNull((object)args, nameof(args));

      if (PackName.Value.Length == 0)
      {
        SheerResponse.Alert("Pack name required");
        return;
      }

      if (PackCoverages.Value.Length == 0)
      {
        SheerResponse.Alert("Pack coverages required");
        return;
      }

      if (Mode == "webedit")
      {
        SheerResponse.SetDialogValue(StringUtil.EscapeJavascriptString(GetData()));

        base.OnOK(sender, args);
      }
      else
        SheerResponse.Eval("scClose(" + StringUtil.EscapeJavascriptString(GetData()) + ")");
      
    }

    private string GetData()
    {
      var html = string.Empty;

      html += $@"
        <div class='contentgroup'>
          <div class='contentgroup__left'>
            <div class='contentgroup__title'>
              {PackName.Value}
            </div>";

      if (PackSummary.Value.Length > 0)
      {
        html += $@"
          <div class='contentgroup__info'>
            {PackSummary.Value}
          </div>          
        ";
      }

      html += $@"</div>";
      html += $@"
        <div class='contentgroup__right contentgroup__tick'>
          <ul>";

      var reader = new StringReader(PackCoverages.Value);
      string line;
      while (null != (line = reader.ReadLine()))
      {
        html += $@"<li>{line}</li>";
      }


      html +=  $@"</ul>
      </div>      
    </div>";


      return html;
    }


  }
}