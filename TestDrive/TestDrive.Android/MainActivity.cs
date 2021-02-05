using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using TestDrive.Media;
using TestDrive.Droid;
using Android.Provider;
using Android.Content;
using Xamarin.Forms;


[assembly: Xamarin.Forms.Dependency(typeof(MainActivity))]
namespace TestDrive.Droid
{
    [Activity(Label = "TestDrive", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
        , ICamera
    {
        static Java.IO.File imageFile;

        [Obsolete]
        public void TakePhoto()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);

            imageFile = GetImageFile();

            intent.PutExtra(MediaStore.ExtraOutput,
                Android.Net.Uri.FromFile(imageFile));

            var activity = Forms.Context as Activity;
            activity.StartActivityForResult(intent, 0);

        }

        private static Java.IO.File GetImageFile()
        {
            Java.IO.File imageFile;
            Java.IO.File directory = new Java.IO.File(
      Android.OS.Environment.GetExternalStoragePublicDirectory(
      Android.OS.Environment.DirectoryPictures), "Images");

            if (!directory.Exists())
                directory.Mkdirs();

            imageFile =
                new Java.IO.File(directory, "MyPhoto.jpg");
            return imageFile;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            StrictMode.VmPolicy.Builder builder = new StrictMode.VmPolicy.Builder();
            StrictMode.SetVmPolicy(builder.Build());
            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new TestDrive.App());

        }
        
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok)
            {
                byte[] bytes;
                using (var stream = new Java.IO.FileInputStream(imageFile))
                { 
                    bytes = new byte[imageFile.Length()];
                    stream.Read(bytes);
                }
                MessagingCenter.Send<byte[]>(bytes, "TakePhoto");
            }
         }
    }
}