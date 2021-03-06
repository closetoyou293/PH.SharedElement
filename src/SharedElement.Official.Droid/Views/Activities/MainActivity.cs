﻿using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using MvvmCross.Core.Views;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views.Attributes;
using SharedElement.Official.Core.ViewModels;

namespace SharedElement.Official.Droid.Views
{
    [Activity(
        Theme = "@style/AppTheme",
        Name = DroidConstants.SharedElement_Views_Namespace + nameof(MainActivity))]
    public class MainActivity : MvxAppCompatActivity<MainViewModel>, IMvxOverridePresentationAttribute
    {
        public MvxBasePresentationAttribute PresentationAttribute()
        {
            return new MvxActivityPresentationAttribute();
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_main);
            SetSupportActionBar(FindViewById<Toolbar>(Resource.Id.toolbar));
            SetTitle(Resource.String.app_project_name);
        }
    }
}
