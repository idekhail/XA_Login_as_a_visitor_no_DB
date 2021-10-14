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
    [Activity(Label = "RegActivity")]
    public class RegActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.activity_reg);


            var yourId = FindViewById<EditText>(Resource.Id.yourId);
            var code = FindViewById<EditText>(Resource.Id.code);
            var dMobile = FindViewById<EditText>(Resource.Id.dMobile);
            var dWebsite = FindViewById<EditText>(Resource.Id.dWebsite);

            var create = FindViewById<Button>(Resource.Id.create);
            var cancel = FindViewById<Button>(Resource.Id.cancel);


            create.Click += delegate
            {
                if (!string.IsNullOrEmpty(yourId.Text) && !string.IsNullOrWhiteSpace(code.Text))
                {
                    Intent i = new Intent(this, typeof(MainActivity));
                    i.PutExtra("id", yourId.Text);
                    i.PutExtra("code", code.Text);
                    i.PutExtra("dMobile", dMobile.Text);
                    i.PutExtra("dWebsite", dWebsite.Text);
                    i.PutExtra("statuse", true);
                    StartActivity(i);
                }
                else
                    Toast.MakeText(this, " is empty  ", ToastLength.Long).Show();
            };


            cancel.Click += delegate
            {
                Intent i = new Intent(this, typeof(MainActivity));
                StartActivity(i);
            };

        }
    }
}