using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace ACCCServerApp.Shard
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

        private Dictionary<string, LanguageResource> _languageResources = new Dictionary<string, LanguageResource>();

        private LanguageResource _languageResource;

        public LanguageResource LanguageResource {
            get
            {
                if(this._languageResource == null)
                {
                    this._languageResource = _languageResources[Thread.CurrentThread.CurrentCulture.Name];
                }

                return this._languageResource;
            }
        }

        public LanguageResource this[string lang]
        {
            get
            {
                this._languageResource = _languageResources[lang];
                return this._languageResource;
            }
        }


        private LanguageHandler() {
            if (_languageResources.Count <= 0)
            {
                _languageResources.Add("en-US", LoadLanguageSetting("en-US"));
                _languageResources.Add("ko-KR", LoadLanguageSetting("ko-KR"));
            }
        }

        private Dictionary<string, string> _keyValues = new Dictionary<string, string>
        {
            {"ko-KR",  "./Resource/Lang/ko-KR.json"},
            {"en-US",  "./Resource/Lang/en-US.json"}
        };

        private LanguageResource LoadLanguageSetting(string language)
        {
            var resourceJson = string.Empty;
            var keyValue = _keyValues.Where(m => m.Key == language).FirstOrDefault();
            LanguageResource langRes = null;

            if(string.IsNullOrEmpty(keyValue.Key))
            {
                keyValue = _keyValues.Where(m => m.Key == "en-US").First();
            }

            try
            {
                resourceJson = File.ReadAllText(keyValue.Value);

                langRes = JsonConvert.DeserializeObject<LanguageResource>(resourceJson);

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

            return langRes;
        }
    }
}
