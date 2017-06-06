using Sitecore.Forms.Mvc.Interfaces;
using Sitecore.WFFM.Abstractions.Data.Enums;
using System.Text;
using System.Web.Mvc;

namespace Sitecore.Support.Forms.Mvc.Html
{
  public static class HtmlHelperExtensions
  {
    public static MvcHtmlString SupportBootstrapSubmit(this HtmlHelper helper, string title = null)
    {
      TagBuilder builder = new TagBuilder("input")
      {
        Attributes = { {
            "type",
            "submit"
        } }
      };
      ISubmitSettings model = helper.ViewData.Model as ISubmitSettings;
      string submitButtonSize = string.Empty;
      string submitButtonType = string.Empty;
      string submitButtonName = string.Empty;
      string submitButtonPosition = string.Empty;
      if (model != null)
      {
        submitButtonSize = model.SubmitButtonSize;
        submitButtonType = model.SubmitButtonType;
        submitButtonName = model.SubmitButtonName;
        submitButtonPosition = model.SubmitButtonPosition;
      }
      builder.Attributes.Add("value", title ?? submitButtonName);
      StringBuilder builder2 = new StringBuilder();
      builder2.Append("btn").Append(" ").Append(submitButtonSize).Append(" ").Append(submitButtonType);
      IStyleSettings settings2 = helper.ViewData.Model as IStyleSettings;
      if ((settings2 != null) && (settings2.FormType != FormType.Inline))
      {
        TagBuilder builder3 = new TagBuilder("div");
        builder3.AddCssClass(("form-submit-border " + submitButtonPosition).Trim());
        builder.AddCssClass(builder2.ToString().Trim());
        builder3.InnerHtml = builder3.InnerHtml + builder.ToString(TagRenderMode.SelfClosing);
        return MvcHtmlString.Create(builder3.ToString());
      }
      builder.AddCssClass(builder2.ToString().Trim());
      return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
    }
  }
}
