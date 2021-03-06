﻿using System;
using Android.Support.V4.View;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;

namespace SharedElement.Official.Droid.Adapters
{
    public partial class SelectedItemRecyclerAdapter : MvxRecyclerAdapter
    {
        public event EventHandler<SelectedItemEventArgs> OnItemClick;

        public SelectedItemRecyclerAdapter(IMvxAndroidBindingContext bindingContext)
              : base(bindingContext)
        {
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, BindingContext.LayoutInflaterHolder);
            View view = InflateViewForHolder(parent, viewType, itemBindingContext);

            return new SelectedItemViewHolder(view, itemBindingContext, OnClick)
            {
                Click = ItemClick,
                LongClick = ItemLongClick
            };
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ImageView itemLogo = holder.ItemView.FindViewById<ImageView>(Resource.Id.img_logo);
            ViewCompat.SetTransitionName(itemLogo, DroidConstants.Transition_Name_Image + position);

            TextView itemName = holder.ItemView.FindViewById<TextView>(Resource.Id.txt_name);
            ViewCompat.SetTransitionName(itemName, DroidConstants.Transition_Name_Text + position);

            base.OnBindViewHolder(holder, position);
        }

        private void OnClick(int position, View view, object dataContext)
            => OnItemClick?.Invoke(this, new SelectedItemEventArgs(position, view, dataContext));
    }
}
