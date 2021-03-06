﻿using System;
using System.IO;

using static System.Console;

namespace CredentialCat.Console.Entities
{
    /// <summary>
    /// Represent all the options for search command"/>
    /// </summary>
    public class SearchCommandOptions
    {
        private string _passwordList;
        private string _userList;
        private string _export;

        /// <summary>
        /// If the query will be ignore the cache database
        /// </summary>
        public bool IgnoreCache { get; set; } = false;

        /// <summary>
        /// If the cache database update will be ignored
        /// </summary>
        public bool IgnoreUpdate { get; set; } = false;

        /// <summary>
        /// If the cache database will be forced to update 
        /// </summary>
        public bool ForceUpdate { get; set; } = false;

        /// <summary>
        /// If case sensitive will be used
        /// </summary>
        public bool CaseSensitive { get; set; } = false;

        /// <summary>
        /// If the default proxy will be ignored
        /// </summary>
        public bool BypassProxy { get; set; } = false;

        /// <summary>
        /// Max time for get an answer of the engine
        /// </summary> 
        public int Timeout { get; set; } = 3500;

        /// <summary>
        /// Max entities to return from a query
        /// </summary>
        public int Limit { get; set; } = 0;

        /// <summary>
        /// Path with the extension of the file to be exported
        /// </summary>
        public string Export
        {
            get => _export;
            set
            {
                if (value != null && (!value.EndsWith(".json", StringComparison.InvariantCulture) ||
                                      !value.EndsWith(".json", StringComparison.InvariantCulture)))
                {
                    WriteLine(
                        $"[!] Invalid export file format ({Path.GetExtension(value)})! Only CSV and JSON are supported!");
                    Environment.Exit(1);
                }

                if (File.Exists(value))
                {
                    WriteLine($"[!] Export file {value} already exist!");
                    Environment.Exit(1);
                }

                _export = value;
            }
        }

        /// <summary>
        /// Password or hash to be searched
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Password and/or hash wordlist to be searched
        /// </summary>
        public string PasswordList
        {
            get => _passwordList;
            set
            {
                if (!File.Exists(value))
                {
                    WriteLine($"[!] Password(s) and/or hash(es) wordlist ({value}) not exist!");
                    Environment.Exit(1);
                }

                _passwordList = value;
            }
        }

        /// <summary>
        /// User, username or email address
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// User, username or email address wordlist
        /// </summary>
        public string UserList 
        {
            get => _userList;
            set
            {
                if (!File.Exists(value))
                {
                    WriteLine($"[!] User(s) and/or email address(es) wordlist ({value}) not exist!");
                    Environment.Exit(1);
                }

                _userList = value;
            }
        }

        /// <summary>
        /// Search by given domain
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// Search domain by given wordlist
        /// </summary>
        public string DomainList { get; set; }

        /// <summary>
        /// If present, search on cache database with specific origin
        /// </summary>
        public string Origin { get; set; }
    }
}
