using System.Collections.Specialized;
using Sitecore.Data.Items;
using Sitecore.Shell.Applications.WebEdit;

namespace Wedia.Foundation.FieldEditor.Services
{
    public interface IGetFieldsToEditService
    {
        string GetFieldsToEdit(Item item);
        PageEditFieldEditorOptions GetFieldEditorOptions(NameValueCollection form, string pipedFields, Item item);
    }
}