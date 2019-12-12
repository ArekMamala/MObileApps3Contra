# Banner ads for iOS developers
## Overview
This guide covers implementation for banner ads in your iOS game.

* If you are a Unity developer using C#, [click here](MonetizationBannerAdsUnity.md). 
* If you are an Android developer using Java, [click here](MonetizationBannerAdsAndroid.md). 
* [Click here](MonetizationResourcesApiIos.md#unityads) for the Objective-C `UnityAds` API reference.

## Configuring your game for Unity Ads
To implement banner ads, you must integrate Unity Ads in your Project. To do so, follow the steps in the [basic ads integration guide](MonetizationBasicIntegrationIos.md) that detail the following:

* [Creating a Project in the Unity developer dashboard](MonetizationBasicIntegrationIos.md#creating-a-project-in-the-unity-developer-dashboard)
* [Importing the Unity Ads framework](MonetizationBasicIntegrationIos.md#importing-the-unity-ads-framework)

Once your Project is configured for Unity Ads, proceed to creating a banner Placement.

## Creating a banner Placement
[Placements](MonetizationPlacements.md) are triggered events within your game that display monetization content. Manage Placements from the **Operate** tab of the [Developer Dashboard](https://operate.dashboard.unity3d.com/) by selecting your Project, then selecting **Monetization** > **Placements** from the left navigation bar.

Click the **ADD PLACEMENT** button to bring up the Placement creation prompt. Name your Placement and select the **Banner** type.

## Script implementation
Follow the steps in the basic integration guide for [initializing the SDK](MonetizationBasicIntegrationIos.md#initializing-the-sdk). You must intialize Unity Ads before displaying a banner ad.

Add your banner code in the `ViewController` implementation (`.m`). The following script sample is an example implementation for displaying banner ads. For more information on the classes referenced, see the [`UnityAdsBanner`](MonetizationResourcesApiIos.md#unityadsbanner) API section.

```
@interface ViewController: UIViewController <UnityAdsBannerDelegate>

@property (copy, nonatomic) NSString* bannerPlacementId;

@end

@implementation ViewController

-(void) viewDidLoad {
    [super viewDidLoad];
    [UnityAdsBanner setDelegate: self];
    [UnityAds initialize: @"1234567" delegate: nil testMode: YES];
}

// If the Placement is ready, load the banner:
-(void) loadBanner {
    if ([UnityAds isReady: self.bannerPlacementId]) {
        [UnityAdsBanner setDelegate: self];
        // Optionally set the banner anchor position:
        [UnityAdsBanner setBannerPosition:kUnityAdsBannerPositionBottomCenter];
        // Request ad content for your Placement, and load the banner:
        [UnityAdsBanner loadBanner: self.bannerPlacementId];
    }
}

-(void) unloadBanner {
    [UnityAdsBanner destroy];
}

-(void) unityAdsBannerDidClick: (NSString *) placementId {
    // Define behavior for the player clicking the banner.
}

-(void) unityAdsBannerDidError: (NSString *) message {
    // Define behavior for an error occurring within the banner.
    // Consider the banner unloaded.
}

-(void) unityAdsBannerDidHide: (NSString *) placementId {
    // The banner was hidden due to being removed from the view hierarchy or the window changing
}

-(void) unityAdsBannerDidShow: (NSString *) placementId {
    // The banner entered the view hierarchy and is visible to the user
}

// The banner loaded and is available to show:
-(void) unityAdsBannerDidLoad: (NSString *) placementId view: (UIView *) view {
    // Store the bannerView for later:
    self.bannerView = view;
    // Add the banner into your view hierarchy:
    [self.view addSubview:self.bannerView];
}

// The banner was destroyed, so references can be removed:
-(void) unityAdsBannerDidUnload: (NSString *) placementId {
    self.bannerView = nil;
}
@end
```

### Banner position
By default, banner ads display anchored on the bottom-center of the screen, supporting 320 x 50 or 728 x 90 pixel resolution. To specify the banner achor, use the [`setBannerPosition`](MonetizationResourcesApiIos.md#setbannerposition) method. For example:

```
[UnityAdsBanner setBannerPosition:kUnityAdsBannerPositionTopCenter];
```

## What's next? 
View documentation for [AR ads integration](MonetizationArAdsIos.md) to offer players a fully immersive and interactive experience by incorporating digital content directly into their physical world, or [return](Monetization.md) to the monetization hub.