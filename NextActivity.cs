using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XA_MT1_1
{
    [Activity(Label = "NextActivity")]
    public class NextActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.activity_next);

            var mobile = FindViewById<EditText>(Resource.Id.mobile);
            var website = FindViewById<EditText>(Resource.Id.website);

            var call = FindViewById<Button>(Resource.Id.call);
            var clear = FindViewById<Button>(Resource.Id.clear);
            var logout = FindViewById<Button>(Resource.Id.logout);
            var web = FindViewById<Button>(Resource.Id.web);

            string dMobile = Intent.GetStringExtra("mobile");
            string dWebsite = Intent.GetStringExtra("website");
            if(dMobile != "")   mobile.Text = dMobile;
            if (dWebsite != "")   website.Text = dWebsite;


            call.Click += delegate
            {
                if (!string.IsNullOrWhiteSpace(mobile.Text) || !string.IsNullOrEmpty(mobile.Text))
                {
                    try
                    {
                        var uri = Android.Net.Uri.Parse("tel:" + mobile);
                        var intent = new Intent(Intent.ActionDial, uri);
                        StartActivity(intent);
                    }
                    catch (Exception ex)
                    {
                        Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
                    }
                }
                else
                    Toast.MakeText(this, "Enter a mobile number!!!", ToastLength.Long).Show();
            };


            web.Click += delegate
            {
                if (!string.IsNullOrWhiteSpace(website.Text) || !string.IsNullOrEmpty(website.Text))
                {
                    try
                    {
                        var uri = Android.Net.Uri.Parse("http://" + website.Text);
                        var intent = new Intent(Intent.ActionView, uri);
                        StartActivity(intent);
                    }
                    catch (Exception ex)
                    {
                        // An unexpected error occured. No browser may be installed on the device.
                        Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
                    }
                }
                else
                    Toast.MakeText(this, "Enter a website number!!!", ToastLength.Long).Show();
            };

            clear.Click += delegate
            {
                mobile.Text = "";
                website.Text = string.Empty;
            };

            logout.Click += delegate
            {
                Intent i = new Intent(this, typeof(MainActivity));
                StartActivity(i);
            };

        }
    }
}