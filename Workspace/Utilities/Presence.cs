﻿using DiscordRPC;
using Galaxy_Swapper_v2.Workspace.Properties;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Galaxy_Swapper_v2.Workspace.Utilities
{
    public static class Presence
    {
        private static RichPresence RichPresence;
        public static DiscordRpcClient Client;
        public static User User;
        public static void Initialize()
        {
            var Parse = Endpoint.Read(Endpoint.Type.Presence);

            Client = new DiscordRpcClient(Parse["ApplicationID"].Value<string>());
            

            RichPresence = new RichPresence()
            {
                Details = "Dashboard",
                State = Parse["State"].Value<string>(),
                Timestamps = Timestamps.Now,
                Buttons = Parse["Buttons"].Select(Button => new DiscordRPC.Button { Label = Button["Label"].Value<string>(), Url = Button["URL"].Value<string>() }).ToArray(),
                Assets = new Assets()
                {
                    LargeImageKey = Parse["LargeImageKey"].Value<string>(),
                    LargeImageText = Parse["LargeImageText"].Value<string>(),
                    SmallImageKey = Parse["SmallImageKey"].Value<string>(),
                    SmallImageText = Parse["SmallImageText"].Value<string>()
                }
            };

            
        }

        
    }
}