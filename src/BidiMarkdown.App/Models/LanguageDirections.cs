using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidiMarkdown.App.Models
{
    public enum LanguageDirection
    {
        LTR,
        RTL
    }

    public static class LanguageDirections
    {
        public static Dictionary<string, LanguageDirection> Directions = new Dictionary<string, LanguageDirection>()
        {
            { "af", LanguageDirection.LTR },
            { "ar", LanguageDirection.RTL },
            { "az", LanguageDirection.LTR },
            { "be", LanguageDirection.LTR },
            { "bg", LanguageDirection.LTR },
            { "bn", LanguageDirection.LTR },
            { "bs", LanguageDirection.LTR },
            { "ca", LanguageDirection.LTR },
            { "ceb", LanguageDirection.LTR },
            { "cs", LanguageDirection.LTR },
            { "cy", LanguageDirection.LTR },
            { "da", LanguageDirection.LTR },
            { "de", LanguageDirection.LTR },
            { "el", LanguageDirection.LTR },
            { "en", LanguageDirection.LTR },
            { "eo", LanguageDirection.LTR },
            { "es", LanguageDirection.LTR },
            { "et", LanguageDirection.LTR },
            { "eu", LanguageDirection.LTR },
            { "fa", LanguageDirection.RTL },
            { "fi", LanguageDirection.LTR },
            { "fr", LanguageDirection.LTR },
            { "ga", LanguageDirection.LTR },
            { "gl", LanguageDirection.LTR },
            { "gu", LanguageDirection.LTR },
            { "ha", LanguageDirection.RTL },
            { "hi", LanguageDirection.LTR },
            { "hmn", LanguageDirection.LTR },
            { "hr", LanguageDirection.LTR },
            { "ht", LanguageDirection.LTR },
            { "hu", LanguageDirection.LTR },
            { "hy", LanguageDirection.LTR },
            { "id", LanguageDirection.LTR },
            { "ig", LanguageDirection.LTR },
            { "is", LanguageDirection.LTR },
            { "it", LanguageDirection.LTR },
            { "iw", LanguageDirection.RTL },
            { "ja", LanguageDirection.LTR },
            { "jw", LanguageDirection.LTR },
            { "ka", LanguageDirection.LTR },
            { "kk", LanguageDirection.LTR },
            { "km", LanguageDirection.LTR },
            { "kn", LanguageDirection.LTR },
            { "ko", LanguageDirection.LTR },
            { "la", LanguageDirection.LTR },
            { "lo", LanguageDirection.LTR },
            { "lt", LanguageDirection.LTR}
        };
    }

}
