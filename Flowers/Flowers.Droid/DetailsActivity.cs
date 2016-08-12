using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Flowers.Helpers;
using Flowers.Model;
using Flowers.ViewModel;
using GalaSoft.MvvmLight.Helpers;

namespace Flowers
{
    [Activity(Label = "Flower Details")]
    public partial class DetailsActivity
    {
        // This "fools" the linker into believing that the events are used.
        // In fact we don't even subscribe to them.
        // See https://developer.xamarin.com/guides/android/advanced_topics/linking/
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private static bool _falseFlag = false;

        private FlowerViewModel Vm { get; set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Details);

            // Retrieve navigation parameter and set as current "DataContext"
            Vm = GlobalNavigation.GetAndRemoveParameter<FlowerViewModel>(Intent);

            var headerView = LayoutInflater.Inflate(Resource.Layout.CommentsListHeaderView, null);
            headerView.FindViewById<TextView>(Resource.Id.NameText).Text = Vm.Model.Name;
            headerView.FindViewById<TextView>(Resource.Id.DescriptionText).Text = Vm.Model.Description;

            CommentsList.AddHeaderView(headerView);
            CommentsList.Adapter = Vm.Model.Comments.GetAdapter(GetCommentTemplate);

            ImageDownloader.AssignImageAsync(FlowerImageView, Vm.Model.Image, this);

            AddCommentButton.SetCommand(Vm.AddCommentCommand);

            // Subscribing to events to avoid linker issues in release mode ---------------------------------

            // This "fools" the linker into believing that the events are used.
            // In fact we don't even subscribe to them.
            // See https://developer.xamarin.com/guides/android/advanced_topics/linking/

            if (_falseFlag)
            {
                AddCommentButton.Click += (s, e) => { };
            }
        }

        private View GetCommentTemplate(int position, Comment comment, View convertView)
        {
            convertView = LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null);
            convertView.FindViewById<TextView>(Android.Resource.Id.Text1).Text = comment.Text;
            convertView.FindViewById<TextView>(Android.Resource.Id.Text2).Text = comment.InputDate.ToString();
            return convertView;
        }
    }
}