# Banner ads for Android developers
## Overview
This guide covers implementation for banner ads in your Android game.

* If you are a Unity developer using C#, [click here](MonetizationBannerAdsUnity.md). 
* If you are an iOS developer using Objective-C, [click here](MonetizationBannerAdsIos.md). 
* [Click here](MonetizationResourcesApiAndroid.md#unityads) for the Java `UnityAds` API reference.

## Configuring your game for Unity Ads
To implement banner ads, you must integrate Unity Ads in your Project. To do so, follow the steps in the [basic ads integration guide](MonetizationBasicIntegrationAndroid.md) that detail the following:

* [Creating a Project in the Unity developer dashboard](MonetizationBasicIntegrationAndroid.md#creating-a-project-in-the-unity-developer-dashboard)
* [Importing the Unity Ads framework](MonetizationBasicIntegrationAndroid.md#importing-the-unity-ads-framework)

Once your Project is configured for Unity Ads, proceed to creating a banner Placement.

## Creating a banner Placement
[Placements](MonetizationPlacements.md) are triggered events within your game that display monetization content. Manage Placements from the **Operate** tab of the [Developer Dashboard](https://operate.dashboard.unity3d.com/) by selecting your Project, then selecting **Monetization** > **Placements** from the left navigation bar.

Click the **ADD PLACEMENT** button to bring up the Placement creation prompt. Name your Placement and select the **Banner** type.

## Script implementation
Follow the steps in the basic integration guide for [Initializing the SDK](MonetizationBasicIntegrationAndroid.md#initializing-the-sdk). You must intialize Unity Ads before displaying a banner ad.

In your game script, import the `UnityBanners` API, then implement an [`IUnityBannerListener`](MonetizationResourcesApiAndroid.md#iunitybannerlistener) interface to provide callbacks to the SDK. Use the [`loadBanner`](MonetizationResourcesApiAndroid.md#loadbanner) and [`destroy`](MonetizationResourcesApiAndroid.md#destroy) functions to show or hide the banner. The following script sample is an example implementation for displaying banner ads:

```
import com.unity3d.ads.IUnityAdsListener;
import com.unity3d.ads.UnityAds;
import com.unity3d.services.banners.UnityBanners;
import com.unity3d.services.banners.view.BannerPosition;
import android.view.View;

public class UnityBannerExample extends Activity {
    private String unityGameId = “1234567”;
    private Bool testMode = true;
    private String placementId = “banner”;
    private View bannerView;

    @Override
    protected void onCreate (Bundle savedInstanceState) {
        super.onCreate (savedInstanceState);
        setContentView (R.layout.unityads_example_layout);
        final Activity myActivity = this;
        // Declare a new banner listener, and set it as the active banner listener:
        final IUnityBannerListener myBannerListener = new UnityBannerListener ();
        UnityBanners.setBannerListener (myBannerListener);
        // Initialize the Ads SDK:
        UnityAds.initialize (this, unityGameID, myAdsListener, testMode);
    }

    // Implement a function to display or destroy a banner ad: 
    @Override
    public void ToggleBannerAd () {
        // If no banner exists, show one; otherwise remove the existing one:
        if (bannerView == null) {
            // Optionally specify the banner’s anchor position:
            UnityBanners.setBannerPosition (BannerPosition.BOTTOM_CENTER);
            // Request ad content for your Placement, and load the banner:
            UnityBanners.loadBanner (myActivity, "banner");
        } else {
            UnityBanners.destroy ();
        }
    }

    // Implement the banner listener interface methods:
    private class UnityBannerListener implements IUnityBannerListener {

        @Override
        public void onUnityBannerLoaded (String placementId, View view) {
            // When the banner content loads, add it to the view hierarchy:
            bannerView = view;
            ((ViewGroup) findViewById (R.id.unityads_example_layout_root)).addView (view);
        }

        @Override
        public void onUnityBannerUnloaded (String placementId) {
            // When the banner’s no longer in use, remove it from the view hierarchy:
            bannerView = null;
        }

        @Override
        public void onUnityBannerShow (String placementId) {
            // Called when the banner is first visible to the user.
        }

        @Override
        public void onUnityBannerClick (String placementId) {
            // Called when the banner is clicked.
        }

        @Override
        public void onUnityBannerHide (String placementId) {
            // Called when the banner is hidden from the user.
        }

        @Override
        public void onUnityBannerError (String message) {
            // Called when an error occurred, and the banner failed to load or show. 
        }
    }
}
```

### Banner position
By default, banner ads display anchored on the bottom-center of the screen, supporting 320 x 50 or 728 x 90 pixel resolution. To specify a custom banner achor, use the [`UnityBanners.setBannerPosition`](MonetizationResourcesApiAndroid.md#setbannerposition) method. For example:

```
UnityBanners.setBannerPosition (BannerPosition.TOP_CENTER);
```

## What's next? 
View documentation for [AR ads integration](MonetizationArAdsAndroid.md) to offer players a fully immersive and interactive experience by incorporating digital content directly into their physical world, or [return](Monetization.md) to the monetization hub.