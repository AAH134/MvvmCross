﻿using Cirrious.CrossCore.Interfaces.Platform;
using Cirrious.CrossCore.Interfaces.ServiceProvider;
using Cirrious.CrossCore.Plugins;
using Cirrious.MvvmCross.Application;
using Cirrious.MvvmCross.Interfaces.ViewModels;
using Cirrious.MvvmCross.Platform;
using Cirrious.MvvmCross.Plugins.Json;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;
using Cirrious.MvvmCross.WindowsPhone.Platform;
using Microsoft.Phone.Controls;

namespace BestSellers.WindowsPhone
{
    public class Setup 
        : MvxWindowsPhoneSetup
    {
        public Setup(PhoneApplicationFrame rootFrame)
            : base(rootFrame)
        {
        }

        protected override MvxApplication CreateApp()
        {
            var app = new BestSellers.App();
            return app;
        }

        protected override IMvxNavigationRequestSerializer CreateNavigationRequestSerializer()
        {
            Cirrious.MvvmCross.Plugins.Json.PluginLoader.Instance.EnsureLoaded();
            var json = this.GetService<IMvxJsonConverter>();
            return new MvxNavigationRequestSerializer(json);
        }

        protected override void AddPluginsLoaders(MvxLoaderPluginRegistry registry)
        {
            registry.AddConventionalPlugin<Cirrious.MvvmCross.Plugins.Visibility.WindowsPhone.Plugin>();
            base.AddPluginsLoaders(registry);
        }

        protected override void InitializeLastChance()
        {
            Cirrious.MvvmCross.Plugins.Visibility.PluginLoader.Instance.EnsureLoaded();
            base.InitializeLastChance();
        }
    }
}
