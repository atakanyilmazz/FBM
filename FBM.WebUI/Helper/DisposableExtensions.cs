using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

public static class DisposableExtensions
{
    private class FBMpanel : IDisposable
    {
        private readonly TextWriter _writer;
        public FBMpanel(TextWriter writer)
        {
            _writer = writer;
        }

        public void Dispose()
        {
            _writer.Write("</div></div></div>");
        }
    }

    public static IDisposable FBMPanel(this HtmlHelper html, string headerName, string @class = "col-md-12 col-sm-12 col-xs-12", bool colaps = false, bool cloasble = false)
    {
        var writer = html.ViewContext.Writer;
        writer.Write(string.Format("<div class='" + @class + "'><div class='x_panel'><div class='x_title'><h2>{0}</h2>{1}<div class='clearfix'></div></div><div class='x_content'>", headerName,(colaps || cloasble)? String.Format("<ul class='nav navbar-right panel_toolbox'>{0}{1}</ul>", (colaps? "<li><a class='collapse-link'><i class='fa fa-chevron-up'></i></a></li>" : ""), (cloasble ? "<li><a class='close-link'><i class='fa fa-close'></i></a></li>" : "")) :""));
        return new FBMpanel(writer);
    }

    private class FBMdiv : IDisposable
    {
        private readonly TextWriter _writer;
        public FBMdiv(TextWriter writer)
        {
            _writer = writer;
        }

        public void Dispose()
        {
            _writer.Write("</div>");
        }
    }

    public static IDisposable FBMDiv(this HtmlHelper html, string @class = "", string id = "", string style = "")
    {
        var writer = html.ViewContext.Writer;
        writer.Write(string.Format("<div class='{0}' {1} style='{2}'>", @class, (id != "" ? "id='" + id + "'" : ""),style));
        return new FBMdiv(writer);
    }


    private class FBMdl : IDisposable
    {
        private readonly TextWriter _writer;
        public FBMdl(TextWriter writer)
        {
            _writer = writer;
        }

        public void Dispose()
        {
            _writer.Write("</dl>");
        }
    }

    public static IDisposable FBMDl(this HtmlHelper html, string @class = "")
    {
        var writer = html.ViewContext.Writer;
        writer.Write(string.Format("<dl class='dl-horizontal {0}'>", @class));
        return new FBMdl(writer);
    }

    private class FBMdt : IDisposable
    {
        private readonly TextWriter _writer;
        public FBMdt(TextWriter writer)
        {
            _writer = writer;
        }

        public void Dispose()
        {
            _writer.Write("</dt>");
        }
    }

    public static IDisposable FBMDt(this HtmlHelper html, string @class = "")
    {
        var writer = html.ViewContext.Writer;
        writer.Write(string.Format("<dt class='{0}'>", @class));
        return new FBMdt(writer);
    }

    private class FBMdd : IDisposable
    {
        private readonly TextWriter _writer;
        public FBMdd(TextWriter writer)
        {
            _writer = writer;
        }

        public void Dispose()
        {
            _writer.Write("</dd>");
        }
    }

    public static IDisposable FBMDd(this HtmlHelper html, string @class = "")
    {
        var writer = html.ViewContext.Writer;
        writer.Write(string.Format("<dd class='{0}'>", @class));
        return new FBMdt(writer);
    }

    private class FBMul : IDisposable
    {
        private readonly TextWriter _writer;
        public FBMul(TextWriter writer)
        {
            _writer = writer;
        }

        public void Dispose()
        {
            _writer.Write("</ul>");
        }
    }

    public static IDisposable FBMUl(this HtmlHelper html, string @class = "", string id = "", string style = "")
    {
        var writer = html.ViewContext.Writer;
        writer.Write(string.Format("<ul class='{0}' id='{1}' style='{2}'>", @class, id,style));
        return new FBMul(writer);
    }

    private class FBMli : IDisposable
    {
        private readonly TextWriter _writer;
        public FBMli(TextWriter writer)
        {
            _writer = writer;
        }

        public void Dispose()
        {
            _writer.Write("</li>");
        }
    }

    public static IDisposable FBMLi(this HtmlHelper html, string @class = "", string id = "")
    {
        var writer = html.ViewContext.Writer;
        writer.Write(string.Format("<li class='{0}' id='{1}'>", @class, id));
        return new FBMli(writer);
    }

}