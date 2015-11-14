using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DataAccess
{
    public class ConfigDataAccess : ConfigurationSection
    {
        private static ConfigDataAccess configSettings = ConfigurationManager.GetSection(ConfigSectionConstant.NAMESECTION) as ConfigDataAccess;

        public static ConfigDataAccess ConfigSection
        {
            get { return configSettings; }
        }

        [ConfigurationProperty(ConfigSectionConstant.TYPEDBMANAGER,IsRequired=true)]
        public TypeDBManager TypeDBManager
        {
            get { return (TypeDBManager)(Enum.Parse(typeof(DataAccess.TypeDBManager), this[ConfigSectionConstant.TYPEDBMANAGER].ToString())); }
        }

        [ConfigurationProperty(ConfigSectionConstant.CONNECTIONSTRING,IsRequired=true)]
        public string ConnectionString
        {
            get { return this[ConfigSectionConstant.CONNECTIONSTRING].ToString(); }
        }
    }
}
