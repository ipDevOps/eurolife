Telerik.Web.UI.Editor.CommandList["ProductCoverageListItem"] = function (commandName, editor, args) {
  scEditor = editor;
  editor.showExternalDialog(
    "/sitecore/shell/default.aspx?xmlcontrol=RichText.ProductCoverageListItem&la=" + scLanguage,
    null, //argument
    400,
    400,
    scInsertProductCoverageListItem,
    null,
    "Insert Product Coverage List Item",
    true, //modal
    Telerik.Web.UI.WindowBehaviors.Close, // behaviors
    false, //showStatusBar
    false //showTitleBar
  );
};

function scInsertProductCoverageListItem(sender, input) {
  if (!input) {
    return;
  }

  scEditor.pasteHtml(input);
}