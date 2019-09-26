using FBM.Core.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Text;
using System.IO;

public enum Position
{
    Left, Right
}

public static class ButtonExtensions
{
    public static MvcHtmlString AddNewButton(this HtmlHelper helper, string url, Position buttonPosition = Position.Right, Position iconPosition = Position.Left, string id = "", bool openInNewTab = false, string text = "")
    {
        if (buttonPosition == Position.Right)
            return LinkButton(url, (String.IsNullOrEmpty(text)) ? Resources.AddNew : text, "btn-success pull-right", "fa-plus", id: id, openInNewTab: openInNewTab);
        else
            return LinkButton(url, (String.IsNullOrEmpty(text)) ? Resources.AddNew : text, "btn-success", "fa-plus", id: id, openInNewTab: openInNewTab);
    }

    public static MvcHtmlString ShoppingCartButton(this HtmlHelper helper, string url, string text = "", Position buttonPosition = Position.Left, Position iconPosition = Position.Left, string id = "", bool openInNewTab = false)
    {
        if (buttonPosition == Position.Right)
            return LinkButton(url, text, "btn-success pull-right", "fa-shopping-cart", id: id, openInNewTab: openInNewTab);
        else
            return LinkButton(url, text, "btn-success", "fa-shopping-cart", id: id, openInNewTab: openInNewTab);
    }

    public static MvcHtmlString SaveButton(this HtmlHelper helper, string text = "", Position position = Position.Left, string id = "__btnSave")
    {
        return SubmitButton(text == "" ? Resources.Save : text, String.Format("btn-success {0}", position == Position.Right ? "pull-right" : ""), "fa-floppy-o", id: id);
    }

    public static MvcHtmlString SearchButton(this HtmlHelper helper, Position position = Position.Left, string id = "__btnSearch")
    {
        return SubmitButton(Resources.Search, String.Format("btn-info {0}", position == Position.Right ? "pull-right" : ""), "fa-search", id: id);
    }

    public static MvcHtmlString PreviousPageButton(this HtmlHelper helper)
    {
        return LinkButton("javascript:;history.back(-1)", Resources.PreviousPage, "btn-default", "fa-arrow-left");
    }

    public static MvcHtmlString CancelButton(this HtmlHelper helper, string url, string id = "")
    {
        return LinkButton(url, Resources.Cancel, "btn-default", "fa-arrow-left", id: id);
    }

    public static MvcHtmlString DeleteButton(this HtmlHelper helper, string url, Position position = Position.Right, string id = "", bool openInNewTab = false)
    {
        return LinkButton(String.Format("javascript:;ApproveAndRedirect('{0}')", url), Resources.Delete, String.Format("btn-danger {0}", position == Position.Right ? "pull-right" : ""), "fa-trash", id: id, openInNewTab: openInNewTab);
    }

    public static MvcHtmlString EditButton(this HtmlHelper helper, string url, Position position = Position.Right, string id = "", bool openInNewTab = false)
    {
        return LinkButton(url, Resources.Edit, "btn-warning " + (position == Position.Right ? "pull-right" : ""), "fa-pencil", id: id, openInNewTab: openInNewTab);
    }

    public static MvcHtmlString ListButton(this HtmlHelper helper, string url, Position position = Position.Right, string name = "", string id = "", bool openInNewTab = false)
    {
        return LinkButton(url, name == "" ? Resources.List : name, "btn-info " + (position == Position.Right ? "pull-right" : ""), "fa-list", id: id, openInNewTab: openInNewTab);
    }

    public static MvcHtmlString SubmitButton(string text, string cssClass, string iconClass, Position iconPosition = Position.Left, string id = "")
    {
        string html = "<button id='{0}' class='btn {1}'>{2} <span>{3}</span> {4} </button>";

        string iconHtml = "";

        if (!String.IsNullOrEmpty(iconClass))
        {
            iconHtml = String.Format("<i class='fa {0}'></i>", iconClass);
        }

        return new MvcHtmlString(String.Format(html, id, cssClass, iconPosition == Position.Left ? iconHtml : "", text, iconPosition == Position.Right ? iconHtml : ""));
    }

    public static MvcHtmlString LinkButton(string url, string text, string cssClass, string iconClass, Position iconPosition = Position.Left, string id = "", bool openInNewTab = false)
    {

        string html = "<a href=\"{0}\" class='btn {1}' id='{5}' style='margin-left:6px;' {6}>{2} <span>{3}</span> {4} </a>";

        string iconHtml = "";

        if (!String.IsNullOrEmpty(iconClass))
        {
            iconHtml = String.Format("<i class='fa {0}'></i>", iconClass);
        }

        return new MvcHtmlString(String.Format(html, url,
                                                     cssClass,
                                                     iconPosition == Position.Left ? iconHtml : "",
                                                     text,
                                                     iconPosition == Position.Right ? iconHtml : "",
                                                     id,
                                                     openInNewTab ? "target='_blank'" : ""));
    }

