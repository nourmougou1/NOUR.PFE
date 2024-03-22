﻿using Microsoft.Extensions.Configuration;
using NOUR.PFE.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOUR.PFE.DataLayer.DB
{
    public class SettingDB
    {
        public static IConfigurationRoot Configuration;
        public static string ConnStr;
        public static string DBType;

        static SettingDB()
        {
            try
            {
                Configuration = GetConfiguration();

                bool _IsEncrypted = !string.IsNullOrEmpty(Configuration.GetSection("ApplicationParams").GetSection("app_connection_string_is_encrypted").Value)
                                    ? Convert.ToBoolean(Configuration.GetSection("ApplicationParams").GetSection("app_connection_string_is_encrypted").Value)
                                    : false;

                ConnStr = _IsEncrypted
                          ? Crypto.Decrypt(Configuration.GetSection("ConnectionStrings").GetSection("app_data_base_connection_string").Value, Entities.Constant.CONST_CIPHER_PHRASE)
                          : Configuration.GetSection("ConnectionStrings").GetSection("app_data_base_connection_string").Value;

                DBType = !string.IsNullOrEmpty(Configuration.GetSection("ApplicationParams").GetSection("app_data_base_type").Value)
                         ? Configuration.GetSection("ApplicationParams").GetSection("app_data_base_type").Value
                         : "SqlServer";

            }
            catch (Exception ex)
            {
                string strEx = ex.Message;
                throw;
            }
        }

        public static IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory.TrimEnd(Path.DirectorySeparatorChar)).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
    }
}

