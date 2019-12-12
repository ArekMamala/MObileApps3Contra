using System;

namespace UnityEngine.Advertisements
{
    interface IBanner
    {
        event EventHandler<StartEventArgs> OnShow;
        event EventHandler<HideEventArgs> OnHide;
        event EventHandler<ErrorEventArgs> OnError;
        event EventHandler<EventArgs> OnUnload;
        event EventHandler<EventArgs> OnLoad;

        bool isLoaded { get; }

        void Load(string placementId);
        void Show(string placementId);
        void Hide(bool destroy = false);
        void SetPosition(BannerPosition position);
    }
}