    public static MvcHtmlString CustomActionButton(this HtmlHelper helper, string url, string text, string cssClass = "btn-info", string iconClass = null, Position iconPosition = Position.Left, string id = "", bool openInNewTab = false)
    {
        return LinkButton(url, text, cssClass, iconClass, iconPosition, id, openInNewTab);
    }

    public static IHtmlString FBMEditorFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, bool disabled = false, bool visible = true)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("<div class=\"form-group\">");
        builder.Append(htmlHelper.LabelFor(expression, new { @class = "control-label col-md-2" }));
        builder.Append("<div class=\"col-md-8\">");
        builder.Append(htmlHelper.EditorFor(expression, new { htmlAttributes = new { @class = "form-control" } }));
        builder.Append(htmlHelper.ValidationMessageFor(expression, "", new { @class = "text-danger" }));
        builder.Append("</div>");
        builder.Append("</div>");
        return MvcHtmlString.Create(builder.ToString());
    }

    public static IHtmlString FBMEnumDropDownListFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, bool disabled = false, bool visible = true)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("<div class=\"form-group\">");
        builder.Append(htmlHelper.LabelFor(expression, new { @class = "control-label col-md-2" }));
        builder.Append("<div class=\"col-md-8\">");
        builder.Append(htmlHelper.EnumDropDownListFor(expression, new { @class = "form-control" }));
        builder.Append(htmlHelper.ValidationMessageFor(expression, "", new { @class = "text-danger" }));
        builder.Append("</div>");
        builder.Append("</div>");
        return MvcHtmlString.Create(builder.ToString());
    }

    public static IHtmlString FBMDropDownListFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, IEnumerable<SelectListItem> items)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("<div class=\"form-group\">");
        builder.Append(htmlHelper.LabelFor(expression, new { @class = "control-label col-md-2" }));
        builder.Append("<div class=\"col-md-8\">");
        builder.Append(htmlHelper.DropDownListFor(expression, items, new { @class = "form-control" }));
        builder.Append(htmlHelper.ValidationMessageFor(expression, "", new { @class = "text-danger" }));
        builder.Append("</div>");
        builder.Append("</div>");
        return MvcHtmlString.Create(builder.ToString());
    }

    public static IHtmlString FBMDisplayFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("<dt>");
        builder.Append(htmlHelper.DisplayNameFor(expression));
        builder.Append("</dt>");
        builder.Append("<dd>");
        builder.Append(htmlHelper.DisplayFor(expression));
        builder.Append("</dd>");
        return MvcHtmlString.Create(builder.ToString());
    }
    public static IHtmlString FBMSplit(this HtmlHelper htmlHelper)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("<hr />");
        return MvcHtmlString.Create(builder.ToString());
    }
    public static IHtmlString FBMTab(this HtmlHelper htmlHelper, string target, string text)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(String.Format("<a href='#{0}' data-toggle='tab'>{1}</a>", target, text));
        return MvcHtmlString.Create(builder.ToString());
    }
    public static IHtmlString FBMSaveButton(this HtmlHelper htmlHelper, string text = "")
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("<div class='form-group'>");
        builder.Append("<div class='col-md-offset-2 col-md-10'>");
        builder.Append(htmlHelper.SaveButton(text));
        builder.Append("</div>");
        builder.Append("</div>");
        return MvcHtmlString.Create(builder.ToString());
    }
    public static IHtmlString FBMNavLiBtn(this HtmlHelper htmlHelper, string url, string text, bool hasIcon = false, string icon = "", string liClass = "")
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(String.Format("<li class='{0}'>", (String.IsNullOrEmpty(liClass) ? "" : liClass)));
        builder.Append(String.Format("<a href='{0}'>{1} {2}</a>", url, (hasIcon ? String.Format("<i class='{0}'></i>", icon) : ""), text));
        builder.Append("</li>");
        return MvcHtmlString.Create(builder.ToString());
    }
    public static IHtmlString FBMALink(this HtmlHelper htmlHelper, string url, string text, bool hasIcon = false, string icon = "", string @class = "")
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(String.Format("<a {0} {3}>{1} {2}</a>", (String.IsNullOrEmpty(url) ? "" : "href='" + url + "'"), (hasIcon ? String.Format("<i class='{0}'></i>", icon) : ""), text, (String.IsNullOrEmpty(@class) ? "" : "class='" + @class + "'")));
        return MvcHtmlString.Create(builder.ToString());
    }

    public static IHtmlString FBMClearFix(this HtmlHelper htmlHelper)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("<div class='clearfix'></div>");
        return MvcHtmlString.Create(builder.ToString());
    }
}