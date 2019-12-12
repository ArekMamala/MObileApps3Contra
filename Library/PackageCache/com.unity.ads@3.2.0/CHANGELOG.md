# Changelog
## [3.2.0] - 2019-07-22
### Unity (Editor, Asset Store, & Packman)
#### Features
* Added OMID viewability integration. Unity is now [IAB certified with VAST viewability](https://iabtechlab.com/blog/vast-4-1-open-measurement-the-long-awaited-video-verification-solution/).
#### Bug Fixes
* In cases where you've installed both the package manager and Asset store versions of Unity Ads, the SDK now surfaces an error notifying you to remove one instance.
* Fixed an Android java proxy usage issue for Unity versions below 2017. This fixes a multiple listeners crash. 

### iOS
#### Features
* Added OMID viewability integration. Unity is now [IAB certified with VAST viewability](https://iabtechlab.com/blog/vast-4-1-open-measurement-the-long-awaited-video-verification-solution/). 

### Android
#### Features
* Added OMID viewability integration. Unity is now [IAB certified with VAST viewability](https://iabtechlab.com/blog/vast-4-1-open-measurement-the-long-awaited-video-verification-solution/). 

## [3.1.1] - 2019-05-16
### Features
#### Update Android & iOS binaries to 3.1.0
#### Multiple Listeners
#### ASWebAuthenticationSession support
### Bug Fixes
#### Banner memory leak
#### GetDeviceId on android SDK < 23
#### Bugfix for volume change event not getting captured properly on ios
#### USRVStorage json exception caught and handled
#### Analytics onLevelUp takes a string instead of an int
#### Crash prevented in the AdUnitActivity.onPause
#### Playstation & Xbox no longer throw errors attempting to access UnityAdsSettings when building a project that includes ads on other platforms.
#### Test mode resources folder moved to editor only scope

## [3.0.3] - 2019-03-15

### Update Android & iOS binaries
### Fix https://fogbugz.unity3d.com/f/cases/1115398/
### Fix BYOP uncaught exception on iOS

## [3.0.2] - 2019-02-26

### Update Android & iOS binaries
### Fix https://fogbugz.unity3d.com/f/cases/1127423/
### Fix https://fogbugz.unity3d.com/f/cases/1127770/

## [3.0.1] - 2019-01-25

### Integrated Ads 3.0.1 SDK

## [2.3.2] - 2018-11-21

### Integrate Ads 2.3.0 SDK with Unity 2019.X
### Fixed Bugs:
#### https://fogbugz.unity3d.com/f/cases/1107128/
#### https://fogbugz.unity3d.com/f/cases/1108663/

## [2.3.1] - 2018-11-15

### Fixed

 * Update to Ads SDK 2.3.0
 * Multithreaded Request API
 * SendEvent API for Ads and IAP SDK communication
 * New Unity integration

## [2.2.1] - 2017-04-192

### Fixed

 * Fixed issues (iOS, Android)

## [2.2.0] - 2017-03-22

### Added

 * IAP Promotion support (iOS, Android)

### Changed

 * Improved cache handling (iOS, Android)
 * Increased flexibility showing different ad formats (iOS, Android)

### Fixed

 * Fixed a couple of rare crashes (iOS)
