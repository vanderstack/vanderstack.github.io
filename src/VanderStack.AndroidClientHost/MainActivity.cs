using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;

namespace VanderStack.AndroidClientHost
{
    // add usings here
    using BlazorWebView.Android;
    using BlazorWebView;
    using System;
    using Serilog;
    using System.IO;
    using Microsoft.Extensions.Logging;
    using VanderStack.AndroidClientHost.Infrastructure.Exceptions;
    using VanderStack.Shared.Infrastructure.Exceptions;

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private BlazorWebView blazorWebView;

        private IDisposable disposable;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            // TODO: Log from Android.

            //// Configure Logging for Exceptions which occur outside of Blazor
            //Log.Logger =
            //    new LoggerConfiguration()
            //    .MinimumLevel.Verbose()
            //    .Enrich.WithMachineName()
            //    .Enrich.FromLogContext()
            //    // TODO: verify sinks are valid on android
            //    //.WriteTo.Console()
            //    //.WriteTo.Debug()
            //    //.WriteTo.AndroidLog()
            //    //.WriteTo.File(
            //    //    Path.Combine(Path.GetTempPath(), $"{nameof(VanderStack)}.log")
            //    //    , rollingInterval: RollingInterval.Day
            //    //    , retainedFileCountLimit: 7
            //    //)
            //    .CreateLogger()
            //;

            //var loggerFactory = new LoggerFactory().AddSerilog(Log.Logger);

            //_exceptionManager = new AndroidGlobalExceptionManager(
            //    new UnobservedExceptionLoggingHandler(loggerFactory.CreateLogger<IUnobservedExceptionHandler>())
            //    , new AppDomainUnhandledExceptionLoggingHandler(loggerFactory.CreateLogger<IAppDomainUnhandledExceptionHandler>())
            //);

            //_exceptionManager.Start();

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            this.SupportActionBar.Hide();
            this.blazorWebView = (BlazorWebView)this.SupportFragmentManager.FindFragmentById(Resource.Id.blazorWebView);

            // run blazor.
            this.disposable = BlazorWebViewHost.Run<Startup>(this.blazorWebView, "wwwroot/index.html", new AndroidAssetResolver(this.Assets, "wwwroot/index.html").Resolve);
        }

        protected override void OnDestroy()
        {
            if (this.disposable != null)
            {
                this.disposable.Dispose();
                this.disposable = null;
            }

            //_exceptionManager.Dispose();
            base.OnDestroy();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}