﻿namespace OptionPattern.Settings
{
    public class SmtpSettings
    {
        public string Host { get; set; }
        public bool EnableSSL { get; set; }
        public int Port { get; set; }
        public DefaultValues Defaults { get; set; }

    }

    public class DefaultValues
    {
        public string From { get; set; }
        public string Subject { get; set; }
    }
}
