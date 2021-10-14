using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Content;
using Android.Widget;

namespace XA_MT1_1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        string id = "abc";
        string c = "123";
        string mobile = "";
        string website = "";
        bool statuse = false;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var yourId = FindViewById<EditText>(Resource.Id.yourId);
            var code = FindViewById<EditText>(Resource.Id.code);

            var close = FindViewById<Button>(Resource.Id.close);
            var clear = FindViewById<Button>(Resource.Id.clear);
            var login = FindViewById<Button>(Resource.Id.login);
            var newAcount = FindViewById<Button>(Resource.Id.newAcount);

            statuse = Intent.GetBooleanExtra("statuse", false);

            if (statuse)
            {
                this.id = Intent.GetStringExtra("id");
               this.c = Intent.GetStringExtra("code");
               this.mobile = Intent.GetStringExtra("dMobile");
               this.website = Intent.GetStringExtra("dWebsite");
            }



            login.Click += delegate
            {
                // Make sure your username and password are entered
                if (!string.IsNullOrEmpty(yourId.Text) && !string.IsNullOrWhiteSpace(code.Text))
                {
                    // Match your username and password with stored data
                    if (yourId.Text == id && code.Text == c)
                    {
                        Intent i = new Intent(this, typeof(NextActivity));
                        i.PutExtra("mobile", mobile);
                        i.PutExtra("website", website);
                        StartActivity(i);
                    }
                    else
                    {
                        // Toast message to display the error!!! LONG (long time) - Last for about 4 seconds
                        Toast.MakeText(this, "Your Id  or Code is wrong!!!!", ToastLength.Long).Show();
                    }
                }
                else
                {
                    // Toast message to display the error!!! SHORT (short time) - Last forabout 2 seconds
                    Toast.MakeText(this, " Is Empty ", ToastLength.Short).Show();
                }
            };


            clear.Click += delegate
            {
                yourId.Text = "";
                code.Text = string.Empty;
            };

            close.Click += delegate
            {
                System.Environment.Exit(0);
                // JavaSystem.Exit(0);
            };


            newAcount.Click += delegate
            {
                Intent i = new Intent(this, typeof(RegActivity));
                StartActivity(i);
            };
        }
    }
}