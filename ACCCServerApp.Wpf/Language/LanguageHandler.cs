using ACCCServerApp.Wpf.Resource;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace ACCCServerApp.Wpf.Language
{
    public class LanguageHandler
    {
        private static readonly Lazy<LanguageHandler> _instance =
            new Lazy<LanguageHandler>(() => new LanguageHandler());

        public static LanguageHandler Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private LanguageResource _languageResource = null;
        public LanguageResource LanguageResource {
            get
            {
                if(this._languageResource == null)
                {
                    InitLanguageResource(Thread.CurrentThread.CurrentCulture.Name);
                }

                return this._languageResource;
            }
        }

        private LanguageHandler() { }

        private Dictionary<string, string> _keyValues = new Dictionary<string, string>
        {
            {"ko-KR",  "./Resource/Lang/ko-KR.json"},
            {"en-US",  "./Resource/Lang/en-US.json"}
        };

        private void InitLanguageResource(string language)
        {
            var resourceJson = string.Empty;
            var keyValue = _keyValues.Where(m => m.Key == language).FirstOrDefault();

            if(string.IsNullOrEmpty(keyValue.Key))
            {
                keyValue = _keyValues.Where(m => m.Key == "en-US").First();
            }

            try
            {
                resourceJson = File.ReadAllText(keyValue.Value);

                _languageResource = JsonConvert.DeserializeObject<LanguageResource>(resourceJson);

                NumberFormatInfo numberFormatInfo = CultureInfo.CreateSpecificCulture(language).NumberFormat;
                CultureInfo cultureInfo = new CultureInfo(language);
                cultureInfo.NumberFormat = numberFormatInfo;

                if(language == "ko-KR")
                {
                    cultureInfo.DateTimeFormat.DateSeparator = "-";
                    cultureInfo.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
                }
                else
                {
                    cultureInfo.DateTimeFormat.DateSeparator = "/";
                    cultureInfo.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
                }

                Thread.CurrentThread.CurrentUICulture = cultureInfo;
                Thread.CurrentThread.CurrentCulture = cultureInfo;
            }
            catch(Exception e)
            {
                throw;
            }
        }
    }
}
