using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace App286
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private TextView[] _dots { get; set; }
        private LinearLayout _dotsLayout { get; set; }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layout1);

            List<Android.Support.V4.App.Fragment> fragments = new List<Android.Support.V4.App.Fragment>();
            fragments.Add(new MyFragment_1());
            fragments.Add(new MyFragment_2());
            fragments.Add(new MyFragment_3());
            fragments.Add(new MyFragment_4());

            var adapter = new MyPagerAdapter(SupportFragmentManager, fragments);
            ViewPager pager = (ViewPager)FindViewById(Resource.Id.pager);
            pager.Adapter = adapter;
            pager.PageSelected += Pager_PageSelected;

            _dotsLayout = FindViewById<LinearLayout>(Resource.Id.indicator);
            AddDotsIndicator(0);
        }

        private void Pager_PageSelected(object sender, ViewPager.PageSelectedEventArgs e)
        {
            AddDotsIndicator(e.Position);
        }
        private void AddDotsIndicator(int pos)
        {
            _dots = new TextView[4];
            _dotsLayout.RemoveAllViews();
            for (int i = 0; i < _dots.Length; i++)
            {
                _dots[i] = new TextView(this);
                _dots[i].Text = "●";
                _dots[i].TextSize = 35;

                _dotsLayout.AddView(_dots[i]);
            }
            if (_dots.Length > 0)
                _dots[pos].SetTextColor(Android.Graphics.Color.Red); //change indicator color on selected page
        }
    }

    public class MyPagerAdapter : FragmentPagerAdapter
    {
        List<Android.Support.V4.App.Fragment> fragments;

        public MyPagerAdapter(Android.Support.V4.App.FragmentManager fm, List<Android.Support.V4.App.Fragment> fragments) : base(fm)
        {
            this.fragments = fragments;
        }
        public override int Count { get { return fragments.Count; } }

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            return fragments[position];
        }
    }

    public class MyFragment_1 : Android.Support.V4.App.Fragment
    {
        public MyFragment_1()
        {

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.mainLayout, container, false);
          
            return view;
        }
    }

    public class MyFragment_2 : Android.Support.V4.App.Fragment
    {
        public MyFragment_2()
        {
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.mainLayout, container, false);
          
            return view;
        }
    }

    public class MyFragment_3 : Android.Support.V4.App.Fragment
    {
        public MyFragment_3()
        {
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.mainLayout, container, false);

          

            return view;
        }
    }

    public class MyFragment_4 : Android.Support.V4.App.Fragment
    {
        public MyFragment_4()
        {
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.mainLayout, container, false);
    
            return view;
        }
    }
}
