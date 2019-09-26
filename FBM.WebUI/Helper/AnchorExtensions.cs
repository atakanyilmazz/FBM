using FBM.Core.Resource;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

public static class AnchorExtensions
{
    public static MvcHtmlString AddNewAnchor(this HtmlHelper helper, string url)
    {

        return Anchor(url, Resources.AddNew, "fa-plus");
    }

    public static MvcHtmlString PreviousPageButton(this HtmlHelper helper)
    {
        return Anchor("javascript:;history.back(-1)", Resources.PreviousPage, "fa-arrow-left");
    }

    public static MvcHtmlString CancelAnchor(this HtmlHelper helper, string url, string id = "")
    {
        return Anchor(url, Resources.Cancel, "fa-arrow-left", id: id);
    }
    public static MvcHtmlString DeleteAnchor(this HtmlHelper helper, string url, Position position = Position.Left, string id = "")
    {
        return Anchor(String.Format("javascript:;ApproveAndRedirect('{0}')", url), Resources.Delete, "fa-trash", id: id);
    }
    public static MvcHtmlString EditAnchor(this HtmlHelper helper, string url, string id = "")
    {
        return Anchor(url, Resources.Edit, "fa-pencil", id: id);
    }
    public static MvcHtmlString ListAnchor(this HtmlHelper helper, string url, string name, string id = "")
    {
        return Anchor(url, name, "fa-list", id: id);
    }
    public static MvcHtmlString CardAnchor(this HtmlHelper helper, string url, string id = "")
    {
        return Anchor(url, Resources.Card, "fa-info", id: id);
    }

    public static MvcHtmlString DetailAnchor(this HtmlHelper helper, string url, string id = "")
    {
        return Anchor(url, Resources.Detail, "fa-info", id: id, cssClass: "cursor-pointer");
    }
    public static MvcHtmlString Anchor(string url, string text, string iconClass, string cssClass = "", Position iconPosition = Position.Left, string id = "")
    {
        //yetki burada sor
        string html = "<a id='{0}' href=\"{1}\" class='{2}'>{3} <span>{4}</span> {5} </a>";

        string iconHtml = "";

        if (!String.IsNullOrEmpty(iconClass))
        {
            iconHtml = String.Format("<i class='fa {0}'></i>", iconClass);
        }

        return new MvcHtmlString(String.Format(html, id, url, cssClass, iconPosition == Position.Left ? iconHtml : "", text, iconPosition == Position.Right ? iconHtml : ""));
    }

    public static MvcHtmlString CustomAnchor(this HtmlHelper helper, string url, string text, string cssClass = "btn-info", string iconClass = null, Position iconPosition = Position.Left, string id = "")
    {
        return Anchor(url, text, cssClass, iconClass, iconPosition, id: id);
    }

    public static MvcHtmlString EditListItem(this HtmlHelper helper, string url, string id = "")
    {
        return GetListItem(AnchorExtensions.EditAnchor(helper, url, id: id));
    }

    public static MvcHtmlString DeleteListItem(this HtmlHelper helper, string url, string id = "")
    {
        return GetListItem(AnchorExtensions.DeleteAnchor(helper, url, id: id));
    }

    public static MvcHtmlString CardListItem(this HtmlHelper helper, string url, string id = "")
    {
        return GetListItem(AnchorExtensions.CardAnchor(helper, url, id: id));
    }

    public static MvcHtmlString DetailListItem(this HtmlHelper helper, string url, string id = "")
    {
        return GetListItem(AnchorExtensions.DetailAnchor(helper, url, id: id));
    }

    public static MvcHtmlString CustomListItem(this HtmlHelper helper, string url, string text, string iconClass, string cssClass = "", Position iconPosition = Position.Left, string id = "")
    {
        return GetListItem(Anchor(url, text, iconClass, cssClass: cssClass, iconPosition: iconPosition, id: id));
    }

    public static MvcHtmlString GetListItem(MvcHtmlString str)
    {
        return new MvcHtmlString(String.Format("<li>{0}</li>", str.ToString()));
    }

    public static MvcHtmlString BeginActionMenu(this HtmlHelper helper, string title = "", string iconClass = "", string btnCss = "", string additionalClass = "", string dropdownAdditionalClass = "", string id = "")
    {
        if (String.IsNullOrEmpty(title))
        {
            title = Resources.Actions;
        }
        string iconHtml = "";
        if (!String.IsNullOrEmpty(iconClass))
        {
            iconHtml = String.Format("<i class='fa {0}'></i>", iconClass);
        }

        if (String.IsNullOrEmpty(btnCss))
        {
            btnCss = "btn-default";
        }
        string html = "<div class='dropdown " + dropdownAdditionalClass + "'>" +
    "<button id='" + id + "' class='btn " + btnCss + " " + additionalClass + "' data-toggle='dropdown'>" +
        iconHtml +
        title +
        "<span class='caret'></span>" +
    "</button>" +
   "<ul class='dropdown-menu' role='menu'>";

        return new MvcHtmlString(html);
    }

    public static MvcHtmlString EndActionMenu(this HtmlHelper helper)
    {
        string html = "</ul>" +
        "</div>";
        return new MvcHtmlString(html);
    }

    public static string FileLink(string filename)
    {
        string url = String.Format("/File/Download?f={0}", filename);

        return url;
    }

    public static string FileLink(this HtmlHelper helper, string filename)
    {
        var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);

        string url = urlHelper.Action("Download", "File", new { area = "", f = filename });

        return url;
    }

    public static MvcHtmlString FileAnchor(this HtmlHelper helper, string filename, string title = "")
    {
        string url = FileLink(helper, filename);

        if (String.IsNullOrEmpty(title))
        {
            title = Resources.DownloadLink;
        }
        return new MvcHtmlString(String.Format("<a target='_blank' href='{0}'>{1}</a>", url, title));
    }
}